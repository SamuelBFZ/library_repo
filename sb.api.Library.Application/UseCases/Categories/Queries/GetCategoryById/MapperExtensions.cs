using sb.api.Library.Application.UseCases.Catalog.Dtos;
using sb.api.Library.Domain.Entities;

namespace sb.api.Library.Application.UseCases.Categories.Queries.GetCategoryById
{
    internal static class MapperExtensions
    {
        public static CategoryDetailDTO ToDetailDTO(this Category category)
        {
            return new CategoryDetailDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Books = category.Books.ToOrderedBookSummaries(),
            };
        }
    }
}
