using Server.DatabaseContext;
using MediatR;

namespace Server.CQRS.Queries.Cinema
{
    public class GetCinemaById
    {
        // <summary>
        ///Data to execute
        /// </summary>
        public record Query(int id) : IRequest<Response>;

        // Handler
        public class Handler : IRequestHandler<Query, Response>
        {

            MovieDbContext movieDbContext;
            public Handler(MovieDbContext movieDbContext)
            {
                this.movieDbContext = movieDbContext;
            }

            /// <summary>
            /// Handle All business logic. get Cinema by ID
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<Response>? Handle(Query request, CancellationToken cancellationToken)
            {

                var output = (from C in movieDbContext.Cinema where C.Id == request.id
                              select C).FirstOrDefault();

                return new Response(Cinema: output) ?? null;
            }
        }

        /// <summary>
        /// Return All Cinemas
        /// </summary>
        /// <param name="Cinema"></param>

        public record Response(Cinetown.Shared.Cinema Cinema);
    }
}
