using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRovnyBlog.Areas.Posts
{
    public interface IPostsService
    {
        Task<IEnumerable<PostSummary>> GetAllBlogPostsAsync();
    }
}