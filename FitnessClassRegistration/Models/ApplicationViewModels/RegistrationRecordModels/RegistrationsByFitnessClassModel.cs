using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessClassRegistration.Models.ApplicationViewModels
{
    public class RegistrationsByFitnessClassModel
    {
        public List<RegistrationRecordView> RegistrationRecords { get; set; }
        //public int Id { get; set; }

        //[Display(Name = "User Name")]
        //public string UserName { get; set; }

        //public string Email { get; set; }

        //[Display(Name = "On Wait List")]
        //public bool WaitListed { get; set; }

        //[Display(Name = "Remove Registration")]
        //public bool DeleteRegistration { get; set; }

        //public int FitnessClass_Id { get; set; }

        //public bool Attended { get; set; }

        //public string FitnessClassName { get; set; }
    }
}
