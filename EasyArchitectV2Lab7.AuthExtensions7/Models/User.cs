using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyArchitectV2Lab7.AuthExtensions7.Models
{
    /// <summary>
    /// JSON Idenity Token 保存的使用者資料模型
    /// </summary>
    public class User
    {
        public decimal Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public static string LOGIN_USER_INFO = "LOGIN_USER_INFO";
    }
}
