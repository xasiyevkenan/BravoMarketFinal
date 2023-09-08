using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class VacancyViewModel
    {
        public List<Vacancy> Vacancies { get; set; }
        public List<VacancyType> VacancyTypes{ get; set; }
    }
}
