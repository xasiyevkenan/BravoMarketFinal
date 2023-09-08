
namespace BravoMarket.DAL.Entities
{
    public class PreferenceParagraph : TimeStample
    {
        public string Inner { get; set; }
        public int PreferenceId { get; set; }

        public Preference Preference { get; set; }
    }
}
