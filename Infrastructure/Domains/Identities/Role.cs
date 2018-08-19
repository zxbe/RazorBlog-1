using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Infrastructure.Domains.Identities
{
    public class Role : IdentityRole<long>
    {
        public ICollection<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
