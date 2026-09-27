using sb.api.Library.Application.UseCases.Catalog.Dtos;

namespace sb.api.Library.Application.UseCases.Categories.Queries.GetCategoriesList
{
    public class CategoryListItemDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public List<BookSummaryDTO> Books { get; init; } = [];
    }
}
