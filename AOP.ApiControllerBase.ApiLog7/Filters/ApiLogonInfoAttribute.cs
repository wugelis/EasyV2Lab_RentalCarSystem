using EasyArchitectCore.Core;
using EasyArchitectV2Lab7.AuthExtensions7.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyArchitectV2Lab1.ApiControllerBase.ApiLog.Filters
{
    /// <summary>
    /// 外部人員的 Web API 呼叫紀錄 Log
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ApiLogonInfoAttribute : Attribute, IActionFilter
    {
        private IUserService _userService;
        private IUriExtensions _uriExtensions;

        private string _userName;
        private string _controllerName;
        private string _actionName;

        private DateTime _startTime;

        private long _startMilliSeconds;

        private string _paramesString;

        System.Diagnostics.Stopwatch sw;

        public ApiLogonInfoAttribute()
        {
            sw = new System.Diagnostics.Stopwatch();
            sw.Reset();
            sw.Start();
        }

        /// <summary>
        /// 在 WEB API 的 ACTION 執行前被觸發.
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _startTime = DateTime.Now;
            _startMilliSeconds = sw.ElapsedMilliseconds;

            _controllerName = context.Controller.GetType().FullName ?? "";
            _actionName = context.ActionDescriptor.DisplayName ?? "";

            _userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
            _uriExtensions = context.HttpContext.RequestServices.GetRequiredService<IUriExtensions>();
        }
        /// <summary>
        /// 在 WEB API 的 ACTION 執行之後被觸發，代表 Web API Method 執行完畢，因此在這裡紀錄 Log 資訊，包括執行時間
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // 取得 Scoped 下的 IdentityUser 名稱，並存放在屬於目前 Current Scoped 下的 userService 物件中，所以每次 DI 注入時均會取得一份 IdentityUser 實體
            // 但只局限於目前 Scoped 範範圍內，在每次『方法呼叫』的『Token 檢核』時產生，一旦 Token 失效，該 IdentityUser 即會失效變成 null
            _userName = _userService.IdentityUser;

            ApiLogger.WriteLog(_userName,
                    _startTime,
                    _controllerName,
                    _actionName,
                    _paramesString,
                    DateTime.Now,
                    sw.ElapsedMilliseconds - _startMilliSeconds,
                    context.HttpContext.Request.GetAbsoluteUri(_uriExtensions));
        }
    }
}
