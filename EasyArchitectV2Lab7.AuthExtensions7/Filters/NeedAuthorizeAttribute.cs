using EasyArchitectCore.Core;
using EasyArchitectV2Lab1.ApiControllerBase.ApiLog;
using EasyArchitectV2Lab1.ApiControllerBase.ApiLog.Filters;
using EasyArchitectV2Lab7.AuthExtensions7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyArchitectV2Lab7.AuthExtensions7.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class NeedAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string errorMessage = "未授權存取此資源 (Unauthorized).\r\n請確認您具備存取此資源的帳號與權限。";
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                var actionName = context.ActionDescriptor.DisplayName;
                //var controllerName = context.HttpContext.Controller.GetType().FullName;

                // 取得 Action 上面有使用的 Attributes
                // 使用 AOP 屬性方式擴充附加功能（這裡則取得該屬性進行相關處裡）
                var endpointMetadata = context.ActionDescriptor.EndpointMetadata;
                var hasApiLogException = endpointMetadata.Any(x => x.GetType() == typeof(ApiLogExceptionAttribute));
                
                // 如果存在 ApiLogonInfo，則紀錄 Log 資訊，否则忽略
                if (hasApiLogException)
                {
                    IUriExtensions uriExtensions = context.HttpContext.RequestServices.GetRequiredService<IUriExtensions>();
                    string absoluteUri = context.HttpContext.Request.GetAbsoluteUri(uriExtensions);

                    // 紀錄錯誤的 Error Log Message
                    ApiLogger.WriteErrorLog(
                        context.HttpContext,
                        absoluteUri,
                        absoluteUri,
                        context.HttpContext.Request.Method,
                        context.HttpContext.Request.Path,
                        errorMessage,
                        "");
                }
                

                // 未登入時複寫 IActionResult
                context.Result = new JsonResult(new { message = errorMessage })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
