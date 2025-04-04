using System.Net;

namespace DesafioPicPay.Exception.ExceptionBase;

public class AccountAlreadyExistsException : DesafioPicPayException
{
    public AccountAlreadyExistsException() : base(string.Empty) { }
 
    public override IList<string> GetErrorMessages() => [ResourceMessageExceptions.ACCOUNT_EXISTS];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}
