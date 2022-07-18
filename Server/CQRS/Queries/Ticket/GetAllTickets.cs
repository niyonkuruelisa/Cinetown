using Server.DatabaseContext;
using MediatR;

namespace Server.CQRS.Queries.Ticket
{
    public class GetAllTickets
    {
        /// <summary>
        ///Data to execute
        /// </summary>
        public record Query() : IRequest<Response>;

        // Handler
        public class Handler : IRequestHandler<Query, Response>
        {

            MovieDbContext movieDbContext;
            public Handler(MovieDbContext movieDbContext)
            {
                this.movieDbContext = movieDbContext;
            }

            /// <summary>
            /// Handle All business logic. Get Movie And It's assiated Days And Time.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<Response>? Handle(Query request, CancellationToken cancellationToken)
            {

                var output = (from T in movieDbContext.Ticket
                              select T).ToList();

                return new Response(output) ?? null;
            }
        }

        /// <summary>
        /// Return All Movies
        /// </summary>
        /// <param name="Tickets"></param>

        public record Response(List<Cinetown.Shared.Ticket> Tickets);
    }
}
