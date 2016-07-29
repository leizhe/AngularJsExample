using Example.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.ServiceContract
{
    public interface IUserService
    {
        GetResults<UserDto> GetUsers(PageInput input);

        UpdateResult UpdateUser(UserDto user);

        CreateResult<int> AddUser(UserDto user);

        DeleteResult DeleteUser(int userId);
        
        GetResult<UserDto> GetUser(int userId);

        UpdateResult UpdateRoles(UserDto user);

        DeleteResult DeleteRole(int userId, int roleId);

        bool Exist(string username, string password);

    }
}
