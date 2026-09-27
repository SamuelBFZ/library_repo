using sb.api.Library.Application.Utilities.Pagination;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.Contracts.Repositories
{
    public interface ICategoriesRepository
    {
        Task<PaginationResponse<Category>> GetPagedListAsync(
            PaginationRequest pagination,
            string? search,
            CancellationToken cancellationToken = default);

        Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
