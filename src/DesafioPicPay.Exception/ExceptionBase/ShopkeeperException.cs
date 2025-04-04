using System.Net;

namespace DesafioPicPay.Exception.ExceptionBase;

public class ShopkeeperException : DesafioPicPayException
{
    public ShopkeeperException() : base(ResourceMessageExceptions.SHOPKEEPER_TRANSACTION) { }
    public override IList<string> GetErrorMessages() => [Message];
    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}
