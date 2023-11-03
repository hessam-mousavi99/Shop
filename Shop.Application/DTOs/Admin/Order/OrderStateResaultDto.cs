namespace Shop.Application.DTOs.Admin.Order
{
    public class OrderStateResaultDto
    {
        public int RequestCount { get; set; }
        public int ProcessingCount { get; set; }
        public int SentCount { get; set; }
        public int CancelCount { get; set; }
    }
}
