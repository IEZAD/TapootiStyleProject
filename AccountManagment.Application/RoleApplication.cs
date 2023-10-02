using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AccountManagment.Domain.RoleAgg;
using _0_Framework.Apllication.Logger;
using _0_Framework.Apllication.Resources;
using _0_Framework.Apllication.Apllication;
using AccountManagment.Domain.PermissionAgg;
using _0_Framework.Infrastructure.Permission;
using AccountManagment.Application.Contracts.Role;
using _0_Framework.Apllication.Messaging.ApiWrapper;

namespace AccountManagment.Application
{
    public class RoleApplication : TapootiApllication, IRoleApplication
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private RoleManager<Role> _roleManager;

        public RoleApplication(ILogger logger,
                               IMapper mapper,
                               RoleManager<Role> roleManager) : base(logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        #region IRoleApplicationMethod
        //Test Done :)
        public async Task<ApiWrapperResponse> UpdateAsync(EditRole command)
        {
            try
            {
                command.MappedPermissions = null;
                var role = await _roleManager.FindByIdAsync(command.Id);

                if (role is null)
                    return new ApiWrapperResponse(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                if (await _roleManager.RoleExistsAsync(command.Name))
                    return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.DuplicatedRecord);

                List<Permission> permissions = new List<Permission>();
                command.Permissions.ForEach(x => permissions.Add(new Permission(x)));

                role.Update(command.Name, permissions);
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                    return new ApiWrapperResponse(false, HttpStatusCode.OK, ApplicationMessages.Successed);

                return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.Failed);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex);
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse> CreateAsync(CreateRole command)
        {
            try
            {
                if (await _roleManager.RoleExistsAsync(command.Name))
                    return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.DuplicatedRecord);

                Role role = new Role(command.Name, new List<Permission>());

                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                    return new ApiWrapperResponse(false, HttpStatusCode.OK, ApplicationMessages.Successed);

                return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.Failed);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex);
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<List<RoleViewModel>>> ListAsync()
        {
            try
            {
                var result = await _roleManager.Roles.Select(x => new RoleViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreationDate = string.Empty,//x.CreationDate.ToFarsi(),
                }).ToListAsync();

                return new ApiWrapperResponse<List<RoleViewModel>>(result);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new List<RoleViewModel>());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<EditRole>> GetDetailsAsync(string id)
        {
            try
            {
                id = id.Trim();
                if (string.IsNullOrEmpty(id))
                    return new ApiWrapperResponse<EditRole>(true, HttpStatusCode.BadRequest, ApplicationMessages.Failed);

                var role = _roleManager.Roles.Select(x => new EditRole()
                {
                    Id = x.Id,
                    Name = x.Name,
                    MappedPermissions = MapPermissions(x.Permissions),
                }).AsNoTracking().FirstOrDefault(x => x.Id == id);

                role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();

                if (role is null)
                    return new ApiWrapperResponse<EditRole>(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                return new ApiWrapperResponse<EditRole>(role);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new EditRole());
            }
        }
        #endregion

        #region OutherHelperMethod
        private static List<PermissionDto> MapPermissions(List<Permission> permissions)
        {
            try
            {
                return permissions.Select(x => new PermissionDto(x.Code, x.Name)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        #endregion 
    }
}