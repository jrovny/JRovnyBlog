using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JRovnyBlog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JRovnyBlog.Services
{

    public class PostsService : IPostsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostsService(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<Models.PostSummary>> GetAllBlogPostsAsync()
        {
            return await _context.Posts
                .AsNoTracking()
                .Where(p => p.Published == true)
                .Select(p => new Models.PostSummary
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Slug = p.Slug,
                    Image = p.Image,
                    CreatedDate = p.CreatedDate
                })
                .OrderByDescending(p => p.PostId)
                .ToListAsync();
        }

        public async Task<Models.PostDetail> GetBySlugAsync(string slug)
        {
            Post post = await _context.Posts
                            .AsNoTracking()
                            .Where(p => p.Slug == slug && p.Published == true)
                            .FirstOrDefaultAsync();

            await AddToViewCountAsync(post);

            return _mapper.Map<Models.PostDetail>(post);
        }

        private async Task AddToViewCountAsync(Post post)
        {
            post.ViewCount++;
            _context.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}