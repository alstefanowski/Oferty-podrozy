using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Pages
{
    [Authorize(Roles = "Driver")]
    public class EditModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public EditModel(Projekt.Data.ApplicationDbContext context)
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

            var tripmodel =  await _context.TripModel.FirstOrDefaultAsync(m => m.Id == id);
            if (tripmodel == null)
            {
                return NotFound();
            }
            TripModel = tripmodel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TripModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripModelExists(TripModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TripModelExists(int id)
        {
          return (_context.TripModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
