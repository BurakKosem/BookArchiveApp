using BookArchive.Application.Features.BookFeatures.Commands.CreateBook;
using BookArchive.Application.Features.BookFeatures.Commands.DeleteBook;
using BookArchive.Application.Features.BookFeatures.Commands.UpdateBook;
using BookArchive.Application.Features.BookFeatures.Queries.GetAllBooks;
using BookArchive.Application.Features.BookFeatures.Queries.GetBookByName;
using BookArchive.Application.Features.BookFeatures.Queries.GetBooksByAuthor;
using BookArchive.Application.Features.BookFeatures.Queries.GetBooksByShelf;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookArchive.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(UpdateBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(DeleteBookRequest request)
        {

            await _mediator.Send(request);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await _mediator.Send(new GetAllBooksRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksByAuthor([FromQuery] GetBooksByAuthorRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookByName([FromQuery] GetBookByNameRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookByShelf([FromQuery] GetBookByShelfRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
