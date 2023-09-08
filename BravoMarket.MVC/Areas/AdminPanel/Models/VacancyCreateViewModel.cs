using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BravoMarket.MVC.Areas.AdminPanel.Models
{
    public class VacancyCreateViewModel
    {
        public VacancyCreateViewModel()
        {
            VacancyTypeSelectList = new List<SelectListItem>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlıq mütləqdir")]
        [MaxLength(100, ErrorMessage = "Başlıq 100 simvoldan çox ola bilməz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Vakansiya növü mütləqdir")]
        public int SelectedVacancyTypeId { get; set; }

        public List<SelectListItem> VacancyTypeSelectList { get; set; }

        public string? Time { get; set; }

        [MaxLength(100, ErrorMessage = "Ünvan 100 simvoldan çox ola bilməz")]
        public string Adress { get; set; }
    }
}


