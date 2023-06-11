using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public DetailsModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
