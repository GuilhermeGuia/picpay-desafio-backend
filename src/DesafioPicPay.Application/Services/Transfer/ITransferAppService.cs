using DesafioPicPay.Application.Services.Transfer.Dto;

namespace DesafioPicPay.Application.Services.Transfer;

public interface ITransferAppService
{
    Task<Guid> Transfer(TransferInput input);
}
