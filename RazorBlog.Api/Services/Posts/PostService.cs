using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contexts;
using Infrastructure.Domains;
using Infrastructure.Dtos.Posts;
using Infrastructure.Extensions;
using Infrastructure.Extensions.Pages;
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

        public PagedList<PostResponse> PagedPosts(PagingParams pagingParams)
        {
            var query = _db.Posts.Select(p => p.MapPostResponse()).AsQueryable();
                                
            var result = new PagedList<PostResponse>(query, pagingParams.PageIndex, pagingParams.PageSize);

            return result;
        }
    }
}
