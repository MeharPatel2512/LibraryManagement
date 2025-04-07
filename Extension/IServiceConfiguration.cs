using Library.Business.Services;
using Library.Business.Interface;
using Library.Repository;
using Library.Middleware;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Extensions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<IExecuteStoredProcedure, ExecuteStoredProcedure>();

            // Register services
            services.AddScoped<IRegisterUserBusiness, RegisterUserBusiness>();
            services.AddScoped<ILoginUserBusiness, LoginUserBusiness>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IOtherUserBusiness, OtherUserBusiness>();
            services.AddScoped<ISubscriptionBusiness, SubscriptionBusiness>();
            services.AddScoped<IAdminBusiness, AdminBusiness>();
            services.AddScoped<IBookBusiness, BookBusiness>();
            services.AddScoped<TokenService>();
        }
    }
}
