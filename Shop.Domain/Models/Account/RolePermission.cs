using Shop.Domain.Models.BaseEntities;

namespace Shop.Domain.Models.Account
{
    public class RolePermission:BaseEntity
    {
        #region properties
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        #endregion

        #region relations
        public virtual Role? Role { get; set; }
        public virtual Permission? Permission { get; set; }
        #endregion
    }
}
