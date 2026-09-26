using Microsoft.EntityFrameworkCore;
using sb.api.Library.Domain.Entities;
using sb.api.Library.Persistence.Seeds;

namespace sb.api.Library.Persistence.Seeds.Catalog
{
    public class BookAuthorSeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public BookAuthorSeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 4;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.BookAuthors.AnyAsync(cancellationToken))
            {
                return;
            }

            await _context.BookAuthors.AddRangeAsync(
            [
                new BookAuthor(CatalogSeedIds.CienAnos, CatalogSeedIds.GarciaMarquez, 1),
                new BookAuthor(CatalogSeedIds.AmorColera, CatalogSeedIds.GarciaMarquez, 1),
                new BookAuthor(CatalogSeedIds.CasaEspiritus, CatalogSeedIds.Allende, 1),
                new BookAuthor(CatalogSeedIds.Ficciones, CatalogSeedIds.Borges, 1),
                new BookAuthor(CatalogSeedIds.PridePrejudice, CatalogSeedIds.Austen, 1),
                new BookAuthor(CatalogSeedIds.NineteenEightyFour, CatalogSeedIds.Orwell, 1),
                new BookAuthor(CatalogSeedIds.BoomAnthology, CatalogSeedIds.GarciaMarquez, 1),
                new BookAuthor(CatalogSeedIds.BoomAnthology, CatalogSeedIds.Allende, 2),
                new BookAuthor(CatalogSeedIds.BoomAnthology, CatalogSeedIds.Borges, 3)
            ], cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
