using sb.api.Library.Application.UseCases.Catalog.Dtos;

namespace sb.api.Library.Application.UseCases.Books.Queries.GetBooksList
{
    public class BookListItemDTO
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = null!;
        public string? Isbn { get; init; }
        public short? PublicationYear { get; init; }
        public string? Publisher { get; init; }
        public string? Language { get; init; }
        public List<AuthorSummaryDTO> Authors { get; init; } = [];
        public List<CategorySummaryDTO> Categories { get; init; } = [];
    }
}
