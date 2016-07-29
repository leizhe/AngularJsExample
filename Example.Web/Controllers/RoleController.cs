using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Example.Application.Dtos;
using Example.Application.ServiceContract;

namespace Example.Web.Controllers
{
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("api/role/GetAllRoles")]
        public OutputBase GetAllRoles()
        {
            PageInput input = new PageInput() { Current = 1, Size = 10 };
            return _roleService.GetRoles(input);
        }

        [HttpGet]
        [Route("api/role/GetRoles")]
        public OutputBase GetRoles([FromUri]PageInput input)
        {
            return _roleService.GetRoles(input);
        }
        [HttpGet]
        [Route("api/role/RoleInfo")]
        public OutputBase GetRoleInfo(int id)
        {
            return _roleService.GetRole(id);
        }

        [HttpPost]
        [ActionName("AddRole")]
        [Route("api/role/AddRole")]
        public OutputBase CreateRole([FromBody]RoleDto roleDto)
        {
            return _roleService.CreateRole(roleDto);
        }

        [HttpPost]
        [Route("api/role/UpdateRole")]
        public OutputBase UpdateRole([FromBody]RoleDto roleDto)
        {
            return _roleService.UpdateRole(roleDto);
        }

        [HttpPost]
        [Route("api/role/DeleteRole/{id}")]
        public OutputBase DeleteRole(int id)
        {
            return _roleService.DeleteRole(id);
        }
    }
}
