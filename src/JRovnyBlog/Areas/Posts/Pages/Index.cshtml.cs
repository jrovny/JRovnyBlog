using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JRovnyBlog.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JRovnyBlog.Areas.Posts.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPostsService _postsService;
        public IEnumerable<PostSummary> Posts;

        public IndexModel(IPostsService postsService)
        {
            _postsService = postsService;
        }

        public async Task OnGetAsync()
        {
            Posts = await _postsService.GetAllBlogPostsAsync();
        }
    }
}
