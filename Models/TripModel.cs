using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class TripModel
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Expected_arrival { get; set; }
        public string? Destination { get; set; }
        public int Number_of_people { get; set; }
        public bool Smoking { get; set; }
        public ContactStatus Status { get; set; }
        public List<BusModel> Buses { get; set; }
    }
    
    public enum ContactStatus
    {
        Zapisany,
        Niezapisany
    }
}
