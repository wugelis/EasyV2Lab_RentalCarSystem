using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyArchitectV2Lab7.JWTMiddleware7
{
    public static class JwtCustomAuthenticationMiddleware
    {
        public static IApplicationBuilder UseJwtCustomAuthentication(this IApplicationBuilder app)
        {
            return app.UseMiddleware<JwtService>();
        }
    }
}
