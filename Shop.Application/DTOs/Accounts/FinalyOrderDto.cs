namespace Shop.Application.DTOs.Accounts
{
    public class FinalyOrderDto
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }

        public bool IsWallet { get; set; }
    }
}
