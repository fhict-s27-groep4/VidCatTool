using Data_Layer;
using Data_Layer.Interface;
using Data_Layer.Repository;
using Logic_Layer.AlgoritmRatings;
using Logic_Layer.CategoryReverser;
using Logic_Layer.Handlers;
using Logic_Layer.Hasher;
using Logic_Layer.Interfaces;
using Logic_Layer.JsonReader;
using Logic_Layer.JsonWriter;
using Logic_Layer.Maths;
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
            services.AddTransient<IJsonAddRepository, JsonAddRepository>();
            services.AddTransient<IDBContext, MySQLDBContext>();

            services.AddTransient<ILogin, AccountManager>();
            services.AddTransient<IRegister, AccountManager>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddTransient<RatingHandler>();
            services.AddTransient<SessionHandler>();
            services.AddTransient<UserHandler>();
            services.AddTransient<VideoAssignHandler>();
            services.AddTransient<CategoryHandler>();
            services.AddTransient<VideoHandler>();

            services.AddSingleton<IRatingSettings, RatingSettings>();
            services.AddTransient<IRatingAlgoritm, RatingAlgoritm>();
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<IAllCategories, AllCategories>();
            services.AddTransient<IReaderJson, ReaderJson>();
            services.AddTransient<IWriterJson, WriterJson>();
            services.AddTransient<ICalculator, Calculator>();

            return services;
        }
    }
}
