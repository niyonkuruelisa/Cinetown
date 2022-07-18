using Server.CQRS.Queries.Seat;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cinetown.Shared;

namespace Server.Controllers
{
    public class SeatController : Controller
    {
        private IMediator mediator;

        public SeatController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: TicketController
        [HttpGet("Seat/All")]
        public async Task<List<Seat>> Index(int cinemaId, int movieId,string day,string time)
        {
            var response = await mediator.Send(new GetAllSeats.Query(cinemaId,movieId,day,time));
            List<Seat> result = response.Seats;
            return result;
        }
    }
}