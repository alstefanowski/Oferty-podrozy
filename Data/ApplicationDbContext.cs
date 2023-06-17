using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Projekt.Models.TripModel>? TripModel { get; set; }
        public DbSet<Projekt.Models.UsersTrip>? UsersTrip { get; set; }
        public DbSet<DriverModel>? Drivers { get; set; }
        public DbSet<LoggedUserModel>? Offers { get; set; }
    }
}