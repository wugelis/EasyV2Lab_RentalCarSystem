using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyArchitectV2Lab7.AuthExtensions7.Models
{
    public class AuthenticateResponse
    {
        public decimal Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Token = token;
        }
    }
}
