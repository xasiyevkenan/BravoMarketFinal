
namespace BravoMarket.DAL.Entities
{
    public class ClientFAQ : TimeStample
    {
        public string Title { get; set; }
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public ICollection<ClientFAQTitle> Questions { get; set; }
    }
}
