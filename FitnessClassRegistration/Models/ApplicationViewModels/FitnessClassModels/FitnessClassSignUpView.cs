using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassSignUpView
    {
        public int Id { get; set; }

        [Display(Name = "Start Time")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = @"{0:h\:mm}")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "End Time")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = @"{0:h\:mm}")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Class Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfClass { get; set; }

        [Display(Name = "Remaining Capacity")]
        public int RemainingCapacity { get; set; }

        [Display(Name = "Fitness Class")]
        public FitnessClassTypeView FitnessClassType { get; set; }

        [Display(Name = "Instructor")]
        public InstructorView Instructor { get; set; }

        [Display(Name = "Room")]
        public LocationView Location { get; set; }

        [Display(Name = "Attending ?")]
        public bool Attending { get; set; }
    }
}
