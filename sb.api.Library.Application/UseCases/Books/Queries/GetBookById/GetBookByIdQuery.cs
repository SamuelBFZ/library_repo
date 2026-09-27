using sb.api.Library.Application.Utilities.Mediator;

namespace sb.api.Library.Application.UseCases.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDetailDTO?>
    {
        public Guid Id { get; set; }
    }
}
