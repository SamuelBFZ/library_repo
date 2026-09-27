using sb.api.Library.Application.UseCases.Catalog.Dtos;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Books.Queries.GetBooksList
{
    internal static class MapperExtensions
    {
        public static BookListItemDTO ToListItemDTO(this Book book)
        {
            return new BookListItemDTO
            {
                Id = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                PublicationYear = book.PublicationYear,
                Publisher = book.Publisher,
                Language = book.Language,
                Authors = book.ToOrderedAuthorSummaries(),
                Categories = book.ToOrderedCategorySummaries(),
            };
        }
    }
}
