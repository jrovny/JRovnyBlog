using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JRovnyBlog.Areas.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JRovnyBlog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPostsService _postsService;
        public IEnumerable<Models.PostSummary> Posts;

        public IndexModel(ILogger<IndexModel> logger, IPostsService postsService)
        {
            _logger = logger;
            _postsService = postsService;
        }

        public async Task OnGet()
        {
            Posts = await _postsService.GetAllBlogPostsAsync();
        }
    }
}
