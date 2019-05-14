using Logic_Layer.Handlers;
using Data_Layer;
using Data_Layer.Interface;
using Data_Layer.Repository;
using Logic_Layer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service_Layer.RequestHandlers;
using Service_Layer.SessionExtension;
using System;

namespace Service_Layer.ServiceCollector
{
    public static class ServiceCollector
    {
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ILogin, AccountHandler>();
            services.AddTransient<IRegister, AccountHandler>();

            services.AddTransient<RatingHandler>();
            services.AddTransient<SessionHandler>();
            services.AddTransient<UserHandler>();
            services.AddTransient<VideoAssignHandler>();

            return services;
        }
    }
}
