using Application.Features.User.Login;
using Application.Features.User.Register;
using Application.Features.User.UpdatePassword;
using Application.Features.User.UpdateUser;
using AutoMapper;
using WebApi.Features.User.Requests;

namespace WebApi.Features.User;

public class UsersAdControllerProfile : Profile
{
    public UsersAdControllerProfile()
    {
        CreateMap<RegisterUserRequest, RegisterUserCommand>()
            .ReverseMap();

        CreateMap<UpdatePasswordUserRequest, UpdatePasswordCommand>()
            .ReverseMap();

        CreateMap<LoginRequest, LoginCommand>()
            .ReverseMap();

        CreateMap<UpdateUserRequest, UpdateUserCommand>()
           .ReverseMap();

        CreateMap<LoginRequest, LoginCommand>()
            .ReverseMap();
    }
}
