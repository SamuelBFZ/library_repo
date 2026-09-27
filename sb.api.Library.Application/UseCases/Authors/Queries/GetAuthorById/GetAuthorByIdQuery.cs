using sb.api.Library.Application.Utilities.Mediator;

namespace sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<AuthorDetailDTO?>
    {
        public Guid Id { get; set; }
    }
}
