using sb.api.Library.Application.UseCases.Catalog.Dtos;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Categories.Queries.GetCategoriesList
{
    internal static class MapperExtensions
    {
        public static CategoryListItemDTO ToListItemDTO(this Category category)
        {
            return new CategoryListItemDTO
            {
                Id = category.Id,
                Name = category.Name,
                Books = category.Books.ToOrderedBookSummaries(),
            };
        }
    }
}
