using System.Threading.Tasks;
using JRovnyBlog.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace JRovnyBlog.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly IPostsService _postsService;
        private readonly IConfiguration _configuration;

        public IndexModel(IPostsService postsService, IConfiguration configuration)
        {
            _postsService = postsService;
            _configuration = configuration;
        }

        [BindProperty(SupportsGet = true)]
        public string Slug { get; set; }
        public Models.PostDetail Post;
        public HtmlString PostContent;

        public async Task OnGetAsync()
        {
            Post = await _postsService.GetBySlugAsync(Slug);
            PostContent = new HtmlString(Post.Content);

            ViewData["ogurl"] = HttpContext.Request.GetDisplayUrl();
            ViewData["ogtitle"] = Post.Title;
            ViewData["ogdescription"] = Post.Title;
            ViewData["ogimage"] = Post.Image;
        }
    }
}
