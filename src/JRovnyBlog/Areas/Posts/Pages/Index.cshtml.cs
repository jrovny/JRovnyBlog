using System.Collections.Generic;
using System.Threading.Tasks;
using JRovnyBlog.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JRovnyBlog.Areas.Posts.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Post> Posts;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            this.Posts = await _context.Posts.AsNoTracking().ToListAsync();
        }
    }
}
