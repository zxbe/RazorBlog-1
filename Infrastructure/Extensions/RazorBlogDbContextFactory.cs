using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Infrastructure.Extensions
{
    public class RazorBlogDbContextFactory : IDesignTimeDbContextFactory<RazorBlogDbContext>
    {
        public RazorBlogDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RazorBlogDbContext>();

            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RazorBlog;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new RazorBlogDbContext(builder.Options);
        }
    }
}
