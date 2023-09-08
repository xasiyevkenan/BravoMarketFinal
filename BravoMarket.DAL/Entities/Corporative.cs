
namespace BravoMarket.DAL.Entities
{
    public class Corporative : TimeStample
    {
        public string ClientServiceTitle { get; set; }
        public string ClientServiceDescription { get; set; }

        public CorporativeBanner CorporativeBanner { get; set; }

        public ICollection<CorporativeClientService> CorporativeClientServices { get; set; }
    }
}
