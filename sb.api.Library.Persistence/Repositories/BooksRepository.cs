using Microsoft.EntityFrameworkCore;
using sb.api.Library.Application.Contracts.Repositories;
using sb.api.Library.Application.Utilities.Pagination;
using sb.api.Library.Domain.Entities;
using sb.api.Library.Persistence.Extensions;

namespace sb.api.Library.Persistence.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DataContext _context;

        public BooksRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PaginationResponse<Book>> GetPagedListAsync(
            PaginationRequest pagination,
            string? search,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Book> query = CatalogBooks();

            string? term = NormalizeSearch(search);
            if (term is not null)
            {
                query = query.Where(b => b.Title.Contains(term));
            }

            query = query.OrderBy(b => b.Title);

            return await query.ToPagedListAsync(pagination, cancellationToken);
        }

        public Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return CatalogBooks().FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }

        private IQueryable<Book> CatalogBooks()
        {
            return _context.Books
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.Authors)
                .Include(b => b.Categories)
                .AsQueryable();
        }

        private static string? NormalizeSearch(string? search)
        {
            return string.IsNullOrWhiteSpace(search) ? null : search.Trim();
        }
    }
}
