using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Pages
{
    //[Authorize(Roles ="Driver")]
    public class PodróżeModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public PodróżeModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<TripModel> Trips { get; set; }

        public void OnGet()
        {
            Trips = _context.TripModel.ToList();
        }
        [BindProperty]
        public TripModel TripModel { get; set; } = default!;
        
        public IActionResult OnPost()
        {
            _context.TripModel.Add(TripModel);
            _context.SaveChanges();
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
                foreach (var error in errors)
                {

                }
                return Page();
            }
            return RedirectToPage("./Index");
        
        }
        
        /*public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TripModel == null || TripModel == null)
            {
                return RedirectToPage("./Index");
            }

            _context.TripModel.Add(TripModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        */
    }
}
