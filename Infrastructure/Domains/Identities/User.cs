using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Infrastructure.Domains.Identities
{
    public class User : IdentityUser<long>
    {
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsEnabled { get; set; }

        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
