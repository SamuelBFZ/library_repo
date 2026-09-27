using sb.api.Library.Application.Utilities.Pagination;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.Contracts.Repositories
{
    public interface IBooksRepository
    {
        Task<PaginationResponse<Book>> GetPagedListAsync(
            PaginationRequest pagination,
            string? search,
            CancellationToken cancellationToken = default);

        Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
