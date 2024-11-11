using EasyArchitectCore.Core;
using EasyArchitectV2Lab7.AuthExtensions7.Extensions;
using EasyArchitectV2Lab7.AuthExtensions7.Models;
using EasyArchitectV2Lab7.AuthExtensions7.Services;
using EasyArchitectV2Lab7.Configuration7;
using EasyArchitectV2Lab7.JWTMiddleware7;
using Microsoft.AspNetCore.Authentication.Cookies;
using RentalCar7.Application7;
using RentalCar7.Application7.port.In;
using RentalCar7.Application7.port.Out;
using RentalCar7.Infrastructure7.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfigurationSection configRoot = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(configRoot);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(configure =>
{
    configure.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    configure.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(3);
    options.Cookie.HttpOnly = true;
    options.Events = new CookieAuthenticationEvents()
    {
        OnRedirectToReturnUrl = async (context) =>
        {
            context.HttpContext.Response.Cookies.Delete(AuthenticateRequest.LOGIN_USER_INFO);
        }
    };
});

//builder.Services.AddEasyArchitectV2DbContext(builder.Configuration, "OutsideDbContext");
//builder.Services.AddScoped<IEnumerable<IAccountEnt>, List<AccountEnt>>(account =>
//    new List<AccountEnt>(
//        new AccountEnt[]
//        {
//            new AccountEnt() { Id=1, UserID="gelis", AID="F123456789" },
//            new AccountEnt() { Id=2, UserID="mary", AID="F123456780" },
//            new AccountEnt() { Id=3, UserID="allan", AID="F123456781" },
//        }));

builder.Services.AddScoped<IUriExtensions, UriExtensions>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRentalCarRepository, RentalCarRepository>();
builder.Services.AddScoped<IRentalCarUseCase, RentalCarUseCase>();
builder.Services.AddScoped<RentalCarSerAppServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseJwtCustomAuthentication();

//app.UseEasyArchitectV2Infrastructure();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//namespace EasyArchitectV2Lab7.AuthExtensions7.Extensions
//{
//public class UriExtensions : IUriExtensions
//{
//    public string GetAbsoluteUri(HttpRequest httpRequest)
//    {
//        return httpRequest.Scheme + "://" + httpRequest.Host.ToUriComponent() + httpRequest.PathBase.ToUriComponent() + httpRequest.Path.ToUriComponent() + httpRequest.QueryString.ToUriComponent();
//    }

//    public string GetAbsoluteUri(HttpRequest httpRequest, string customPathUri)
//    {
//        return httpRequest.Scheme + "://" + httpRequest.Host.ToUriComponent() + httpRequest.PathBase.ToUriComponent() + customPathUri + httpRequest.QueryString.ToUriComponent();
//    }
//}
//}