using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyArchitectV2Lab7.AuthExtensions7.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 是否為 Admin 的管理人員
        /// </summary>
        [Required]
        public bool IsAdmin { get; set; }

        public static string LOGIN_USER_INFO = "LOGIN_USER_INFO";
    }
}
