using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class TripModel
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Cost must be grater than 0")]
        public int Cost { get; set; }
        public DateTime Departure { get; set; }

        [Display(Name ="Expected arrival")]
        [CustomDateValidation(ErrorMessage = "Expected arrival date must be greater than Departure date")]
        public DateTime Expected_arrival { get; set; }
        public string? Destination { get; set; }

        [Display(Name="Starting place ")]
        public string? Starting_place { get; set; }

        [Display(Name = "Number of people")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of people must be grater than 0")]
        public int Number_of_people { get; set; }
        public bool Smoking { get; set; }
        public ContactStatus Status { get; set; }

        //public List<BusModel> Buses { get; set; }
    }
    public class CustomDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (TripModel)validationContext.ObjectInstance;

            if (!(DateTime.Compare(model.Departure, model.Expected_arrival) < 0))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

    public enum ContactStatus
    {
        Dostępna,
        Niedostępna
    }
}
