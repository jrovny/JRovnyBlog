using Microsoft.AspNetCore.Mvc;

namespace JRovnyBlog.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Models.Comment comment)
        {
            return View(comment);
        }
    }
}