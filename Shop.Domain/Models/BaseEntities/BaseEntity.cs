using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Models.BaseEntities
{
    public abstract class BaseEntity
    {
        #region Properties
        [Key]
        public long Id { get; set; }
        [Display(Name = "حذف شده / نشده")]
        public bool IsDelete { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        #endregion
    }
}
