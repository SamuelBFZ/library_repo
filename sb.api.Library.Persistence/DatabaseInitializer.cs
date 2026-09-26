using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using sb.api.Library.Persistence.Seeds;

namespace sb.api.Library.Persistence
{
    public static class DatabaseInitializer
    {
        public static async Task MigrateAndSeedAsync(IServiceProvider services, CancellationToken cancellationToken = default)
        {
            using IServiceScope scope = services.CreateScope();
            DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
            await context.Database.MigrateAsync(cancellationToken);
            await DataBaseSeeder.SeedAsync(services, cancellationToken);
        }
    }
}
