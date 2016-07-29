using Example.Application.Dtos;

namespace Example.Application.ServiceContract
{
    public interface IRoleService
    {
        GetResult<RoleDto> GetRole(int roleId);
        GetResults<RoleDto> GetRoles(PageInput input);

        CreateResult<int> CreateRole(RoleDto role);

        UpdateResult UpdateRole(RoleDto role);

        DeleteResult DeleteRole(int roleId);
    }
}
