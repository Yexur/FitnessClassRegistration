using FitnessApp.Core;

namespace ApplicationModels.FitnessApp.Models
{
    public class RegistrationRecord : EntityBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool WaitListed { get; set; }
        public int FitnessClass_Id { get; set; }
        public bool Attended { get; set; }
        public FitnessClass FitnessClass { get; set; }
    }
}
