using System.Threading.Tasks;
using JRovnyBlog.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JRovnyBlog.Pages.Posts
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Slug { get; set; }
        private readonly IPostsService _postsService;
        public Models.PostDetail Post;
        public HtmlString PostContent;
        public IndexModel(IPostsService postsService)
        {
            _postsService = postsService;
        }

        public async Task OnGetAsync()
        {
            Post = await _postsService.GetBySlugAsync(Slug);
            PostContent = new HtmlString(Post.Content);
        }
    }
}
