using System.Net;

namespace DesafioPicPay.Exception.ExceptionBase;

public class ErrorOnValidationException : DesafioPicPayException
{
    private readonly IList<string> _errorMessages;
    public ErrorOnValidationException(IList<string> errorMessages) : base(string.Empty)
    {
        _errorMessages = errorMessages;
    }
    public ErrorOnValidationException(string errorMessage) : base(string.Empty)
    {
        _errorMessages = [errorMessage];
    }

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    public override IList<string> GetErrorMessages() => _errorMessages;
}
