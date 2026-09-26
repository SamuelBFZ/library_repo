using Microsoft.EntityFrameworkCore;
using sb.api.Library.Domain.Entities;
using sb.api.Library.Persistence.Seeds;

namespace sb.api.Library.Persistence.Seeds.Catalog
{
    public class CategorySeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public CategorySeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 2;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Categories.AnyAsync(cancellationToken))
            {
                return;
            }

            await _context.Categories.AddRangeAsync(
            [
                new Category(CatalogSeedIds.Fiction, "Fiction", "Narrative literature."),
                new Category(CatalogSeedIds.LatinAmerican, "Latin American Literature", "Works from Latin America."),
                new Category(CatalogSeedIds.Classics, "Classics", "Works with lasting literary importance."),
                new Category(CatalogSeedIds.Dystopian, "Dystopian", "Speculative fiction about oppressive societies."),
                new Category(CatalogSeedIds.MagicalRealism, "Magical Realism", "Everyday settings with magical elements.")
            ], cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
