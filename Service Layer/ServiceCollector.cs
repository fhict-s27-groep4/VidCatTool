using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using BusinessLogicLibrary;
using Microsoft.Extensions.Configuration;
using Data_Layer;
using Microsoft.EntityFrameworkCore;
using Data_Layer.Interface;
using Data_Layer.Repository;

namespace Service_Layer
{
    public static class ServiceCollector
    {
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<VidCatToolContext>(options => options.UseMySql(config["ConnectionStrings:MYSQLConnection"]));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddSingleton<ApplicationUser>();
            services.AddTransient<IAccountHandler, AccountHandler>();
            services.AddTransient<IAssignManager, AssignManager>();
            return services;
        }

        public static IServiceCollection RenewSingletonService<T>(this IServiceCollection services)
        {
            var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            if (serviceDescriptor != null) services.Remove(serviceDescriptor);

            services.AddSingleton<ApplicationUser>();

            return services;
        }
    }
}
