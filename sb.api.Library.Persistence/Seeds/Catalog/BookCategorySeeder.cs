using Microsoft.EntityFrameworkCore;
using sb.api.Library.Domain.Entities;
using sb.api.Library.Persistence.Seeds;

namespace sb.api.Library.Persistence.Seeds.Catalog
{
    public class BookCategorySeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public BookCategorySeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 5;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.BookCategories.AnyAsync(cancellationToken))
            {
                return;
            }

            await _context.BookCategories.AddRangeAsync(
            [
                new BookCategory(CatalogSeedIds.CienAnos, CatalogSeedIds.Fiction),
                new BookCategory(CatalogSeedIds.CienAnos, CatalogSeedIds.LatinAmerican),
                new BookCategory(CatalogSeedIds.CienAnos, CatalogSeedIds.MagicalRealism),
                new BookCategory(CatalogSeedIds.AmorColera, CatalogSeedIds.Fiction),
                new BookCategory(CatalogSeedIds.AmorColera, CatalogSeedIds.LatinAmerican),
                new BookCategory(CatalogSeedIds.CasaEspiritus, CatalogSeedIds.Fiction),
                new BookCategory(CatalogSeedIds.CasaEspiritus, CatalogSeedIds.MagicalRealism),
                new BookCategory(CatalogSeedIds.Ficciones, CatalogSeedIds.Fiction),
                new BookCategory(CatalogSeedIds.Ficciones, CatalogSeedIds.LatinAmerican),
                new BookCategory(CatalogSeedIds.PridePrejudice, CatalogSeedIds.Fiction),
                new BookCategory(CatalogSeedIds.PridePrejudice, CatalogSeedIds.Classics),
                new BookCategory(CatalogSeedIds.NineteenEightyFour, CatalogSeedIds.Fiction),
                new BookCategory(CatalogSeedIds.NineteenEightyFour, CatalogSeedIds.Dystopian),
                new BookCategory(CatalogSeedIds.BoomAnthology, CatalogSeedIds.LatinAmerican)
            ], cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
