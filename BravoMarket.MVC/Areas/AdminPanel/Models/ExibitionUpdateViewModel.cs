using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BravoMarket.MVC.Areas.AdminPanel.Models
{
    public class ExibitionUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Image")]
        [Required]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }
    }
}
