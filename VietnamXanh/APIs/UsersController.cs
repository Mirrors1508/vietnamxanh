using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Lib.Ultilities.Constants;
using Utilities;
using Lib.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Lib.Entities.Models;
using Lib.Repositories.AccountRepo;
using Lib.Entities.AccountWebModels;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WEB.APIs
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        public UsersController(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }
        /// <summary>
        /// Function thực hiện xử lý đăng nhập bước 1.
        /// </summary>
        /// <param name="entity"> Thông tin đăng nhập</param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmLogin(LoginRequest model)
        {
            try
            {
                //-- Validate model
                if (model == null || model.username == null || model.username.Trim() == "" || model.password == null || model.password.Trim() == "")
                {
                    return Ok(new BaseResponseModel<string>()
                    {
                        status = ResponseStatus.FAILED,
                        msg = NotificationText.Users.LoginIncorrect
                    });
                }
                //-- Bỏ ký tự đặc biệt
                model.username = StringHelpers.RemoveSpecialCharacters(model.username);
                model.username = model.username.Replace("+", "").Replace("//", "").Replace("=", "");
                model.password = StringHelpers.RemoveNonKeyBoardInputCharacter(model.password);
                //-- Kiểm tra user/pass
                var user = await _accountRepository.GetByUsernameAndPassword(model.username, model.password);
                if (user == null || user.Id <= 0)
                {
                    return Ok(new BaseResponseModel<string>()
                    {
                        status = ResponseStatus.FAILED,
                        msg = NotificationText.Users.LoginIncorrect
                    });
                }
                //-- Nếu tài khoản bị khóa
                if (user.Status != AccountStatus.ACTIVATED || HttpContext.Request.HttpContext.Connection.RemoteIpAddress == null)
                {
                    return Ok(new BaseResponseModel<string>()
                    {
                        status = ResponseStatus.FAILED,
                        msg = NotificationText.Users.LockedOrNotActivated
                    });
                }
                var model_authent = JsonConvert.DeserializeObject<AccountAuthenticationModel>(JsonConvert.SerializeObject(user));
                model_authent.remote_ip = HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
                var success = await CreateAuthentication(model_authent);
                if (success)
                {
                    return Ok(new BaseResponseModel<string>()
                    {
                        status = ResponseStatus.SUCCESS,
                        msg = NotificationText.Users.Success
                    });
                }
            }
            catch
            {
            }
            return Ok(new BaseResponseModel<string>()
            {
                status = ResponseStatus.FAILED,
                msg = NotificationText.Users.LoginIncorrect
            });
        }
        private async Task<bool> CreateAuthentication(AccountAuthenticationModel model)
        {
            try
            {
                if(model==null || model.Id <= 0 || model.Dataid==null|| model.Dataid<=0)
                {
                    return false;
                }
                var user = await _userRepository.GetById((int)model.Dataid);
                if(user==null || user.Id<=0 || user.Status != AccountStatus.ACTIVATED)
                {
                    return false;
                }
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id.ToString())); ;
                claims.Add(new Claim("UserID", user.Id.ToString())); ;
                claims.Add(new Claim(ClaimTypes.Name, user.Name));
                claims.Add(new Claim(ClaimTypes.Email, user.Email));

                //-- Login:
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                    IsPersistent = true
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return true;
            }
            catch
            {
            }
            return false;
        }
    }
}
