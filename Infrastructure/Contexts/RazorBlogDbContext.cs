using Infrastructure.Domains;
using Infrastructure.Domains.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class RazorBlogDbContext : IdentityDbContext<
        User,
        Role,
        long,
        UserClaim,
        UserRole,
        UserLogin,
        RoleClaim,
        UserToken>
    {
        public RazorBlogDbContext(DbContextOptions<RazorBlogDbContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                   .ToTable("User");

            builder.Entity<Role>()
                .ToTable("Role");

            builder.Entity<UserClaim>()
                .ToTable("UserClaim");

            builder.Entity<UserRole>(b =>
            {
                b.HasKey(ur => new { ur.UserId, ur.RoleId });
                b.HasOne(ur => ur.Role).WithMany(x => x.Users).HasForeignKey(r => r.RoleId);
                b.HasOne(ur => ur.User).WithMany(x => x.Roles).HasForeignKey(u => u.UserId);
                b.ToTable("UserRole");
            });

            builder.Entity<UserLogin>()
                .ToTable("UserLogin");

            builder.Entity<RoleClaim>()
                .ToTable("RoleClaim");

            builder.Entity<UserToken>()
                .ToTable("UserToken");

            builder.Entity<Post>()
                .ToTable("Post")
                .HasKey(p => p.Id);

            builder.Entity<Tag>()
                .ToTable("Tag")
                .HasKey(t => t.Id);

            builder.Entity<PostTag>(b =>
            {
                b.HasKey(pt => new { pt.PostId, pt.TagId });
                b.HasOne(pt => pt.Post).WithMany(x => x.Tags).HasForeignKey(r => r.PostId);
                b.HasOne(pt => pt.Tag).WithMany(x => x.Posts).HasForeignKey(u => u.TagId);
                b.ToTable("PostTag");
            });

            builder.Entity<Comment>()
                .ToTable("Comment")
                .HasKey(c => c.Id);
        }
    }
}
