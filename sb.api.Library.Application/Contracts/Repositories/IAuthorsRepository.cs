using sb.api.Library.Application.Utilities.Pagination;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.Contracts.Repositories
{
    public interface IAuthorsRepository
    {
        Task<PaginationResponse<Author>> GetPagedListAsync(
            PaginationRequest pagination,
            string? search,
            CancellationToken cancellationToken = default);

        Task<Author?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
