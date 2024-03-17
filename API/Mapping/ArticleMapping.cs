using AutoMapper;
using Data.Entities;
using WebApp.Models; // Make sure to adjust namespaces as per your project structure

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Articles, ArticleViewModel>().ReverseMap();
        CreateMap<ArticleDescriptions, ArticleDescriptionsViewModel>().ReverseMap();
    }
}
