using System.ComponentModel.DataAnnotations;

namespace FitnessClassRegistration.Models.ApplicationViewModels
{
    public class InstructorView
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please supply an Instructor")]
        [Display(Name = "Instructor")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

    }
}
