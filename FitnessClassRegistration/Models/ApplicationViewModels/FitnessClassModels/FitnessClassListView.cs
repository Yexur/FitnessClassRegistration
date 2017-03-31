using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassListView : FitnessClassBaseView
    {
        [Display(Name = "Instructor")]
        public InstructorView Instructor { get; set; }


        [Display(Name = "Room")]
        public LocationView Location { get; set; }

        [Display(Name = "Fitness Class")]
        public FitnessClassTypeView FitnessClassType { get; set;}
    }
}
