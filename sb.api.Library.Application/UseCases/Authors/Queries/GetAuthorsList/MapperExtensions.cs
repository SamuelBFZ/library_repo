using sb.api.Library.Application.UseCases.Catalog.Dtos;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorsList
{
    internal static class MapperExtensions
    {
        public static AuthorListItemDTO ToListItemDTO(this Author author)
        {
            return new AuthorListItemDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Books = author.Books.ToOrderedBookSummaries(),
            };
        }
    }
}
