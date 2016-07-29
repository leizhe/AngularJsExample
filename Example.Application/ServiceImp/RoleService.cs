using Example.Application.Dtos;
using Example.Application.ServiceContract;
using Example.Domain.Models;
using Example.Domain.Repositories;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Example.Application.ServiceImp
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public RoleService(IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository)
        {
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }
        public GetResult<RoleDto> GetRole(int roleId)
        {
            var result = GetDefault<GetResult<RoleDto>>();
            var model = _roleRepository.FindSingle(x => x.Id == roleId);

            result.Data = new RoleDto()
            {
                Id=model.Id,
                RoleName = model.RoleName,
                CreationTime = model.CreationTime
            };
            return result;
        }
        public GetResults<RoleDto> GetRoles(PageInput input)
        {
            var result = GetDefault<GetResults<RoleDto>>();
            var filterExp = BuildExpression(input);

            var query = _roleRepository.Find(filterExp, r => r.Id, SortOrder.Descending, input.Current, input.Size);

            //if (input.UserId > 0)
            //    query = query.Where(x => x.UserRoles.Any((z => z.UserId == input.UserId)));
            
            result.Total = _roleRepository.Find(filterExp).Count();
            result.Data = query.Select(roleDto => new RoleDto()
            {
                Id = roleDto.Id,
                RoleName = roleDto.RoleName,
                CreationTime=roleDto.CreationTime
               
            }).ToList();

            return result;
        }

        public CreateResult<int> CreateRole(RoleDto roleDto)
        {
            var result = GetDefault<CreateResult<int>>();
            if (IsExisted(roleDto.RoleName))
            {
                result.Message = "ROLE_NAME_HAS_EXIST";
                return result;
            }

            var role = new Role()
            {
                RoleName = roleDto.RoleName,
                CreationTime = DateTime.Now
            };


            _roleRepository.Add(role);
            _roleRepository.Commit();
            result.Id = role.Id;
            result.IsCreated = true;
            return result;
        }

        public UpdateResult UpdateRole(RoleDto roleDto)
        {
            var result = GetDefault<UpdateResult>();
            var role = _roleRepository.FindSingle(r => r.Id == roleDto.Id);
            if (role == null)
            {
                result.Message = "ROLE_NOT_EXIST";
                return result;
            }

           
            role.RoleName = roleDto.RoleName;
            _roleRepository.Update(role);
            _roleRepository.Commit();
            result.IsSaved = true;
            return result;
        }

        public DeleteResult DeleteRole(int roleId)
        {
            var result = GetDefault<DeleteResult>();
            var role = _roleRepository.FindSingle(r => r.Id == roleId);
            if (role != null)
            {
                _roleRepository.Delete(role);
            }

            _roleRepository.Commit();
            result.IsDeleted = true;
            return result;
        }

        private bool IsExisted(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && _roleRepository.Find(x => x.RoleName == name).Any();
        }

        private Expression<Func<Role, bool>> BuildExpression(PageInput input)
        {
            Expression<Func<Role, bool>> filterExp = x => true;
            if (!string.IsNullOrWhiteSpace(input.Name))
                filterExp = (x => x.RoleName.Contains(input.Name));

            return filterExp;
        }
    }
}
