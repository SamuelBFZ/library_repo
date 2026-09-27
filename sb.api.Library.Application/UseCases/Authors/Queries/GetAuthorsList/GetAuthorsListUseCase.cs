using sb.api.Library.Application.Contracts.Repositories;
using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Application.Utilities.Pagination;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorsList
{
    public class GetAuthorsListUseCase : IRequestHandler<GetAuthorsListQuery, PaginationResponse<AuthorListItemDTO>>
    {
        private readonly IAuthorsRepository _repository;

        public GetAuthorsListUseCase(IAuthorsRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginationResponse<AuthorListItemDTO>> Handle(GetAuthorsListQuery query)
        {
            PaginationRequest pagination = query.Pagination;
            PaginationResponse<Author> response = await _repository.GetPagedListAsync(pagination, query.Search);

            List<AuthorListItemDTO> items = response.Items.Select(a => a.ToListItemDTO()).ToList();

            return PaginationResponse<AuthorListItemDTO>.Create(items, response.TotalCount, pagination);
        }
    }
}
