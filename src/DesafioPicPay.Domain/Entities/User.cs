using DesafioPicPay.Domain.Entities.Enums;
using RecipeFood.Domain.Entities;

namespace DesafioPicPay.Domain.Entities;

public class User : EntityBase
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public EUserType UserType { get; set; }
}