using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Domains;
using Infrastructure.Dtos.Posts;
using Microsoft.AspNetCore.Mvc;
using RazorBlog.Api.Services.Posts;

namespace RazorBlog.Api.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetPosts();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody]PostRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = new Post
            {
                Title = request.Title,
                Permalink = request.Permalink,
                Description = request.Description,
                Content = request.Content,
                Status = request.Status,
                CreatedBy = request.CurrentUser,
                ModifiedBy = request.CurrentUser
            };

            await _postService.CreatePost(post);

            return Ok(request);
        }
    }
}