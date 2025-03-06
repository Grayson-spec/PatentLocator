using backend.Repositories.Interfaces;
using backend.Repositories;
using backend.Services;
using backend.Services.Interfaces;


namespace backend.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IPatentRepository, PatentRepository>();
            services.AddTransient<IPatentService, PatentService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            
        }
    }
}