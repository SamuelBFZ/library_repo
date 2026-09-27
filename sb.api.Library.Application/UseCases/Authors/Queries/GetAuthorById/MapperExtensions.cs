using sb.api.Library.Application.UseCases.Catalog.Dtos;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorById
{
    internal static class MapperExtensions
    {
        public static AuthorDetailDTO ToDetailDTO(this Author author)
        {
            return new AuthorDetailDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                Books = author.Books.ToOrderedBookSummaries(),
            };
        }
    }
}
