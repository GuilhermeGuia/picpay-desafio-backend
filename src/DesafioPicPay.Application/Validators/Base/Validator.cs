
using DesafioPicPay.Exception.ExceptionBase;
namespace DesafioPicPay.Application.Validators.Base;

public abstract class Validator
{
    private readonly List<string> _errors = [];
    public IReadOnlyCollection<string> Errors => _errors;
    protected void AddErros(string error)
    {
        _errors.Add(error);
    }
    public bool IsValid() => _errors.Count == 0;

    public void ThrowIfInvalid<TException>() where TException : DesafioPicPayException
    {
        if (!IsValid())
            throw (TException)Activator.CreateInstance(typeof(TException), _errors)!;
    }
}
