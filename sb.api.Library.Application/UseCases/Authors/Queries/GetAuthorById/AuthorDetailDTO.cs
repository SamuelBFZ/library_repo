using sb.api.Library.Application.UseCases.Catalog.Dtos;

namespace sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorById
{
    public class AuthorDetailDTO
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string? Biography { get; init; }
        public DateOnly? BirthDate { get; init; }
        public List<BookSummaryDTO> Books { get; init; } = [];
    }
}
