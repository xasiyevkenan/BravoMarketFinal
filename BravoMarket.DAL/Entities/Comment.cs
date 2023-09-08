
namespace BravoMarket.DAL.Entities
{
    public class Comment : TimeStample
    {
        public string UploadTitle { get; set; }
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public ICollection<CommentType> CommentTypes { get; set; }
    }
}
