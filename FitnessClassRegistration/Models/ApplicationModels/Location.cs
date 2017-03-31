using FitnessApp.Core;
using System.Collections.Generic;

namespace ApplicationModels.FitnessApp.Models
{
    public class Location : EntityBase
    {
        public string Name { get; set; }
        public List<FitnessClass> FitnessClasses { get; set; }
    }
}
