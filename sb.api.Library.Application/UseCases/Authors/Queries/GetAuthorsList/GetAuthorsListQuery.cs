using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Application.Utilities.Pagination;

namespace sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorsList
{
    public class GetAuthorsListQuery : IRequest<PaginationResponse<AuthorListItemDTO>>
    {
        public PaginationRequest Pagination { get; set; } = PaginationRequest.Standart();
        public string? Search { get; set; }
    }
}
