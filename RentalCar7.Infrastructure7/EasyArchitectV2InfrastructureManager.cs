using RentalCar7.Infrastructure7.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar7.Infrastructure7.RentalCars
{
    /// <summary>
    /// EasyArchiect V2 的 Infrastructure 中間層管理者物件
    /// </summary>
    public class EasyArchitectV2InfrastructureManager
    {
        private readonly RequestDelegate _next;
        private readonly IServiceCollection _services;

        public EasyArchitectV2InfrastructureManager(RequestDelegate next, IServiceCollection services)
        {
            _next = next;
            _services = services;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    context.RequestServices.GetRequiredService<IConfiguration>().GetConnectionString("OutsideDbContext"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // 處理 Request 之前的邏輯
            await _next(context);
            // 處理 Request 之後的邏輯
        }
    }
}

