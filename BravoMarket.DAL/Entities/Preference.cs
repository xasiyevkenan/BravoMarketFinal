
namespace BravoMarket.DAL.Entities
{
    public class Preference : TimeStample
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int CareerId { get; set; }

        public Career Career { get; set; }

        public ICollection<PreferenceParagraph> Paragraphs { get; set; }
    }
}
