using AutoMapper;
using SroParser.Application.UseCases.SroMember.Dto;

namespace SroParser.Application.UseCases.SroMember.Mapping;

public class SroMemberMapperProfile : Profile
{
    public SroMemberMapperProfile()
    {
        CreateMap<SroMemberDto, Domain.Entities.SroMember>();
    }
}