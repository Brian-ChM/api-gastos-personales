using AutoMapper;
using Domain.User;

namespace Application.Features.User.Register;

internal sealed class RegisterUserHandlerProfile : Profile
{
    public RegisterUserHandlerProfile()
    {
        CreateMap<UserAd, RegisterUserResponse>()
            .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name.Value))
            .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email.Value));
    }
}
