using Microsoft.EntityFrameworkCore;
using sb.api.Library.Domain.Entities;
using sb.api.Library.Persistence.Seeds;

namespace sb.api.Library.Persistence.Seeds.Catalog
{
    public class AuthorSeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public AuthorSeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 1;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Authors.AnyAsync(cancellationToken))
            {
                return;
            }

            await _context.Authors.AddRangeAsync(
            [
                new Author(CatalogSeedIds.GarciaMarquez, "Gabriel", "García Márquez", "Novelista colombiano, premio Nobel de Literatura.", new DateOnly(1927, 3, 6)),
                new Author(CatalogSeedIds.Allende, "Isabel", "Allende", "Novelista chilena conocida por el realismo mágico.", new DateOnly(1942, 8, 2)),
                new Author(CatalogSeedIds.Borges, "Jorge Luis", "Borges", "Escritor argentino de cuentos y ensayos.", new DateOnly(1899, 8, 24)),
                new Author(CatalogSeedIds.Austen, "Jane", "Austen", "Novelista inglesa de la época de la regencia.", new DateOnly(1775, 12, 16)),
                new Author(CatalogSeedIds.Orwell, "George", "Orwell", "Ensayista y novelista británico.", new DateOnly(1903, 6, 25))
            ], cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
