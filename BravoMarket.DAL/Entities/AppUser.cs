using Microsoft.AspNetCore.Identity;

namespace BravoMarket.DAL.Entities
{
    public class AppUser : IdentityUser

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? MiddleName { get; set; }
        public DateTime? LastSignInDate { get; set; }
        public DateTime? BirthDay { get; set; }

    }
}
