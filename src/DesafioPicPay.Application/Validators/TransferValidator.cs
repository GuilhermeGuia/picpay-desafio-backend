using DesafioPicPay.Application.Services.Transfer.Dto;
using DesafioPicPay.Application.Validators.Base;
using DesafioPicPay.Exception;
using DesafioPicPay.Exception.ExceptionBase;

namespace DesafioPicPay.Application.Validators;

public class TransferValidator : Validator
{
    public void SendTransferValidation(Domain.Entities.User sender, TransferInput input)
    {
        if (sender.Balance < input.Value)
            AddErros(ResourceMessageExceptions.INSUFFICIENT_BALANCE);

        ThrowIfInvalid<ErrorOnValidationException>();
    }
}   
