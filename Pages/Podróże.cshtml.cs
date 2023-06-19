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
    [Authorize(Roles = "Driver")]
    public class PodróżeModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public PodróżeModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public TripModel TripModel { get; set; } = default!;
        public DriverModel Driver { get; set; } = default!;
        public IActionResult OnPost()
        { 
            if (!ModelState.IsValid )
            {
                return Page();
            }
            DriverModel Driver = new DriverModel();
            Driver.UserName = User.FindFirstValue(ClaimTypes.Name);
            Driver.DriverId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Driver.Description = TripModel.Starting_place + " - " + TripModel.Destination + ": " + TripModel.Departure + " - " + TripModel.Expected_arrival;
            _context.TripModel.Add(TripModel);
            _context.Drivers.Add(Driver);
            _context.SaveChanges();
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
