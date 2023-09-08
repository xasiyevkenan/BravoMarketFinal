using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BravoMarket.MVC.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "Yeni şifrə tələb olunur.")]
        [StringLength(100, ErrorMessage = "Şifrə ən az {2} simvol uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifrə")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifrəni Təsdiq Et")]
        [Compare("Password", ErrorMessage = "Yeni şifrə və təsdiq şifrəsi eyni olmalıdır.")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
