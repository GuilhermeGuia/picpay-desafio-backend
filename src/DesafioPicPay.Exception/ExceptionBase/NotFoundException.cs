using System.Net;

namespace DesafioPicPay.Exception.ExceptionBase;

public class NotFoundException : DesafioPicPayException
{
    public NotFoundException(string message) : base(message) { }
    public override IList<string> GetErrorMessages() => [Message];
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
}
