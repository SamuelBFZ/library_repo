using sb.api.Library.Application.UseCases.Catalog.Dtos;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Books.Queries.GetBookById
{
    internal static class MapperExtensions
    {
        public static BookDetailDTO ToDetailDTO(this Book book)
        {
            return new BookDetailDTO
            {
                Id = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                PublicationYear = book.PublicationYear,
                Publisher = book.Publisher,
                Language = book.Language,
                Synopsis = book.Synopsis,
                Authors = book.ToOrderedAuthorSummaries(),
                Categories = book.ToOrderedCategorySummaries(),
            };
        }
    }
}
