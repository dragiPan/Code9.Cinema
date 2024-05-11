using Code9.API.Models;
using Code9.Domain.Commands;
using Code9.Domain.Models;
using Code9.Domain.Queries;
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
    }
}
