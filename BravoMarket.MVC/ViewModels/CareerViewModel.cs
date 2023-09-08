using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class CareerViewModel
    {
        public Career Career { get; set; }
        public CareerBanner CareerBanner { get; set; }
        public Employer Employer { get; set; }
        public Preference Preference { get; set; }

        public List<Promise> Promises { get; set; }
        public List<PreferenceParagraph> PreferenceParagraphs { get; set; }
        public List<Vacancy> Vacancies { get; set; }
        public List<VacancyType> VacancyTypes { get; set;}
    }
}
