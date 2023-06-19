using Projekt.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class CommentModel
    {

    
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int Rating { get; set; }

        [Required]
        public string? Description { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
