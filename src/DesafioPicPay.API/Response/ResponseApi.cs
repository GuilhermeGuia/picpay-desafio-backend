namespace DesafioPicPay.API.Response;

public class ResponseApi<T>
{
    public T? Result { get; set; }
    public bool Success { get; set; }
    public IList<string>? Errors { get; set; }
    public ResponseApi(T result)
    {
        Success = true;
        Result = result;
    }
    public ResponseApi(IList<string> errors)
    {
        Errors = errors;
        Success = false;
    }
}