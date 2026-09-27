using Microsoft.Extensions.DependencyInjection;
using sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorById;
using sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorsList;
using sb.api.Library.Application.UseCases.Books.Queries.GetBookById;
using sb.api.Library.Application.UseCases.Books.Queries.GetBooksList;
using sb.api.Library.Application.UseCases.Categories.Queries.GetCategoriesList;
using sb.api.Library.Application.UseCases.Categories.Queries.GetCategoryById;
using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Application.Utilities.Pagination;

namespace sb.api.Library.Application
{
    public static class ApplicationServicesRegistry
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMediator, SimpleMediator>();

            services.AddScoped<IRequestHandler<GetBooksListQuery, PaginationResponse<BookListItemDTO>>, GetBooksListUseCase>();
            services.AddScoped<IRequestHandler<GetBookByIdQuery, BookDetailDTO?>, GetBookByIdUseCase>();
            services.AddScoped<IRequestHandler<GetAuthorsListQuery, PaginationResponse<AuthorListItemDTO>>, GetAuthorsListUseCase>();
            services.AddScoped<IRequestHandler<GetAuthorByIdQuery, AuthorDetailDTO?>, GetAuthorByIdUseCase>();
            services.AddScoped<IRequestHandler<GetCategoriesListQuery, PaginationResponse<CategoryListItemDTO>>, GetCategoriesListUseCase>();
            services.AddScoped<IRequestHandler<GetCategoryByIdQuery, CategoryDetailDTO?>, GetCategoryByIdUseCase>();

            return services;
        }
    }
}
