using sb.api.Library.Application.Contracts.Repositories;
using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdUseCase : IRequestHandler<GetAuthorByIdQuery, AuthorDetailDTO?>
    {
        private readonly IAuthorsRepository _repository;

        public GetAuthorByIdUseCase(IAuthorsRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthorDetailDTO?> Handle(GetAuthorByIdQuery query)
        {
            Author? author = await _repository.GetByIdAsync(query.Id);
            return author?.ToDetailDTO();
        }
    }
}
