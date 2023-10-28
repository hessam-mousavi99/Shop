namespace Shop.Web.Models.VM.Admin.Product
{
    public class EditCategoryVM:CreateCategoryVM
    {
        public long CategoryId { get; set; }
        public string ImageName { get; set; }= string.Empty;
    }
}
