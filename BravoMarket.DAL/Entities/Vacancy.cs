
namespace BravoMarket.DAL.Entities
{
    public class Vacancy : TimeStample
    {
        public string Title { get; set; }
        public string Adress { get; set; }
        public string? Time { get; set; }
        public int CareerId { get; set; }
        public int VacancyTypeId { get; set; }

        public Career Career { get; set; }
        public VacancyType VacancyType { get; set; }
    }
}
