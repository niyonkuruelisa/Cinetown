using Server.CQRS.Commands.Cinema;
using Server.CQRS.Queries.Cinema;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cinetown.Shared;

namespace Server.Controllers
{
    
    [ApiController]
    [Route("Cinema")]
    public class CinemaController : ControllerBase
    {
        private IMediator mediator;
        public CinemaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: CinemaController
        [HttpGet("All")]
        public async Task<List<Cinema>> IndexAsync()
        {
            var response = await mediator.Send(new GetAllCinema.Query());

            return response.Cinemas;
        }
        // GET: CinemaController
        [HttpGet]
        public async Task<Cinema> getCinemaByID(string id)
        {
            var response = await mediator.Send(new GetCinemaById.Query(int.Parse(id)));

            return response.Cinema;
        }

        // POST: CinemaController/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] List<Movie> movies)
        {

            try
            {

                var response = await mediator.Send(new CreateMovies.Command(movies));

                return Ok(response.saved);
            }
            catch
            {
                return NotFound("Can't save Movies...");
            }
        }
    }
}
