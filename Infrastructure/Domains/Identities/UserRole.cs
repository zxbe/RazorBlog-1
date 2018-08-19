using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Domains.Identities
{
    public class UserRole : IdentityUserRole<long>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
