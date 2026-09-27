using Microsoft.EntityFrameworkCore;
using sb.api.Library.Application.Contracts.Repositories;
using sb.api.Library.Application.Utilities.Pagination;
using sb.api.Library.Domain.Entities;
using sb.api.Library.Persistence.Extensions;

namespace sb.api.Library.Persistence.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly DataContext _context;

        public AuthorsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PaginationResponse<Author>> GetPagedListAsync(
            PaginationRequest pagination,
            string? search,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Author> query = CatalogAuthors();

            string? term = NormalizeSearch(search);
            if (term is not null)
            {
                query = query.Where(a =>
                    a.FirstName.Contains(term) ||
                    a.LastName.Contains(term) ||
                    (a.FirstName + " " + a.LastName).Contains(term));
            }

            query = query.OrderBy(a => a.LastName).ThenBy(a => a.FirstName);

            return await query.ToPagedListAsync(pagination, cancellationToken);
        }

        public Task<Author?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return CatalogAuthors().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        private IQueryable<Author> CatalogAuthors()
        {
            return _context.Authors
                .Include(a => a.Books)
                .AsQueryable();
        }

        private static string? NormalizeSearch(string? search)
        {
            return string.IsNullOrWhiteSpace(search) ? null : search.Trim();
        }
    }
}
