
using Example.Domain.Model;
using System;
using System.Collections.Generic;

namespace Example.Domain.Models
{
    public class Role: BaseEntity
    {
        public string RoleName { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        public Role()
        {
           
            UserRoles = new HashSet<UserRole>();
            RolePermissions = new HashSet<RolePermission>();
        }
    }
}
