
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;

namespace Infrastrucure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSrcInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseInMemoryDatabase("TMInMemoryDatabase"));

            services.AddScoped<IDbContext>(provider => provider.GetService<UserDbContext>());

            return services;
        }
    }
}
