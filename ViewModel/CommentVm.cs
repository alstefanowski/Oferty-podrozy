namespace Projekt.ViewModel
{
    public class CommentVm
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int Rating { get; set; }
        public string? Description { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
