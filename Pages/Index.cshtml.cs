using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;

namespace Projekt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public IndexModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string DestinationSort { get; set; }
        public string NumberOfPeopleSort { get; set; }
        public string CostSort { get; set; }
        public string IsSmokingSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<TripModel> TripModel { get;set; } = default!;

        [Authorize(Roles = "Driver")]
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "destination_desc" : "";
            //DestinationSort = sortOrder == "Destination" ? "destination_desc" : "Destination";
            NumberOfPeopleSort = sortOrder == "People" ? "people_desc" : "People";
            //IsSmokingSort = sortOrder == "Smoking" ? "smoking_desc" : "smoking";
            CostSort = sortOrder == "Cost" ? "cost_desc" : "Cost";
            CurrentFilter = searchString;

            IQueryable<TripModel> tripsQ = from s 
                                           in _context.TripModel 
                                           select s;
            if(!String.IsNullOrEmpty(searchString) )
            {
                tripsQ = tripsQ.Where(s => s.Destination.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "destination_desc":
                    tripsQ = tripsQ.OrderByDescending(s => s.Destination);
                    break;
                case "People":
                    tripsQ = tripsQ.OrderBy(s => s.Number_of_people);
                    break;
                case "people_desc":
                    tripsQ = tripsQ.OrderByDescending(s => s.Number_of_people);
                    break;
                    /*
                case "smoking_desc":
                    tripsQ = tripsQ.OrderByDescending(s => s.Smoking);
                    break;
                case "smoking":
                    tripsQ = tripsQ.OrderBy(s => s.Smoking);
                    break;
                    */
                case "cost_desc":
                    tripsQ = tripsQ.OrderByDescending(s => s.Cost);
                    break;
                case "Cost":
                    tripsQ = tripsQ.OrderBy(s => s.Cost);
                    break;
                default:
                    tripsQ = tripsQ.OrderBy(s => s.Destination);
                    break;

            }
            TripModel = await tripsQ.AsNoTracking().ToListAsync();
        }
        public IActionResult OnPost(string sortOrder, string searchString)
        {
            var trips = from s in _context.TripModel select s;
            if(!String.IsNullOrEmpty(searchString))
            {
                trips = trips.Where(s => s.Destination.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "Cost":
                    trips = trips.OrderBy(s => s.Cost);
                    break;
                case "Smoking":
                    trips = trips.OrderBy(s => s.Smoking);
                    break;
                default:
                    trips = trips.OrderBy(s => s.Destination); 
                    break;
            }
            return Page();
        }
    }
}
