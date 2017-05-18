using System.Collections.Generic;
using FitnessClassRegistration.Core;

namespace ApplicationModels.FitnessApp.Models
{
    public class Instructor : EntityBase
    {
        public string Name { get; set; }
        public List<FitnessClass> FitnessClasses { get; set; }

        public bool Status { get; set; }
    }
}
