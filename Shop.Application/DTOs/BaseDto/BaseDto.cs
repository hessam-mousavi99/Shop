using System.ComponentModel.DataAnnotations;

namespace Shop.Application.DTOs.BaseDto
{
    public class BaseDto
    {
        public long Id { get; set; }
        [Display(Name = "حذف شده / نشده")]
        public bool IsDelete { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
