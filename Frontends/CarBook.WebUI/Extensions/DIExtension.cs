using CarBook.WebUI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarBook.WebUI.Extensions
{
    public static class DIExtension
    {
        public static void AddDI(this IServiceCollection services)
        {
            services.AddScoped<HttpClientServiceViewComponent>();
            services.AddScoped<HttpClientServiceAction>();
        }
    }
}
