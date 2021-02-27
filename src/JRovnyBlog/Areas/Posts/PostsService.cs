namespace JRovnyBlog.Areas.Posts
{
    public class PostsService
    {
        private readonly ApplicationDbContext _context;

        public PostsService(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}