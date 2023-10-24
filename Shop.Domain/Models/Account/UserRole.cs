using Shop.Domain.Models.BaseEntities;

namespace Shop.Domain.Models.Account
{
    public class UserRole:BaseEntity
    {
        #region properties
        public long UserId { get; set; }
        public long RoleId { get; set; }
        #endregion

        #region relations
        public virtual User? User { get; set; }
        public virtual Role? Role { get; set; }
        #endregion
    }
}
