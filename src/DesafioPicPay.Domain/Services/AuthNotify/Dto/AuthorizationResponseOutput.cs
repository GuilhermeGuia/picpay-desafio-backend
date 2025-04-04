namespace DesafioPicPay.Domain.Services.AuthNotify.Dto;

public class AuthorizationResponseOutput
{
    public string Status { get; set; } = string.Empty;
    public AuthData Data { get; set; }
}

public class AuthData
{
    public bool Authorization { get; set; }
}
