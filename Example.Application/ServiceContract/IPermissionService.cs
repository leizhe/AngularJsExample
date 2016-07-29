using Example.Application.Dtos;

namespace Example.Application.ServiceContract
{
    public interface IPermissionService
    {
        GetResults<PermissionDto> GetPermissions(PageInput input);

        UpdateResult UpdatePermission(PermissionDto action);

        CreateResult<int> CreatePermission(PermissionDto action);

        DeleteResult DeletePermission(int actionId);
    }
}