using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.Dtos
{
    public class RoleDto : BaseEntityDto
    {
        public string RoleName { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
