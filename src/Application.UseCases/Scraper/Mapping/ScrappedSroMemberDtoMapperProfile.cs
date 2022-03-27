using AutoMapper;
using SroParser.Application.UseCases.Scraper.Dto;
using SroParser.Application.UseCases.SroMember.Dto;

namespace SroParser.Application.UseCases.Scraper.Mapping;

public class ScrappedSroMemberDtoMapperProfile : Profile
{
    public ScrappedSroMemberDtoMapperProfile()
    {
        CreateMap<ScrappedSroMemberDto, SroMemberDto>();
    }
}