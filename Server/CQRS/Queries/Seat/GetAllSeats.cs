using Server.DatabaseContext;
using MediatR;

namespace Server.CQRS.Queries.Seat
{
    public class GetAllSeats
    {        /// <summary>
             ///Data to execute
             /// </summary>
        public record Query(int cinemaId,int movieId,string day,string time) : IRequest<Response>;

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
                List<Cinetown.Shared.Seat> seats = new List<Cinetown.Shared.Seat>();
                var output = movieDbContext.Booking.Where(item => item.CinemaId == request.cinemaId &&  item.MovieId == request.movieId && item.Day == request.day && item.Time == request.time).Select(item => item.seats);
                foreach(var seat in output)
                {
                    seats.AddRange(seat);
                }
                return new Response(Seats: seats) ?? null;
            }
        }

        /// <summary>
        /// Return All Movies
        /// </summary>
        /// <param name="Tickets"></param>

        public record Response(List<Cinetown.Shared.Seat> Seats);
    }
}
