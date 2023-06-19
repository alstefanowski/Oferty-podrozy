using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class ReplyModel
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime? CreateOn { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UsersTrip User { get; set; }
        public int CommentId { get; set; }

        [ForeignKey("CommentId")]
        public virtual CommentModel Comment { get; set; }
    }
}
