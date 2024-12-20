
using AutoMapper;
using Domain.User;

namespace Application.Features.User.UpdateUser;

internal sealed class UpdateUserProfile : Profile 
{
    public UpdateUserProfile()
    {
        CreateMap<UserAd, UpdateUserCommand>()
            .ReverseMap();

        CreateMap<UserAd, UpdateUserResponse>()
            .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name.Value))
            .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email.Value))
            .ReverseMap();
    }
}
