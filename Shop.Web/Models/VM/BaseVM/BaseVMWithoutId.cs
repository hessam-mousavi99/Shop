using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Models.VM.BaseVM
{
    public class BaseVMWithoutId
    {
        [Display(Name = "حذف شده / نشده")]
        public bool IsDelete { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
