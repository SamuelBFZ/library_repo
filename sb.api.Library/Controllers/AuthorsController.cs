using Microsoft.AspNetCore.Mvc;
using sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorById;
using sb.api.Library.Application.UseCases.Authors.Queries.GetAuthorsList;
using sb.api.Library.Application.Utilities.Mediator;
using sb.api.Library.Application.Utilities.Pagination;

namespace sb.api.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = PaginationRequest.DEFAULT_PAGE_SIZE,
            [FromQuery] string? search = null)
        {
            GetAuthorsListQuery query = new()
            {
                Pagination = new PaginationRequest(pageNumber, pageSize),
                Search = search
            };

            PaginationResponse<AuthorListItemDTO> result = await _mediator.Send(query);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            AuthorDetailDTO? result = await _mediator.Send(new GetAuthorByIdQuery { Id = id });

            if (result is null)
            {
                return NotFound();
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
