using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Catalog.Dtos
{
    internal static class CatalogMapperExtensions
    {
        public static AuthorSummaryDTO ToAuthorSummaryDTO(this Author author)
        {
            return new AuthorSummaryDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
            };
        }

        public static CategorySummaryDTO ToCategorySummaryDTO(this Category category)
        {
            return new CategorySummaryDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public static BookSummaryDTO ToBookSummaryDTO(this Book book)
        {
            return new BookSummaryDTO
            {
                Id = book.Id,
                Title = book.Title,
                PublicationYear = book.PublicationYear,
            };
        }

        public static List<AuthorSummaryDTO> ToOrderedAuthorSummaries(this Book book)
        {
            if (book.BookAuthors.Count > 0)
            {
                return book.BookAuthors
                    .OrderBy(ba => ba.DisplayOrder)
                    .Select(ba => ba.Author.ToAuthorSummaryDTO())
                    .ToList();
            }

            return book.Authors
                .Select(a => a.ToAuthorSummaryDTO())
                .ToList();
        }

        public static List<CategorySummaryDTO> ToOrderedCategorySummaries(this Book book)
        {
            return book.Categories
                .OrderBy(c => c.Name)
                .Select(c => c.ToCategorySummaryDTO())
                .ToList();
        }

        public static List<BookSummaryDTO> ToOrderedBookSummaries(this IEnumerable<Book> books)
        {
            return books
                .OrderBy(b => b.Title)
                .Select(b => b.ToBookSummaryDTO())
                .ToList();
        }
    }
}
