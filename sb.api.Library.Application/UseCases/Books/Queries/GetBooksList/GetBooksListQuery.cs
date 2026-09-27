using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Application.Utilities.Pagination;

namespace sb.api.Library.Application.UseCases.Books.Queries.GetBooksList
{
    public class GetBooksListQuery : IRequest<PaginationResponse<BookListItemDTO>>
    {
        public PaginationRequest Pagination { get; set; } = PaginationRequest.Standart();
        public string? Search { get; set; }
    }
}
