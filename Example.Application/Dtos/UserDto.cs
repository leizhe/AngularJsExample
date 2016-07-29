using System;
using System.Collections.Generic;

namespace Example.Application.Dtos
{
    public class UserDto : BaseEntityDto
    {
        public string Name { get; set; }
        
        public string RealName { get; set; }
        public string Email { get; set; }

        public int State { get; set; }
        public DateTime CreateTime { get; set; }
        public List<RoleDto> Roles { get; set; }
        public int TotalRole { get; set; }
    }
}
