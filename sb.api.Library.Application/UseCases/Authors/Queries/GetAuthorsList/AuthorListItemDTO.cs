using sb.api.Library.Application.UseCases.Catalog.Dtos;

namespace sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorsList
{
    public class AuthorListItemDTO
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public List<BookSummaryDTO> Books { get; init; } = [];
    }
}
