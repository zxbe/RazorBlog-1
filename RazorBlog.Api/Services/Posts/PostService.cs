using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contexts;
using Infrastructure.Domains;
using Infrastructure.Dtos.Posts;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace RazorBlog.Api.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly RazorBlogDbContext _db;

        public PostService(RazorBlogDbContext db)
        {
            _db = db;
        }

        public async Task CreatePost(Post post)
        {
            if (post != null)
            {
                await _db.Posts.AddAsync(post);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PostResponse>> GetPosts()
        {
            var posts = await _db.Posts.AsNoTracking()
                                       .ToListAsync();

            var result = posts.Select(p => p.MapPostResponse());

            return result;
        }
    }
}
