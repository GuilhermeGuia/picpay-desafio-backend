using DesafioPicPay.Domain.Entities.Enums;

namespace DesafioPicPay.Application.Services.User.Dto;
public class CreateUserInput
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public EUserType UserType { get; set; } = EUserType.Usuario;
}
