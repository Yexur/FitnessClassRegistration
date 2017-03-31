using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassEditView : FitnessClassBaseView
    {
        [Display(Name = "Fitness Class")]
        [Required(ErrorMessage = "Please supply a Fitness Class")]
        public int FitnessClassType_Id { get; set; }

        public ICollection<SelectListItem> FitnessClassTypes { get; set; }

        [Display(Name = "Instructor")]
        [Required(ErrorMessage = "Please supply an Instructor")]
        public int Instructor_Id { get; set; }

        public ICollection<SelectListItem> Instructors { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please supply a Location")]
        public int Location_Id { get; set; }

        public ICollection<SelectListItem> Locations { get; set; }
    }
}
