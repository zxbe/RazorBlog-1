using Infrastructure.Domains;
using Infrastructure.Dtos.Posts;
using System.Linq;

namespace Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static PostResponse MapPostResponse(this Post post)
        {
            return new PostResponse
            {
                Id = post.Id,
                Title = post.Title,
                Permalink = post.Permalink,
                Description = post.Description,
                Content = post.Content,
                Status = post.Status,
                CreatedBy = post.CreatedBy,
                CreatedDate = post.CreatedDate,
                ModifiedBy = post.ModifiedBy,
                ModifiedDate = post.ModifiedDate,
                //Comments = post.Comments.Select(c => new Comment {

                //    Content = c.Content,
                //    CreatedBy = c.CreatedBy,
                //    CreatedDate = c.CreatedDate,
                //    Id = c.Id,
                //    IsApproved = c.IsApproved,
                //    ModifiedBy = c.ModifiedBy,
                //    ModifiedDate = c.ModifiedDate

                //}).ToList(),
                //Tags = post.Tags.Select(pt => new PostTag
                //{
                //    //Id = pt.TagId,
                //    //Description = pt.Tag.Description,
                //    //IsApproved = pt.Tag.IsApproved,
                //    //Name = pt.Tag.Name,
                //    //Slug = pt.Tag.Slug
                //}).ToList()
            };
        }
    }
}
