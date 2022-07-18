using Server.DatabaseContext;
using MediatR;
using Cinetown.Shared;

namespace Server.CQRS.Commands.Cinema
{
    public static class CreateMovies
    {
        /// <summary>
        ///Data to execute
        /// </summary>
        public record Command(List<Cinetown.Shared.Movie> Movies) : IRequest<Response>;

        public class Handler : IRequestHandler<Command, Response>
        {
            MovieDbContext _movieDbContext;
            public Handler(MovieDbContext movieDbContext)
            {
                _movieDbContext = movieDbContext;
            }

            /// <summary>
            /// Handle All business logic. Get Movie And It's assiated Days And Time.
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                //Save movie first
                _movieDbContext.Movie.AddRange(request.Movies.Where(x => !_movieDbContext.Movie.Any(y => y.Id == x.Id)));
                _movieDbContext.SaveChanges();

                // Allocate all movies to all cinemas
                List<Cinetown.Shared.Movie> movies = (from M in _movieDbContext.Movie select M).ToList();
                List<Cinetown.Shared.Cinema> cinemas = (from C in _movieDbContext.Cinema select C).ToList();
                foreach (var movie in movies)
                {
                    foreach(var cinema in cinemas)
                    {
                        if (!_movieDbContext.MovieCinema.Any(c => c.Movie == movie && c.Cinema == cinema))
                        {
                            _movieDbContext.MovieCinema.Add(new MovieCinema { Cinema = cinema,Movie = movie});
                        }
                        
                    }
                }
                _movieDbContext.SaveChanges();
                return new Response(true);
            }
        }
        /// <summary>
        /// Return true
        /// </summary>
        /// <param name="saved"></param>
        public record Response(bool saved);

    }
}
