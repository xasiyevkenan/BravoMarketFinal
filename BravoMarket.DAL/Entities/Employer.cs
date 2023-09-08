
namespace BravoMarket.DAL.Entities
{
    public class Employer : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CareerId { get; set; }

        public Career Career { get; set; }
    }
}
