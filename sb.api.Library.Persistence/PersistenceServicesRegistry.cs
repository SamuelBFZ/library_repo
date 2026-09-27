using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sb.api.Library.Application.Contracts.Persistence;
using sb.api.Library.Application.Contracts.Repositories;
using sb.api.Library.Persistence.Repositories;
using sb.api.Library.Persistence.Seeds;
using sb.api.Library.Persistence.Seeds.Catalog;
using sb.api.Library.Persistence.UnitOfWorks;

namespace sb.api.Library.Persistence
{
    public static class PersistenceServicesRegistry
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyConnection"));
            });

            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            services.AddScoped<IDataSeeder, AuthorSeeder>();
            services.AddScoped<IDataSeeder, CategorySeeder>();
            services.AddScoped<IDataSeeder, BookSeeder>();
            services.AddScoped<IDataSeeder, BookAuthorSeeder>();
            services.AddScoped<IDataSeeder, BookCategorySeeder>();

            return services;
        }
    }
}
