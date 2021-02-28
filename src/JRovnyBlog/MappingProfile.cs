using AutoMapper;

namespace JRovnyBlog
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Post, Areas.Posts.PostSummary>();
            CreateMap<Models.Post, Areas.Posts.Models.PostDetail>();
        }
    }
}