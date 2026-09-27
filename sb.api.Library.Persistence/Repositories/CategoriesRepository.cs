using Microsoft.EntityFrameworkCore;
using sb.api.Library.Application.Contracts.Repositories;
using sb.api.Library.Application.Utilities.Pagination;
using sb.api.Library.Domain.Entities;
using sb.api.Library.Persistence.Extensions;

namespace sb.api.Library.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DataContext _context;

        public CategoriesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PaginationResponse<Category>> GetPagedListAsync(
            PaginationRequest pagination,
            string? search,
            CancellationToken cancellationToken = default)
        {
            IQueryable<Category> query = CatalogCategories();

            string? term = NormalizeSearch(search);
            if (term is not null)
            {
                query = query.Where(c => c.Name.Contains(term));
            }

            query = query.OrderBy(c => c.Name);

            return await query.ToPagedListAsync(pagination, cancellationToken);
        }

        public Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return CatalogCategories().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        private IQueryable<Category> CatalogCategories()
        {
            return _context.Categories
                .Include(c => c.Books)
                .AsQueryable();
        }

        private static string? NormalizeSearch(string? search)
        {
            return string.IsNullOrWhiteSpace(search) ? null : search.Trim();
        }
    }
}
