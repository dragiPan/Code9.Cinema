using Code9.API.Models;
using Code9.Domain.Commands;
using Code9.Domain.Models;
using Code9.Domain.Queries;
using Code9Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Code9.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : Controller
    {
        private readonly IMediator _mediator;
        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cinema>>> GetAllCinemas() 
        {
            var cinemas = await _mediator.Send(new GetAllCinemaQuery());
            return Ok(cinemas);
        }

        [HttpPost]
        public async Task<ActionResult<Cinema>> AddCinema(AddCinemaRequest addCinemaRequest)
        {
            var cinemas = await _mediator.Send(new AddCinemaCommand()
            {
                Name = addCinemaRequest.Name,
                City = addCinemaRequest.City,
                Street = addCinemaRequest.Street,
                NumberofAuditoriums = addCinemaRequest.NumberofAuditoriums
            });
            return Created();
        }

        [HttpPut]
        public async Task<ActionResult<Cinema>> UpdateCinema(Guid id, UpdateCinemaRequest updateCinemaRequest)
        {
            var cinema = new UpdateCinemaCommand
            {
                CinemaId = id,
                Name = updateCinemaRequest.Name,
                City = updateCinemaRequest.City,
                Street = updateCinemaRequest.Street,
                NumberofAuditoriums = updateCinemaRequest.NumberofAuditoriums
            };

            var result = await _mediator.Send(cinema);
            if (result == null) 
            {
                return NotFound("No cinema found with ID {id}");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinema(int id)
        {
            var result = await _mediator.Send(new DeleteCinemaCommand(id));
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
