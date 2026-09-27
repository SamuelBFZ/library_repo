namespace sb.api.Library.Application.UseCases.Catalog.Dtos
{
    public class AuthorSummaryDTO
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
    }
}
