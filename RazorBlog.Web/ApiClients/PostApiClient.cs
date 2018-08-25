using Infrastructure.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RazorBlog.Web.ApiClients
{
    public class PostApiClient
    {
        private readonly HttpClient _httpClient;

        public PostApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatePostAsync(PostRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/posts", request);

            response.EnsureSuccessStatusCode();
        }
    }
}
