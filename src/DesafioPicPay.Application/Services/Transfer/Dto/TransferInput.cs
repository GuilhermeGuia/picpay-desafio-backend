namespace DesafioPicPay.Application.Services.Transfer.Dto;

public class TransferInput
{
    public long Value { get; set; }
    public long SenderId { get; set; }
    public long ReceiverId { get; set; }
}
