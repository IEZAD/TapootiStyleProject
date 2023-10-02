using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using _0_Framework.Apllication.Controllers;
using AccountManagment.Application.Contracts.Role;

namespace Tapooti.API.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("v{version:apiVersion}/[controller]")]
    public class RoleController : TapootiApiController
    {
        private readonly IRoleApplication _roleApplication;

        public RoleController(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        [HttpGet]
        [Route("GetListRole")]
        public async Task<IActionResult> GetListRole()
        {
            var response = await _roleApplication.ListAsync();
            return TapootiObjectResult(response);
        }

        [HttpGet]
        [Route("GetDetailsRole")]
        public async Task<IActionResult> GetDetailsRole([FromQuery] string roleId)
        {
            var response = await _roleApplication.GetDetailsAsync(roleId);
            return TapootiObjectResult(response);
        }

        [HttpPut]
        [Route("UpdateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] EditRole request)
        {
            var response = await _roleApplication.UpdateAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRole request)
        {
            var response = await _roleApplication.CreateAsync(request);
            return TapootiObjectResult(response);
        }
    }
}
