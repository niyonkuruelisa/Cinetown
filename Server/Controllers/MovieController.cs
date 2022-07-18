using Server.CQRS.Queries.Cinema;
using Server.CQRS.Queries.Movie;
using Server.DatabaseContext;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinetown.Shared;

namespace Server.Controllers
{
    [ApiController]
    [Route("Movie")]
    public class MovieController : ControllerBase
    {
        private IMediator mediator;
        public MovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: MovieController / Get all Movies
        [HttpGet("All")]
        public async Task<List<Movie>> GetAllMoviesAsync()
        {

            var response = await mediator.Send(new GetAllMovies.Query());

            return response.Movies;
        }
        // GET: MovieController / Get Movie By Cinema ID
        [HttpGet]
        public async Task<List<Movie>> IndexAsync(int cinemaId)
        {

            var response = await mediator.Send(new GetAllMoviesByCinemaId.Query(cinemaId));

            return response.Movies;
        }
        // GET: MovieController/Details/5
        [HttpGet("Details/{movieId}")]
        public async Task<ActionResult> Details(int movieId)
        {
            
            try
            {
                var response = await mediator.Send(new GetMovieById.Query(movieId));
                var movie = response.Movie;
                return Ok(movie);
            }
            catch (Exception e)
            {

                return NotFound("error: " + e.Message);
            }

        }
    }
}
