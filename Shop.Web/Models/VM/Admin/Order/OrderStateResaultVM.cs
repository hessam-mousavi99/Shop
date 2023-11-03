namespace Shop.Web.Models.VM.Admin.Order
{
    public class OrderStateResaultVM
    {
        public int RequestCount { get; set; }
        public int ProcessingCount { get; set; }
        public int SentCount { get; set; }
        public int CancelCount { get; set; }
    }
}
