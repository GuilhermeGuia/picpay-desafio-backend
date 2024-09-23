namespace DesafioPicPay.Exception.ExceptionBase;

public class ErrorOnValidationException : DesafioPicPayException
{
    public IList<string> ErrorMessages { get; set; }
    //public ErrorOnValidationException(string errorMessage)
    //{
    //    ErrorMessages = [errorMessage];
    //}
    public ErrorOnValidationException(IList<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
