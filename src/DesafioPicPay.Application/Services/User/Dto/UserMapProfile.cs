using AutoMapper;

namespace DesafioPicPay.Application.Services.User.Dto;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<CreateUserInput, Domain.Entities.User>();
        CreateMap<UserOutput, Domain.Entities.User>().ReverseMap();
    }
}
