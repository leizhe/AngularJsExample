using System.Collections;
using System.Collections.Generic;

namespace Example.Domain.Model
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }
    }
}