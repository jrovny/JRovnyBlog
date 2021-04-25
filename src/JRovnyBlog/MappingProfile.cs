using AutoMapper;

namespace JRovnyBlog
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Models.Post, Models.PostSummary>();
            CreateMap<Data.Models.Post, Models.PostDetail>();
            CreateMap<Data.Models.Comment, Models.Comment>();
        }
    }
}