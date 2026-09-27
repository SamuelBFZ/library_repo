namespace sb.api.Library.Application.UseCases.Catalog.Dtos
{
    public class BookSummaryDTO
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = null!;
        public short? PublicationYear { get; init; }
    }
}
