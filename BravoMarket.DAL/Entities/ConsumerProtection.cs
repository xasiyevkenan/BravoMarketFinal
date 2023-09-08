
namespace BravoMarket.DAL.Entities
{
    public class ConsumerProtection : TimeStample
    {
        public string Title { get; set; }
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public ICollection<ConsumerProtectionInfo> ConsumerProtectionInfos { get; set; }
    }
}
