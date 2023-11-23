using AutoMapper;
using LinkShortener.Data.Entities;
using LinkShortener.Presentation.Models;

namespace LinkShortener.Presentation;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UrlViewModel, Url>();
    }
}