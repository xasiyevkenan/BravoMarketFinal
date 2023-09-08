
namespace BravoMarket.DAL.Entities
{

    public class VacancyType : TimeStample
    {
        public string Type { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
