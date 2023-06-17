using System.ComponentModel.DataAnnotations;
namespace Projekt.Models
{
    public class UsersTrip
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Destination { get; set; }
        [Display(Name = "Starting place ")]
        public string? Starting_place { get; set; }
        public DateTime Departure { get; set; }

        [Display(Name = "Expected arrival")]
        public DateTime Expected_arrival { get; set; }

    }
}
