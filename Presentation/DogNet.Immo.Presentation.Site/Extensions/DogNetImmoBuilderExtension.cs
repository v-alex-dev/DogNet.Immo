using DogNet.Immo.Business;
using DogNet.Immo.Data;
using DogNet.Immo.Data.Providers.Sql.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DogNet.Immo.Presentation.Site.Extensions
{
    public static class DogNetImmoBuilderExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRealtyRepository, RealtyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddDomains(this IServiceCollection services)
        {
            services.AddScoped<RealtyDomain>();
            services.AddScoped<UserDomain>();
        }
    }
}
