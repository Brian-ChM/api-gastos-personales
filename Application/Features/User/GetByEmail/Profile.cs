using Application.Features.User.GetByName;
using AutoMapper;
using Domain.User.Queries.Response;

namespace Application.Features.User.GetByEmail;

internal sealed class GetUserByEmailProfile : Profile
{
    public GetUserByEmailProfile()
    {
        CreateMap<GetUserByEmailQueryResponse, GetUserByEmailResponse>()
            .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
            .ReverseMap();
    }
}
