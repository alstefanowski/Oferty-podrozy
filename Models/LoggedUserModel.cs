using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class LoggedUserModel
    {
        public int Id { get; set; }
        public string? Destination { get; set; }
    }
}
