using FitnessApp.Core;

namespace ApplicationModels.FitnessApp.Models
{
    public class Announcement : EntityBase
    {
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}
