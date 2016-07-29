
using System;
using System.Collections.Generic;

namespace Example.Domain.Models
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string RealName { get; set; }
        public DateTime CreationTime { get; set; }

        public int State { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public User()
        {
            this.UserRoles = new List<UserRole>();
        }

    }
}
