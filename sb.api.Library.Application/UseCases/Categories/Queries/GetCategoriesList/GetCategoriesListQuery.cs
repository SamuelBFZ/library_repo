using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Application.Utilities.Pagination;

namespace sb.api.Library.Application.UseCases.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<PaginationResponse<CategoryListItemDTO>>
    {
        public PaginationRequest Pagination { get; set; } = PaginationRequest.Standart();
        public string? Search { get; set; }
    }
}
