using Server.DatabaseContext;
using MediatR;

namespace Server.CQRS.Queries.Movie
{
    public static class GetAllMoviesByCinemaId
    {


        /// <summary>
        ///Data to execute
        /// </summary>
        public record Query(int cinemaID) : IRequest<Response>;

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
                var cinema = (from C in movieDbContext.Cinema where C.Id == request.cinemaID select C).FirstOrDefault();
                
                var output = (from M in movieDbContext.Movie
                              join R in movieDbContext.RunningTimes
                              on M.RunningTimes.Id equals R.Id
                              join CM in movieDbContext.MovieCinema on
                              M equals CM.Movie
                              where CM.Cinema == cinema
                              select new Cinetown.Shared.Movie
                              {
                                  Id = M.Id,
                                  Title = M.Title,
                                  Director = M.Director,
                                  Cast = M.Cast,
                                  Genre = M.Genre,
                                  Notes = M.Notes,
                                  Year = M.Year,
                                  RunningTimes = R,
                              }).ToList();

                return new Response(Movies: output) ?? null;
            }
        }

        /// <summary>
        /// Return All Movies
        /// </summary>
        /// <param name="Movies"></param>
        
        public record Response(List<Cinetown.Shared.Movie> Movies);
    }
}

