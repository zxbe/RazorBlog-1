using Infrastructure.Domains;
using Infrastructure.Dtos.Posts;
using Infrastructure.Extensions.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorBlog.Api.Services.Posts
{
    public interface IPostService
    {
        Task CreatePost(Post post);
        Task<IEnumerable<PostResponse>> GetPosts();
        PagedList<PostResponse> PagedPosts(PagingParams pagingParams);
    }
}
