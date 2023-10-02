using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using _0_Framework.Apllication.Controllers;
using AccountManagment.Application.Contracts.Account;

namespace Tapooti.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("v{version:apiVersion}/[controller]")]
    public class AccountController : TapootiApiController
    {
        private readonly IAccountApplication _accountApplication;
        public AccountController(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        [NonAction]
        [HttpGet]
        [Route("GetUserInfoById")]
        public async Task<IActionResult> UserInfoById([FromQuery] string UserId)
        {
            var response = await _accountApplication.UserInfoByIdAsync(UserId);
            return TapootiObjectResult(response);
        }

        [NonAction]
        [HttpGet]
        [Route("GetUserInfoByUserName")]
        public async Task<IActionResult> UserInfoByUserName([FromQuery] string UserName)
        {
            var response = await _accountApplication.UserInfoByUserNameAsync(UserName);
            return TapootiObjectResult(response);
        }

        [HttpGet]
        [Authorize]
        [Route("GetAccounts")]
        public async Task<IActionResult> GetAccounts([FromQuery] AccountListRequest request)
        {
            var response = await _accountApplication.GetAccountsAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpGet]
        [Route("GetUserInfoByPhoneNumber")]
        public async Task<IActionResult> UserInfoByUserName([FromQuery] PhoneNumberRequest request)
        {
            var response = await _accountApplication.UserInfoByPhoneNumberAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpGet]
        [Authorize]
        [Route("SearchAccount")]
        public async Task<IActionResult> SearchAsync([FromQuery] AccountSearchModelRequest request)
        {
            var response = await _accountApplication.SearchAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpPost]
        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            var response = await _accountApplication.SignOutAsync();
            return TapootiObjectResult(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            var response = await _accountApplication.LoginAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var response = await _accountApplication.RegisterUserAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpPut]
        [Route("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountRequest request)
        {
            var response = await _accountApplication.UpdateAccountAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var response = await _accountApplication.ResetPasswordAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpPost]
        [Route("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest request)
        {
            var response = await _accountApplication.ForgetPasswordAsync(request);
            return TapootiObjectResult(response);
        }
        
        [HttpPost]
        [Route("ResendConfirmPhoneNumber")]
        public async Task<IActionResult> ResendConfirmPhoneNumber([FromBody] PhoneNumberRequest request)
        {
            var response = await _accountApplication.ResendConfirmPhoneNumberAsync(request);
            return TapootiObjectResult(response);
        }

        [HttpPost]
        [Route("ConfirmPhoneNumber")]
        public async Task<IActionResult> ConfirmPhoneNumber([FromBody] ConfirmPhoneNumberRequest request)
        {
            var response = await _accountApplication.ConfirmPhoneNumberAsync(request);
            return TapootiObjectResult(response);
        }
    }
}