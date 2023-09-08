
namespace BravoMarket.DAL.Entities
{
    public class ClientFAQAnswer : TimeStample
    {
        public string Answer { get; set; }
        public int ClientFAQTitleId { get; set; }

        public ClientFAQTitle ClientFAQTitle { get; set; }
    }
}
