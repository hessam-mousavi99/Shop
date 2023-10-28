namespace Shop.Application.DTOs.Admin.Product
{
    public class EditCategoryDto:CreateCategoryDto
    {
        public long CategoryId { get; set; }
        public string ImageName { get; set; } = string.Empty;
    }
}
