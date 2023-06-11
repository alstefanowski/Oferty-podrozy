using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Pages
{
    public class DołączModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public DołączModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<LoggedUserModel> LoggedUsers { get; set; }
        public string Enter { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LoggedUserModel LoggedUserModel { get; set; } = default!;
        public TripModel Trip { get; set; }
        public async Task<IActionResult> OnGetAsync(int ?id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Trip = await _context.TripModel
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Trip == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid || _context.Offers == null || LoggedUserModel == null)
            {
                return Page();
            }
            _context.Offers.Add(LoggedUserModel);
            await _context.SaveChangesAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trip = await _context.TripModel.FindAsync();
            if(trip == null)
            {
                return NotFound();
            }
            trip.Number_of_people--;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
