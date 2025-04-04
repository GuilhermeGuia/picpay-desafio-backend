using System.Net;

namespace DesafioPicPay.Exception.ExceptionBase;

public class AccountAlreadyExistsException : DesafioPicPayException
{
    public AccountAlreadyExistsException() : base(ResourceMessageExceptions.ACCOUNT_EXISTS) { }
 
    public override IList<string> GetErrorMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}
