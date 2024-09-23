namespace DesafioPicPay.Application.Validators;

public interface IValidator<T>
{
    List<string> Errors { get; set; }
    void Validate(T input);
    void Execute(T input);
}
