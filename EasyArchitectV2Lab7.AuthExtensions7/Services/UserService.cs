using EasyArchitectV2Lab7.AuthExtensions7.Models;
using EasyArchitectV2Lab7.Configuration7;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyArchitectV2Lab7.AuthExtensions7.Services
{
    /// <summary>
    /// EasyArchitect V2 的使用者驗證與授權相關服務
    /// </summary>
    public class UserService : IUserService
    {
        public static IEnumerable<IAccountEnt>? _accountEnts;

        private readonly IOptions<AppSettings> _appSettings;
        private string _identityUser;
        private decimal? _identityId;

        /// <summary>
        /// 取得目前 Scoped 下的使用者
        /// </summary>
        public string IdentityUser { get => _identityUser; set => _identityUser = value; }
        /// <summary>
        /// 取得目前 Scoped 下的使用者的 Id (流水號)
        /// </summary>
        public decimal? IdentityId { get => _identityId; set => _identityId = value; }

        public UserService(IOptions<AppSettings> appSettings, IEnumerable<IAccountEnt> accountEnts)
        {
            this._appSettings = appSettings;
            _accountEnts = accountEnts;
        }
        /// <summary>
        /// 外部人員驗證方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            User? user = null;

            user = new User()
            {
                Id = 1,
                Username = model.Username
            };

            //user = _context
            //    .Account
            //    .Where(x => x.Userid == model.Username && x.Password! == model.Password && x.ID != 0)
            //    .Select(u => new User()
            //    {
            //        Id = (decimal)u.ID,
            //        Username = u.Userid
            //    })
            //    .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            var token = generateJwtToken(user);

            // 若目前登入的使用者存在於系統中，將目前 User 名稱記錄在 IdentityUser 屬性中（此屬性只在目前 Scoped Lifecycle 中有效）
            IdentityUser = model.Username;
            IdentityId = user.Id;

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _accountEnts
                .Select(c => new User()
                {
                    Id = c.Id,
                    Username = c.UserID
                });
        }

        public User? GetByUsername(string username)
        {
            return new User()
            {
                Id = 1,
                Username = username
            };
            /*
            return _accountEnts
                .Where(x => x.UserID == username)
                .Select(c => new User()
                {
                    Id = c.Id,
                    Username = c.UserID
                })
                .FirstOrDefault();
            */
        }

        /// <summary>
        /// 產生 Jwt Token.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string generateJwtToken(User user)
        {
            // 產生一個期限只有 【appSettings/TimeoutMinutes】所設定之時間（分鐘）
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Username", user.Username), new Claim("Id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.Value.TimeoutMinutes.HasValue ? _appSettings.Value.TimeoutMinutes.Value : 30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
