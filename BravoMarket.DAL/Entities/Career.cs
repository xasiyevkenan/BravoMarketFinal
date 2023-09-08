
namespace BravoMarket.DAL.Entities
{
    public class Career : TimeStample
    {
        public string BGImageUrl { get; set; }
        public string FirstImageUrl { get; set; }
        public string SecondImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonInner { get; set; }
        public string LinkController { get; set; }
        public string HeadTitle { get; set; }
        public string HeadDescription { get; set; }
        public string PromiseTitle { get; set; }

        public Preference Preference { get; set; }
        public CareerBanner CareerBanner { get; set; }
        public Employer Employer { get; set; }

        public ICollection<Promise> Promises { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
