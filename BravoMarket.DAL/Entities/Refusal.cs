
namespace BravoMarket.DAL.Entities
{
    public class Refusal : TimeStample
    {
        public string Title { get; set; }

        public ICollection<Refusalİnfo> RefusalInformations { get; set; } 
    }
}
