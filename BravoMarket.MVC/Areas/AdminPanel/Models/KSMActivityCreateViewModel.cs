using System.ComponentModel.DataAnnotations;

namespace BravoMarket.MVC.Areas.AdminPanel.Models
{
    public class KSMActivityCreateViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Image")]
        [Required]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }

        public int NewsId { get; set; } 
    }
}
