using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Pages
{
    [Authorize(Roles = "Driver")]
    public class DeleteModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public DeleteModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TripModel TripModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TripModel == null)
            {
                return NotFound();
            }

            var tripmodel = await _context.TripModel.FirstOrDefaultAsync(m => m.Id == id);

            if (tripmodel == null)
            {
                return NotFound();
            }
            else 
            {
                TripModel = tripmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TripModel == null)
            {
                return NotFound();
            }
            var tripmodel = await _context.TripModel.FindAsync(id);

            if (tripmodel != null)
            {
                TripModel = tripmodel;
                _context.TripModel.Remove(TripModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
