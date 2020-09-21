using AutoMapper;
using EvolentHealth.Contact.Business.Interface;
using EvolentHealth.Contact.Business.Manager;
using EvolentHealth.Contact.Common;
using EvolentHealth.Contact.DataAccess;
using EvolentHealth.Contact.DataAccess.Interface;
using EvolentHealth.Contact.DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace EvolentHealth.Contact.Service
{
    public static class ExtentionMethods
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContactManager, ContactManager>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ContactDBContext>(options =>
              options.UseSqlServer(configuration["ConnectionString"]));
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
            return services;
        }
    }
}
