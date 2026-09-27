using sb.api.Library.Application.Contracts.Repositories;
using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdUseCase : IRequestHandler<GetCategoryByIdQuery, CategoryDetailDTO?>
    {
        private readonly ICategoriesRepository _repository;

        public GetCategoryByIdUseCase(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryDetailDTO?> Handle(GetCategoryByIdQuery query)
        {
            Category? category = await _repository.GetByIdAsync(query.Id);
            return category?.ToDetailDTO();
        }
    }
}
