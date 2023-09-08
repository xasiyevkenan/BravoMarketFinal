
namespace BravoMarket.DAL.Entities
{
    public class Promise : TimeStample
    {
        public string IconUrl { get; set; }
        public string FirstPromise { get; set; }
        public string SecondPromise { get; set; }
        public string ThirdPromise { get; set; }
        public int CareerId { get; set; }

        public Career Career { get; set;}
    }
}
