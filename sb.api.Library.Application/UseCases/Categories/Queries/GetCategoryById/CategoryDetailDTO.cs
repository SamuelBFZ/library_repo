using sb.api.Library.Application.UseCases.Catalog.Dtos;

namespace sb.api.Library.Application.UseCases.Categories.Queries.GetCategoryById
{
    public class CategoryDetailDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public string? Description { get; init; }
        public List<BookSummaryDTO> Books { get; init; } = [];
    }
}
