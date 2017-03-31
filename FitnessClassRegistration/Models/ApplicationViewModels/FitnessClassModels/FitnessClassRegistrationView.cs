using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassRegistrationView
    {
        public int FitnessClass_Id { get; set; }

        public int RegistrationRecord_Id { get; set; }

        [Display(Name = "User")]
        public string UserName { get;  set;}

        [Display(Name = "Start Time")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = @"{0:h\:mm}")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "End Time")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = @"{0:h\:mm}")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Class Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfClass { get; set; }

        [Display(Name = "Fitness Class")]
        public string FitnessClassTypeName { get; set; }

        [Display(Name = "Instructor")]
        public string InstructorName { get; set; }

        [Display(Name = "Room")]
        public string LocationName { get; set; }

        [Display(Name = "On Wait List")]
        public bool WaitListed { get; set; }

        [Display(Name = "Remove Registration")]
        public bool DeleteRegistration { get; set; }
    }
}
