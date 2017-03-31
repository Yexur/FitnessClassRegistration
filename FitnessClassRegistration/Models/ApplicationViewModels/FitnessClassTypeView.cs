using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassTypeView
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please supply a Fitness Class")]
        [Display(Name = "Fitness Class")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

    }
}
