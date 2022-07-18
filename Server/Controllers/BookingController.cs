using Server.CQRS.Commands.Booking;
using Server.CQRS.Queries.Booking;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cinetown.Shared;

namespace Server.Controllers
{
    public class BookingController : Controller
    {
        IMediator mediator;
        public BookingController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // get bookings by cinema and movie Ids
        [Route("Booking/Cinema/")]
        [HttpGet]
        public async Task<List<Booking>> GetAllBooKingsByMovie(int cinemaID, int? movieId, string day, string time)
        {
            Console.WriteLine("From Controller");
            try
            {
                //Save Booking
                var response = await mediator.Send(new GetAllBooKingsByCinemaMovie.Query(cinemaID, movieId, day, time));

                return response.Bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpGet("Booking")]
        public async Task<List<Booking>> GetAllBooKingsByMovie(int? movieId,string day,string time)
        {

            try
            {
                //Save Booking
                var response = await mediator.Send(new GetAllBooKingsByMovie.Query(movieId, day, time));

                return response.Bookings;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpPost("Booking")]
        public async Task<bool> create([FromBody] Booking booking)
        {

             try
            {

                //Save Booking
                var response = await mediator.Send(new CreateBooking.Command(booking));

                return response.Saved;
            }
            catch  (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
