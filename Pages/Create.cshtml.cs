using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public CreateModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TripModel TripModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TripModel == null || TripModel == null)
            {
                return Page();
            }

            _context.TripModel.Add(TripModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
