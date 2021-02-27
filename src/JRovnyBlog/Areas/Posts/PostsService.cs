using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JRovnyBlog.Areas.Posts
{

    public class PostsService : IPostsService
    {
        private readonly ApplicationDbContext _context;

        public PostsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostSummary>> GetAllBlogPostsAsync()
        {
            return await _context.Posts
                .AsNoTracking()
                .Where(p => p.Published == true)
                .Select(p => new PostSummary
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Slug = p.Slug,
                    Image = p.Image,
                    CommentCount = p.CommentCount,
                    UpvoteCount = p.UpvoteCount,
                    CreatedDate = p.CreatedDate
                })
                .ToListAsync();
        }
    }
}