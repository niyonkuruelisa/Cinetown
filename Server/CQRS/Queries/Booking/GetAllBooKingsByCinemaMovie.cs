using Server.DatabaseContext;
using MediatR;

namespace Server.CQRS.Queries.Booking
{
    public class GetAllBooKingsByCinemaMovie
    {
        /// <summary>
        ///Data to execute
        /// </summary>
        public record Query(int cinemaID,int? movieId,string day, string time) : IRequest<Response>;

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
                Console.WriteLine("Here => " + request.cinemaID);
                Console.WriteLine("Here => " + request.cinemaID);
                Console.WriteLine("Here => " + request.cinemaID);
                Console.WriteLine("Here => " + request.cinemaID);
                Console.WriteLine("Here => " + request.cinemaID);
                var output = (from B in movieDbContext.Booking
                              
                              where B.MovieId == request.movieId
                              where B.CinemaId == request.cinemaID
                              && B.Day == request.day
                              && B.Time == request.time
                              select new Cinetown.Shared.Booking
                              {
                                Id = B.Id,
                                Name = B.Name,
                                Email = B.Email,
                                Day = B.Day,
                                Time = B.Time,
                                MovieId = B.MovieId,
                                CinemaId = B.CinemaId,
                                seats = B.seats,
                              }).ToList();

                return new Response(Bookings: output) ?? null;
            }
        }

        /// <summary>
        /// Return All Movies
        /// </summary>
        /// <param name="Movies"></param>

        public record Response(List<Cinetown.Shared.Booking> Bookings);
    }
}
