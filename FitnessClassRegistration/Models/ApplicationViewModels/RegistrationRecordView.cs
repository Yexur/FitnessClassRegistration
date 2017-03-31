using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class RegistrationRecordView
    {
        public int Id { get; set; }

        [Display(Name = "")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "On Wait List")]
        public bool WaitListed { get; set; }

        [Display(Name = "Remove Registration")]
        public bool DeleteRegistration { get; set; }
         
        public int FitnessClass_Id { get; set; }

        public bool Attended { get; set; }

        public FitnessClassListView FitnessClass { get; set; }
    }
}
