using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Data.Migrations;
using Projekt.Models;

namespace Projekt.Pages
{
    [Authorize(Roles = "User")]
    public class DołączModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public DołączModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public string Enter { get; set; }
        public string ErrorMessage { get; set; }

        [BindProperty]
        public TripModel Trip { get; set; }

        public UsersTrip usersTrip { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trip = await _context.TripModel.FirstOrDefaultAsync(m => m.Id == id);
            string f_user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userstrip = await _context.UsersTrip.Where(a => a.UserId == f_user).ToListAsync();
            string find_user = User.FindFirstValue(ClaimTypes.Email);
            if (trip == null)
            {
                return NotFound();
            }
            if(trip.Number_of_people <= 0)
            {
                TempData["ErrorMessage"] = "Nie możesz dołączyć do podróży, ponieważ nie ma już wolnych miejsc";
                
                return RedirectToPage("./Index"); 
            }
            if (!(userstrip == null))
            {
                foreach (var user in userstrip)
                {
                    if ((user.Departure.CompareTo(trip.Departure) >= 0 && user.Departure.CompareTo(trip.Expected_arrival) <= 0) || (user.Expected_arrival.CompareTo(trip.Departure) >= 0 && user.Expected_arrival.CompareTo(trip.Expected_arrival) <= 0))
                    {
                        TempData["ErrorMessage"] = "Nie mozesz dołączyć do podróży, ponieważ masz już zaplanowaną podróż na ten termin";

                        return RedirectToPage("./Index");
                    }
                }
            }
            if (trip.Number_of_people == 1)
            {
                trip.Status++;
                //return BadRequest("Brak wolnych miejsc na wybraną wycieczkę");
            }
            trip.Number_of_people--;
            var usersTrip = new UsersTrip
            {
                UserId = f_user,
                Trip = trip.Id,
                Starting_place = trip.Starting_place,
                Destination = trip.Destination,
                Departure = trip.Departure,
                Expected_arrival = trip.Expected_arrival
            };
            _context.UsersTrip.Add(usersTrip);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
