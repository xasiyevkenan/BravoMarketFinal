
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BravoMarket.DAL.Entities
{
    public class KSMActivity : TimeStample
    {
        [MaxLength(300)]
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NewsId { get; set; }

        public News News { get; set; }
    }
}
