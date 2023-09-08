
namespace BravoMarket.DAL.Entities
{
    public class Contact : TimeStample
    {
        public string Title { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
        public string ClientServiceHead { get; set; }
        public string ClientServiceDescription { get; set; }

        public Comment Comment { get; set; }
        public ICollection<ClientFAQ> ClientFAQs   { get; set; }
        public ICollection<ConsumerProtection> ConsumerProtections { get; set; }
    }
}
