using System.Net;

namespace DesafioPicPay.Exception.ExceptionBase;

public abstract class DesafioPicPayException : SystemException
{
    public DesafioPicPayException(string message) : base(message) { }
    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessages();
}
