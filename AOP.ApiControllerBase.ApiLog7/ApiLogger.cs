using EasyArchitectCore.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using System.Net.Http;
using System.Reflection.Metadata;

namespace EasyArchitectV2Lab1.ApiControllerBase.ApiLog
{
    public class ApiLogger
    {
        private static string _baseDirectory = AppContext.BaseDirectory;
        private static LogFactory _logFactory = NLogBuilder.ConfigureNLog(Path.Combine(_baseDirectory, "NLogOutSide.Config")); //LogManager.GetCurrentClassLogger();
        private static Logger _loggerInfo = _logFactory.GetLogger("outsideInfo");
        private static Logger _loggerError = _logFactory.GetLogger("outsideError");

        private static IUriExtensions _uriExtensions;

        public ApiLogger() { }
        /// <summary>
        /// 紀錄執行 Log Info 紀錄
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="startTime"></param>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <param name="paramesString"></param>
        /// <param name="currentTime"></param>
        /// <param name="sw"></param>
        /// <param name="absoluteUri"></param>
        public static void WriteLog(
            string userName,
            DateTime? startTime,
            string controllerName,
            string actionName,
            string paramesString,
            DateTime currentTime,
            long sw,
            string absoluteUri)
        {
            _loggerInfo.Info(string.Format("\t{0}\t[來源：{7}]\t執行\t{2}.{3}\t[parame:{4}]\t[開始時間：{1}]\t[結束時間：{5}]\t[花費時間：{6}]",
                    userName,
                    startTime,
                    controllerName,
                    actionName,
                    paramesString,
                    DateTime.Now,
                    sw,
                    absoluteUri));
        }
        /// <summary>
        /// 記錄詳細的錯誤訊息
        /// </summary>
        /// <param name="absoluteUri"></param>
        /// <param name="absoluteUri2"></param>
        /// <param name="httpMethod"></param>
        /// <param name="parames"></param>
        /// <param name="errorMeg"></param>
        /// <param name="stackTrace"></param>
        public static void WriteErrorLog(
            HttpContext context,
            string absoluteUri,
            string absoluteUri2,
            string httpMethod,
            string parames,
            string errorMeg,
            string? stackTrace)
        {
            _loggerError.Error(string.Format("\t[{0}]\t執行失敗\t{1}.{2}\t[parame:{3}]\t{4}\tStackTrace:{5}",
                                absoluteUri,
                                absoluteUri2,
                                context.Request.Method,
                                "",
                                errorMeg,
                                stackTrace));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="errMeg"></param>
        public static void WriteErrorLog(HttpContext httpContextAccessor, string errMeg)
        {
            IUriExtensions uriExtensions = httpContextAccessor!.RequestServices.GetRequiredService<IUriExtensions>();
            string absoluteUri = httpContextAccessor.Request.GetAbsoluteUri(uriExtensions);

            // 紀錄錯誤的 Error Log Message
            WriteErrorLog(
                httpContextAccessor,
                absoluteUri,
                absoluteUri,
                httpContextAccessor.Request.Method,
                httpContextAccessor.Request.Path,
                errMeg,
                "");
        }
    }
}
