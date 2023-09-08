using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BravoMarket.MVC.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email ünvanı boş ola bilməz.")]
        [EmailAddress(ErrorMessage = "Düzgün bir email ünvanı daxil edin.")]
        [Display(Name = "Email")]
        public string ToEmail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
