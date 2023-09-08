
namespace BravoMarket.DAL.Entities
{
    public class ConsumerProtectionInfo : TimeStample
    {
        public string Information { get; set; }
        public int ConsumerProtectionId { get; set; }

        public ConsumerProtection ConsumerProtection { get; set; }
    }
}
