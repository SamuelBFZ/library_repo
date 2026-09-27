using sb.api.Library.Application.Contracts.Repositories;
using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Application.Utilities.Pagination;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Books.Queries.GetBooksList
{
    public class GetBooksListUseCase : IRequestHandler<GetBooksListQuery, PaginationResponse<BookListItemDTO>>
    {
        private readonly IBooksRepository _repository;

        public GetBooksListUseCase(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginationResponse<BookListItemDTO>> Handle(GetBooksListQuery query)
        {
            PaginationRequest pagination = query.Pagination;
            PaginationResponse<Book> response = await _repository.GetPagedListAsync(pagination, query.Search);

            List<BookListItemDTO> items = response.Items.Select(b => b.ToListItemDTO()).ToList();

            return PaginationResponse<BookListItemDTO>.Create(items, response.TotalCount, pagination);
        }
    }
}
