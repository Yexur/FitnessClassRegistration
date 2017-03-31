using FitnessApp.Core;
using System.Collections.Generic;

namespace ApplicationModels.FitnessApp.Models
{
    public class Instructor : EntityBase
    {
        public string Name { get; set; }
        public List<FitnessClass> FitnessClasses { get; set; }

        public bool Status { get; set; }
    }
}
