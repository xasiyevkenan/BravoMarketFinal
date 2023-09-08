
namespace BravoMarket.DAL.Entities
{
    public class MarketType : TimeStample
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string TagName { get; set; }
        public string PdfUrl { get; set; }

        public ICollection<Market> Markets { get; set; } 
    }
}
