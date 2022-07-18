using Server.CQRS.Queries.Ticket;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cinetown.Shared;

namespace Server.Controllers
{
    public class TicketController
    {
        private IMediator mediator;

        public TicketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: TicketController
        [HttpGet("Ticket/All")]
        public async Task<List<Ticket>> Index()
        {
            var response = await mediator.Send(new GetAllTickets.Query());
            List<Ticket> result = response.Tickets;
            return result;
        }
    }
}
