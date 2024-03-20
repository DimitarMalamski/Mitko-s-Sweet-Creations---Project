using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mitko_s_Sweet_Creations.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        // Adding the content to the service collection
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            // Getting the connection string for the database
            var connectionString = config.GetConnectionString("DefaultConnection");

            // Configuring the context 
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            //Providing helpful error information in the development environment for migrations errors
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        //adding identity to the application
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
