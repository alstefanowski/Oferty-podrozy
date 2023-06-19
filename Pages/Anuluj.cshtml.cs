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
using Projekt.Models;

namespace Projekt.Pages
{
    [Authorize(Roles = "User")]
    public class AnulujModel : PageModel
    {

        private readonly Projekt.Data.ApplicationDbContext _context;

        public AnulujModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        // public TripModel TripModel { get; set; } = default!;
        [BindProperty]
        public UsersTrip UsersTrip { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UsersTrip == null)
            {
                return NotFound();
            }

            var userstrip = await _context.UsersTrip.FirstOrDefaultAsync(m => m.Id == id);
           // var tripmodel = await _context.TripModel.FirstOrDefaultAsync(a => a.Id == userstrip.tID);

            if (userstrip == null )
            {
                return NotFound();
            }
            else
            {
                UsersTrip = userstrip;
                //TripModel = tripmodel;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UsersTrip == null)
            {
                return NotFound();
            }
            var userstrip = await _context.UsersTrip.FindAsync(id);
            //var tripmodel = await _context.TripModel.FirstOrDefaultAsync(a => a.Id == userstrip.tID);

            if (userstrip != null)
            {
                UsersTrip = userstrip;
                //tripmodel.Number_of_people += 1;
                _context.UsersTrip.Remove(UsersTrip);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./TwojePrzejazdy");
        }        
    }
}
