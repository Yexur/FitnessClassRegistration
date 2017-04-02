using System.ComponentModel.DataAnnotations;

namespace FitnessClassRegistration.Models.ApplicationViewModels
{
    public class LocationView
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please supply a Location")]
        [Display(Name = "Location")]
        public string Name { get; set; }
    }
}
