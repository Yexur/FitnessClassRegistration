using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class AnnouncementView
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please supply a Title")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please supply a Comment")]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }
}
