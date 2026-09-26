using Microsoft.EntityFrameworkCore;
using sb.api.Library.Domain.Entities;
using sb.api.Library.Persistence.Seeds;

namespace sb.api.Library.Persistence.Seeds.Catalog
{
    public class BookSeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public BookSeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 3;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Books.AnyAsync(cancellationToken))
            {
                return;
            }

            await _context.Books.AddRangeAsync(
            [
                new Book(CatalogSeedIds.CienAnos, "Cien años de soledad", "9780307474728", 1967, "Editorial Sudamericana", "es", "La historia de la familia Buendía en Macondo."),
                new Book(CatalogSeedIds.AmorColera, "El amor en los tiempos del cólera", "9780307389732", 1985, "Editorial Oveja Negra", "es", "Un romance que cubre más de medio siglo."),
                new Book(CatalogSeedIds.CasaEspiritus, "La casa de los espíritus", "9781501117015", 1982, "Plaza & Janés", "es", "Saga familiar de los Trueba."),
                new Book(CatalogSeedIds.Ficciones, "Ficciones", "9780802130303", 1944, "Editorial Sur", "es", "Colección de cuentos de Borges."),
                new Book(CatalogSeedIds.PridePrejudice, "Pride and Prejudice", "9780141439518", 1813, "T. Egerton", "en", "Elizabeth Bennet and Mr. Darcy."),
                new Book(CatalogSeedIds.NineteenEightyFour, "1984", "9780451524935", 1949, "Secker & Warburg", "en", "A dystopian novel about surveillance and control."),
                new Book(CatalogSeedIds.BoomAnthology, "Antología del Boom latinoamericano", "9788491041234", 1970, "Alianza Editorial", "es", "Selección de autores del Boom.")
            ], cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
