
namespace BravoMarket.DAL.Entities
{
    public class CareerBanner : TimeStample
    {
        public string QuestionTitle { get; set; }
        public string QuestionAnswer { get; set; }
        public string ImageUrl { get; set; }
        public int CareerId { get; set; }

        public Career Career { get; set; }
    }
}
