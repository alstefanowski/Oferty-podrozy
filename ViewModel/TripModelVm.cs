namespace Projekt.ViewModel
{
    public class TripModelVm
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Expected_arrival { get; set; }
        public string? Destination { get; set; }
        public string? Starting_place { get; set; }
        public int Number_of_people { get; set; }
        public bool Smoking { get; set; }
    }
}
