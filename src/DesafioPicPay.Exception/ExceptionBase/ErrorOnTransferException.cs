using System.Net;

namespace DesafioPicPay.Exception.ExceptionBase;

public class ErrorOnTransferException : DesafioPicPayException
{
    public ErrorOnTransferException() : base(ResourceMessageExceptions.FAILED_TRANSFER){}
    public override IList<string> GetErrorMessages() => [Message];
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}
