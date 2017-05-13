using System.Collections.Generic;
using FitnessClassRegistration.Core;

namespace ApplicationModels.FitnessApp.Models
{
    public class Location : EntityBase
    {
        public string Name { get; set; }
        public List<FitnessClass> FitnessClasses { get; set; }
    }
}
