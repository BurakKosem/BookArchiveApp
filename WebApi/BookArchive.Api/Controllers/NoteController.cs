using BookArchive.Application.Features.NoteFeatures.Commands.CreateNote;
using BookArchive.Application.Features.NoteFeatures.Commands.DeleteNote;
using BookArchive.Application.Features.NoteFeatures.Commands.UpdateNote;
using BookArchive.Application.Features.NoteFeatures.Queries.GetAllNotesByBookId;
using BookArchive.Application.Features.NoteFeatures.Queries.GetAllNotesByPrivacy;
using BookArchive.Application.Features.NoteFeatures.Queries.GetAllNotesByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookArchive.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotesByBookId([FromQuery] GetAllNotesByBookIdRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotesByUserId([FromQuery] GetAllNotesByUserIdRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotesByPrivacy([FromQuery] GetAllNotesByPrivacyRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost] 
        public async Task<IActionResult> CreateNote(CreateNoteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNote(UpdateNoteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNote(DeleteNoteRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}
