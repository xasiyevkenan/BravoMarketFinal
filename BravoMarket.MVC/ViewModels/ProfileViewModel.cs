using System.ComponentModel.DataAnnotations;

namespace BravoMarket.MVC.ViewModels
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Ad sahəsi tələb olunur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad sahəsi tələb olunur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "İstifadəçi adı sahəsi tələb olunur.")]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessage = "Şifrə və Şifrəni Təsdiq Et sahələri uyğun gəlmir.")]
        public string? ConfirmNewPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email sahəsi tələb olunur.")]
        public string Email { get; set; }

        public DateTime? BirthDay { get; set; }
        public DateTime? LastSignInDate { get; set; }
        public string? MiddleName { get; set; }
        public string? UserId { get; set; }
    }
}
