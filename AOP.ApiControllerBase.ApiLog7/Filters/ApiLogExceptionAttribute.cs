using EasyArchitectCore.Core;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyArchitectV2Lab1.ApiControllerBase.ApiLog.Filters
{
    /// <summary>
    /// 錯誤紀錄 Error Log Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ApiLogExceptionAttribute : Attribute, IExceptionFilter
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 發生在當 Action 執行時發生錯誤時
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnException(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                //如果有內部錯誤就抓取內部錯誤 (Update by Gelis at 2015/03/12)
                Exception innerEx = context.Exception.InnerException != null ? context.Exception.InnerException : context.Exception;

                var uriExts = context.HttpContext.RequestServices.GetRequiredService<IUriExtensions>();

                ApiLogger.WriteErrorLog(
                                context.HttpContext,
                                context.HttpContext.Request.GetAbsoluteUri(uriExts),
                                context.HttpContext.Request.GetAbsoluteUri(uriExts),
                                context.HttpContext.Request.Method,
                                "",
                                innerEx.Message,
                                innerEx.StackTrace);
            }
        }


    }
}
