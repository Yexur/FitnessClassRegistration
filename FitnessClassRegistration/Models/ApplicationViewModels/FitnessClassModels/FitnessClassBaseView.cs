using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassBaseView
    {
        public int Id { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = " Please pick a start time")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = @"{0:h\:mm}")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = " Please pick an end time")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = @"{0:h\:mm}")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Class Date")]
        [Required(ErrorMessage = " Please pick a date for the class")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfClass { get; set; }

        [Display(Name = "Active")]
        public bool Status { get; set; }

        [Display(Name = "Total Capacity")]
        [Required(ErrorMessage = "Please choose a Capacity between 1 and 15")]
        [Range(1, 15, ErrorMessage = "Please choose a Capacity between 1 and 15")]
        public int Capacity { get; set; }

        [Display(Name = "Remaining Capacity")]
        public int RemainingCapacity { get; set; }
    }
}
