using sb.api.Library.Application.Contracts.Repositories;
using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Application.Utilities.Pagination;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListUseCase : IRequestHandler<GetCategoriesListQuery, PaginationResponse<CategoryListItemDTO>>
    {
        private readonly ICategoriesRepository _repository;

        public GetCategoriesListUseCase(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginationResponse<CategoryListItemDTO>> Handle(GetCategoriesListQuery query)
        {
            PaginationRequest pagination = query.Pagination;
            PaginationResponse<Category> response = await _repository.GetPagedListAsync(pagination, query.Search);

            List<CategoryListItemDTO> items = response.Items.Select(c => c.ToListItemDTO()).ToList();

            return PaginationResponse<CategoryListItemDTO>.Create(items, response.TotalCount, pagination);
        }
    }
}
