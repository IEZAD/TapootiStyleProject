using System.Net;
using AutoMapper;
using System.Text;
using System.Data;
using System.Text.Json;
using System.Security.Claims;
using System.Linq.Expressions;
using _0_Framework.Apllication.SMS;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using _0_Framework.Domain.Pagination;
using _0_Framework.Apllication.Logger;
using System.IdentityModel.Tokens.Jwt;
using AccountManagment.Domain.RoleAgg;
using AccountManagment.Domain.AccountAgg;
using _0_Framework.Apllication.Utilities;
using _0_Framework.Apllication.Resources;
using Microsoft.Extensions.Configuration;
using _0_Framework.Apllication.Pagination;
using _0_Framework.Apllication.Apllication;
using _0_Framework.Apllication.Messaging.ApiWrapper;
using AccountManagment.Application.Contracts.Account;

namespace AccountManagment.Application
{
    public class AccountApplication : TapootiApllication, IAccountApplication
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ISMSService _SMSService;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public AccountApplication(ILogger logger,
                                  IMapper mapper,
                                  ISMSService SMSService,
                                  IConfiguration configuration,
                                  RoleManager<Role> roleManager,
                                  UserManager<Account> userManager,
                                  SignInManager<Account> signInManager) : base(logger, mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _SMSService = SMSService;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        #region IAccountApplicationMethod
        //Test Done :)
        public async Task<ApiWrapperResponse> SignOutAsync()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return new ApiWrapperResponse(false, HttpStatusCode.OK, ApplicationMessages.Successed);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex);
            }
        }

        public Task<ApiWrapperResponse<dynamic>> ResendConfirmEmailAddress(string email)
        {
            throw new NotImplementedException();
        }


        public Task<ApiWrapperResponse<dynamic>> ConfirmEmailAddress(Guid userId, string code)
        {
            throw new NotImplementedException();
        }

        //Test Done :)
        public async Task<ApiWrapperResponse> UpdateAccountAsync(UpdateAccountRequest request)
        {
            try
            {
                if (!string.IsNullOrEmpty(request.Id))
                    request.Id = request.Id.Trim();
                if (!string.IsNullOrEmpty(request.UserName))
                    request.UserName = request.UserName.ReplaceArabicCharacters().Trim();
                if (!string.IsNullOrEmpty(request.CountryCode))
                    request.CountryCode = request.CountryCode.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();
                if (!string.IsNullOrEmpty(request.PhoneNumber))
                    request.PhoneNumber = request.PhoneNumber.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();

                var user = await _userManager.FindByIdAsync(request.Id);
                if (user is null)
                    return new ApiWrapperResponse(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                if (!user.PhoneNumberConfirmed)
                    return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.PhoneNumberNotConfirm);

                user.Update(request.UserName, request.CountryCode, request.PhoneNumber);
                var result = await _userManager.UpdateAsync(user);
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
        public async Task<ApiWrapperResponse> ResetPasswordAsync(ResetPasswordRequest request)
        {
            try
            {
                request.Password = request.Password.Trim();
                request.Code = request.Code.RemoveZeroAndPlusFromTheFrist().Trim();
                request.CountryCode = request.CountryCode.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();
                request.PhoneNumber = request.PhoneNumber.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();

                var user = await FindByPhoneNumber(request.CountryCode, request.PhoneNumber);

                if (user is null)
                    return new ApiWrapperResponse(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                if (!user.PhoneNumberConfirmed)
                    return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.PhoneNumberNotConfirm);

                var result = await _userManager.ResetPasswordAsync(user, request.Code, request.Password);
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
        public async Task<ApiWrapperResponse> ForgetPasswordAsync(ForgetPasswordRequest request)
        {
            try
            {
                request.CountryCode = request.CountryCode.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();
                request.PhoneNumber = request.PhoneNumber.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();

                var user = await FindByPhoneNumber(request.CountryCode, request.PhoneNumber);

                if (user is null)
                    return new ApiWrapperResponse(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                if (!user.PhoneNumberConfirmed)
                    return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.PhoneNumberNotConfirm);

                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var sendResult = await _SMSService.SendLookUpForgetPasswordSMS(new(request.CountryCode + request.PhoneNumber, token));

                return new ApiWrapperResponse(false, HttpStatusCode.OK, new List<string> { ApplicationMessages.Successed, sendResult.Message });
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex);
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<LoginUserResponse>> LoginAsync(LoginUserRequest request)
        {
            try
            {
                request.UserName = request.UserName.Trim();
                request.Password = request.Password.Trim();

                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user is null)
                    return new ApiWrapperResponse<LoginUserResponse>(true, HttpStatusCode.NotFound, ApplicationMessages.UserNotRegister);

                if (!user.PhoneNumberConfirmed)
                    return new ApiWrapperResponse<LoginUserResponse>(true, HttpStatusCode.Unauthorized, ApplicationMessages.PhoneNumberNotConfirm);

                if (!await _userManager.CheckPasswordAsync(user, request.Password))
                    return new ApiWrapperResponse<LoginUserResponse>(true, HttpStatusCode.BadRequest, ApplicationMessages.InValidUserNamePassword);

                await _signInManager.SignOutAsync();

                var result = await _signInManager.PasswordSignInAsync(user: user, password: request.Password, isPersistent: request.IsPersistent, lockoutOnFailure: true);

                if (result.IsLockedOut)
                    return new ApiWrapperResponse<LoginUserResponse>(true, HttpStatusCode.BadRequest, ApplicationMessages.IsLockedOut);

                if (result.IsNotAllowed)
                    return new ApiWrapperResponse<LoginUserResponse>(true, HttpStatusCode.BadRequest, ApplicationMessages.IsNotAllowed);

                if (!result.Succeeded)
                    return new ApiWrapperResponse<LoginUserResponse>(true, HttpStatusCode.BadRequest, ApplicationMessages.Failed);

                var permissions = GetAllPermissions(user);
                AuthViewModelCommand authViewModel = new(user.Id, user.RoleId, user.UserName, user.CountryCode, user.PhoneNumber, permissions);
                var token = await GenerateToken(authViewModel);

                LoginUserResponse entity = new()
                {
                    Id = user.Id,
                    Token = token,
                    UserName = user.UserName,
                    CountryCode = user.CountryCode,
                    PhoneNumber = user.PhoneNumber,
                };

                return new ApiWrapperResponse<LoginUserResponse>(entity);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new LoginUserResponse());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse> ResendConfirmPhoneNumberAsync(PhoneNumberRequest request)
        {
            try
            {
                request.CountryCode = request.CountryCode.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();
                request.PhoneNumber = request.PhoneNumber.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();

                var user = await FindByPhoneNumber(request.CountryCode, request.PhoneNumber);

                if (user is null)
                    return new ApiWrapperResponse(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                if (user.PhoneNumberConfirmed)
                    return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.PhoneNumberConfirmBefore);

                var token = await _userManager.GenerateChangePhoneNumberTokenAsync(user, request.PhoneNumber);
                var sendResult = await _SMSService.SendLookUpVerifySMS(new(request.CountryCode + request.PhoneNumber, token));

                return new ApiWrapperResponse(false, HttpStatusCode.OK, new List<string> { ApplicationMessages.Successed, sendResult.Message });
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex);
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse> ConfirmPhoneNumberAsync(ConfirmPhoneNumberRequest request)
        {
            try
            {
                request.ConfirmCode = request.ConfirmCode.ToNumbers<string>().Trim();
                request.CountryCode = request.CountryCode.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();
                request.PhoneNumber = request.PhoneNumber.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();

                var user = await FindByPhoneNumber(request.CountryCode, request.PhoneNumber);

                if (user is null)
                    return new ApiWrapperResponse(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                if (user.PhoneNumberConfirmed)
                    return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.PhoneNumberConfirmBefore);

                var result = await _userManager.VerifyChangePhoneNumberTokenAsync(user, request.ConfirmCode, request.PhoneNumber);

                if (result is false)
                    return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.UserNotRegister);

                user.PhoneNumberConfirmed = true;
                var updateUser = await _userManager.UpdateAsync(user);
                if (updateUser.Succeeded)
                    return new ApiWrapperResponse(false, HttpStatusCode.OK, new List<string>() { ApplicationMessages.Successed, ApplicationMessages.PhoneNumberConfirm });

                return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.Failed);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex);
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse> UpdateAccountAdminAsync(UpdateAccountAdminRequest request)
        {
            try
            {
                if (!string.IsNullOrEmpty(request.Id))
                    request.Id = request.Id.Trim();
                if (!string.IsNullOrEmpty(request.RoleId))
                    request.RoleId = request.RoleId.Trim();
                if (!string.IsNullOrEmpty(request.UserName))
                    request.UserName = request.UserName.ReplaceArabicCharacters().Trim();
                if (!string.IsNullOrEmpty(request.CountryCode))
                    request.CountryCode = request.CountryCode.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();
                if (!string.IsNullOrEmpty(request.PhoneNumber))
                    request.PhoneNumber = request.PhoneNumber.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();

                var user = await _userManager.FindByIdAsync(request.Id);
                if (user is null)
                    return new ApiWrapperResponse(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                if (!user.PhoneNumberConfirmed)
                    return new ApiWrapperResponse(true, HttpStatusCode.BadRequest, ApplicationMessages.PhoneNumberNotConfirm);

                user.Update(request.RoleId, request.UserName, request.CountryCode, request.PhoneNumber);
                var result = await _userManager.UpdateAsync(user);
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
        public async Task<ApiWrapperResponse<AccountViewModelResponse>> UserInfoByIdAsync(string request)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request);

                if (user is null)
                    return new ApiWrapperResponse<AccountViewModelResponse>(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                if (!user.PhoneNumberConfirmed)
                    return new ApiWrapperResponse<AccountViewModelResponse>(true, HttpStatusCode.BadRequest, ApplicationMessages.PhoneNumberNotConfirm);

                AccountViewModelResponse entity = new()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    CountryCode = user.CountryCode,
                    PhoneNumber = user.PhoneNumber,
                };

                return new ApiWrapperResponse<AccountViewModelResponse>(entity);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new AccountViewModelResponse());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<AccountViewModelResponse>> UserInfoByUserNameAsync(string request)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request);

                if (user is null)
                    return new ApiWrapperResponse<AccountViewModelResponse>(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);


                if (!user.PhoneNumberConfirmed)
                    return new ApiWrapperResponse<AccountViewModelResponse>(true, HttpStatusCode.BadRequest, ApplicationMessages.PhoneNumberNotConfirm);

                AccountViewModelResponse entity = new()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    CountryCode = user.CountryCode,
                    PhoneNumber = user.PhoneNumber,
                };

                return new ApiWrapperResponse<AccountViewModelResponse>(entity);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new AccountViewModelResponse());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<AccountViewModelResponse>> RegisterUserAsync(RegisterUserRequest request)
        {
            try
            {
                request.Password = request.Password.Trim();
                request.UserName = request.UserName.ReplaceArabicCharacters().Trim();
                request.CountryCode = request.CountryCode.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();
                request.PhoneNumber = request.PhoneNumber.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();

                if (await CheckIfUsernameIsDuplicated(request.UserName) || await Exists(x => x.CountryCode == request.CountryCode && x.PhoneNumber == request.PhoneNumber))
                    return new ApiWrapperResponse<AccountViewModelResponse>(true, HttpStatusCode.BadRequest, ApplicationMessages.DuplicatedRecord);

                Role role = await _roleManager.FindByNameAsync(DefaultRoles.User);
                Account account = new Account(role?.Id, request.CountryCode, request.PhoneNumber, request.UserName);

                var result = await _userManager.CreateAsync(account, request.Password);

                if (!result.Succeeded)
                    return new ApiWrapperResponse<AccountViewModelResponse>(true, HttpStatusCode.BadRequest, result.Errors.ToString());

                var user = await FindByPhoneNumber(request.CountryCode, request.PhoneNumber);
                var token = await _userManager.GenerateChangePhoneNumberTokenAsync(user, request.PhoneNumber);
                var sendResult = await _SMSService.SendLookUpVerifySMS(new(request.CountryCode + request.PhoneNumber, token));

                AccountViewModelResponse entity = new()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    CountryCode = user.CountryCode,
                    PhoneNumber = user.PhoneNumber,
                };

                return new ApiWrapperResponse<AccountViewModelResponse>(entity, false, HttpStatusCode.Created, new List<string> { ApplicationMessages.Successed, sendResult.Message });
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new AccountViewModelResponse());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<AccountViewModelResponse>> RegisterAdminAsync(RegisterAdminRequest request)
        {
            try
            {
                request.Password = request.Password.Trim();
                request.UserName = request.UserName.ReplaceArabicCharacters().Trim();
                request.CountryCode = request.CountryCode.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();
                request.PhoneNumber = request.PhoneNumber.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();

                if (await CheckIfUsernameIsDuplicated(request.UserName) || await Exists(x => x.CountryCode == request.CountryCode && x.PhoneNumber == request.PhoneNumber))
                    return new ApiWrapperResponse<AccountViewModelResponse>(true, HttpStatusCode.BadRequest, ApplicationMessages.DuplicatedRecord);

                Role role = await _roleManager.FindByNameAsync(DefaultRoles.Admin);
                Account account = new Account(role?.Id, request.CountryCode, request.PhoneNumber, request.UserName);
                var result = await _userManager.CreateAsync(account, request.Password);

                if (!result.Succeeded)
                    return new ApiWrapperResponse<AccountViewModelResponse>(true, HttpStatusCode.BadRequest, result.Errors.ToString());

                var user = await FindByPhoneNumber(request.CountryCode, request.PhoneNumber);
                var token = await _userManager.GenerateChangePhoneNumberTokenAsync(user, request.PhoneNumber);
                var sendResult = await _SMSService.SendLookUpVerifySMS(new(request.CountryCode + request.PhoneNumber, token));

                AccountViewModelResponse entity = new()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    CountryCode = user.CountryCode,
                    PhoneNumber = user.PhoneNumber,
                };

                return new ApiWrapperResponse<AccountViewModelResponse>(entity, false, HttpStatusCode.Created, new List<string> { ApplicationMessages.Successed, sendResult.Message });
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new AccountViewModelResponse());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<AccountViewModelResponse>> UserInfoByPhoneNumberAsync(PhoneNumberRequest request)
        {
            try
            {
                request.CountryCode = request.CountryCode.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();
                request.PhoneNumber = request.PhoneNumber.RemoveZeroAndPlusFromTheFrist().ToNumbers<string>().Trim();

                var user = await FindByPhoneNumber(request.CountryCode, request.PhoneNumber);

                if (user is null)
                    return new ApiWrapperResponse<AccountViewModelResponse>(true, HttpStatusCode.NotFound, ApplicationMessages.RecordNotFound);

                if (!user.PhoneNumberConfirmed)
                    return new ApiWrapperResponse<AccountViewModelResponse>(true, HttpStatusCode.BadRequest, ApplicationMessages.PhoneNumberNotConfirm);

                AccountViewModelResponse entity = new()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    CountryCode = user.CountryCode,
                    PhoneNumber = user.PhoneNumber,
                };

                return new ApiWrapperResponse<AccountViewModelResponse>(entity, false, HttpStatusCode.OK, ApplicationMessages.Successed);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new AccountViewModelResponse());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<PagedResult<AccountViewModelResponse>>> GetAccountsAsync(AccountListRequest request)
        {
            try
            {
                var accounts = _userManager.Users.AsNoTracking().AsQueryable();

                var result = await _mapper.ProjectTo<AccountViewModelResponse>(accounts).ToListAsync();

                var entity = result.ToPagedResult10(request.Page);

                return new ApiWrapperResponse<PagedResult<AccountViewModelResponse>>(entity);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new PagedResult<AccountViewModelResponse>());
            }
        }

        //Test Done :)
        public async Task<ApiWrapperResponse<PagedResult<AccountViewModelResponse>>> SearchAsync(AccountSearchModelRequest request)
        {
            try
            {
                var query = _userManager.Users.Include(x => x.Role).AsQueryable();

                if (!string.IsNullOrWhiteSpace(request.RoleId))
                    query = query.Where(x => x.RoleId.Contains(request.RoleId));

                if (!string.IsNullOrWhiteSpace(request.UserName))
                    query = query.Where(x => x.UserName.Contains(request.UserName));

                if (!string.IsNullOrWhiteSpace(request.CountryCode))
                    query = query.Where(x => x.CountryCode.Contains(request.CountryCode));

                if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
                    query = query.Where(x => x.PhoneNumber.Contains(request.PhoneNumber));

                var result = await _mapper.ProjectTo<AccountViewModelResponse>(query).ToListAsync();

                var entity = result.ToPagedResult10(request.Page);

                return new ApiWrapperResponse<PagedResult<AccountViewModelResponse>>(entity);
            }
            catch (Exception ex)
            {
                return ExceptionHandler(ex, new PagedResult<AccountViewModelResponse>());
            }
        }
        #endregion

        #region OutherHelperMethod
        private List<int> GetAllPermissions(Account account)
        {
            return _roleManager.Roles.FirstAsync(x => x.Id == account.RoleId).Result.Permissions.Select(x => x.Code).ToList();
        }

        private Task<string> GenerateToken(AuthViewModelCommand account)
        {
            var permissions = JsonSerializer.Serialize(account.Permissions);
            var claims = new List<Claim>
            {
                new Claim("Permissions", permissions),
                new Claim("UserId", account.Id.ToString()),
                new Claim("CountryCode" , account.CountryCode),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, account.UserName),
                new Claim(ClaimTypes.MobilePhone , account.PhoneNumber),
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
                                             audience: _configuration["Jwt:Audience"],
                                             claims: claims,
                                             expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExpiryDuration"])),
                                             notBefore: DateTime.Now,
                                             signingCredentials: credentials);
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(result);
        }

        private async Task<bool> CheckIfUsernameIsDuplicated(string newUserName)
        {
            var userNames = await _userManager.Users.Select(x => new { UserName = x.UserName }).ToListAsync();
            return userNames.Any(x => String.Equals(x.UserName, newUserName, StringComparison.OrdinalIgnoreCase));
        }

        private async Task<bool> Exists(Expression<Func<Account, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        private async Task<Account> FindByPhoneNumber(string countryCode, string phoneNumber)
        {
            return await _userManager.Users.Where(x => x.CountryCode == countryCode && x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }
        #endregion
    }
}