using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRovnyBlog.Areas.Posts
{
    public interface IPostsService
    {
        Task<IEnumerable<Models.PostSummary>> GetAllBlogPostsAsync();
        Task<Models.PostDetail> GetBySlugAsync(string slug);
    }
}