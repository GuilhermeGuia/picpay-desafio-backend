using System.Net;

namespace DesafioPicPay.Exception.ExceptionBase;

public class InvalidLoginException : DesafioPicPayException
{
    public InvalidLoginException() : base(string.Empty) { }

    public override IList<string> GetErrorMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
}
