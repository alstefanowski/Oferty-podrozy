using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Models;
using System.Security.Claims;

namespace Projekt.Pages
{
    //[Authorize(Roles = "Driver")]
    public class KierowcaModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public KierowcaModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DriverModel Driver { get; set; }
        /*
        public void OnGet()
        {
            string driverId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string driverUserName = User.FindFirstValue(ClaimTypes.Email);
            var driver = new DriverModel
            {
                DriverId = driverId,
                UserName = driverUserName
            };
            _dbContext.Drivers.Add(driver);
            _dbContext.SaveChanges();
        }
        */
    }
}
