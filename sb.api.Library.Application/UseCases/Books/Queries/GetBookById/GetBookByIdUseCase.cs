using sb.api.Library.Application.Contracts.Repositories;
using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Books.Queries.GetBookById
{
    public class GetBookByIdUseCase : IRequestHandler<GetBookByIdQuery, BookDetailDTO?>
    {
        private readonly IBooksRepository _repository;

        public GetBookByIdUseCase(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookDetailDTO?> Handle(GetBookByIdQuery query)
        {
            Book? book = await _repository.GetByIdAsync(query.Id);
            return book?.ToDetailDTO();
        }
    }
}
