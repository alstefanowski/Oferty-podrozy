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
    [Authorize]
    public class DołączModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public DołączModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<LoggedUserModel> Offers { get; set; }
        public string Enter { get; set; }

        [BindProperty]
        public LoggedUserModel LoggedUser { get; set; } = default!;
        public TripModel Trip { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trip = await _context.TripModel.FirstOrDefaultAsync(m => m.Id == id);
            string find_user = User.FindFirstValue(ClaimTypes.Email);
            if (trip == null)
            {
                return NotFound();
            }
            if(trip.Number_of_people <= 0)
            {
                return BadRequest("Brak wolnych miejsc na wybraną wycieczkę");
            }
            if (trip.Number_of_people == 1)
            {
                trip.Status++;
                //return BadRequest("Brak wolnych miejsc na wybraną wycieczkę");
            }
            trip.Number_of_people--;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
