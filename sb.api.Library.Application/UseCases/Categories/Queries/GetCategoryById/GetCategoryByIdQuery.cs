using sb.api.Library.Application.Utilities.Mediator;

namespace sb.api.Library.Application.UseCases.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDetailDTO?>
    {
        public Guid Id { get; set; }
    }
}
