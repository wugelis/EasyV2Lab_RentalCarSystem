using EasyArchitectV2Lab7.AuthExtensions7.Models;
using EasyArchitectV2Lab7.AuthExtensions7.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EasyArchitectV2Lab7.ApiControllerBase7
{
    /// <summary>
    /// EasyArchitect V2 的 API Controller 基底類別實作
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EasyArchiectV2ControllerBase : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public EasyArchiectV2ControllerBase(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }
        /// <summary>
        /// 外部人員 獨立框架的（登入/Login）方法
        /// </summary>
        /// <param name="authenticateModel"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        //[ApiLogonInfo]
        //[ApiLogException]
        public IActionResult Login(AuthenticateRequest authenticateModel)
        {
            var response = _userService.Authenticate(authenticateModel);

            //if (response == null)
            //{
            //    ApiLogger.WriteErrorLog(_httpContextAccessor.HttpContext, _errorMessage);

            //    return BadRequest(new { message = _errorMessage });
            //}

            return Ok(response);
        }
    }
}
