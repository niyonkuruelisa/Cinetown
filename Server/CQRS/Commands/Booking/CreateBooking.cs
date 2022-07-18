using Server.DatabaseContext;
using MediatR;
using System.Linq;

namespace Server.CQRS.Commands.Booking
{
    public class CreateBooking
    {
        // Data to execute
        public record Command(Cinetown.Shared.Booking Booking) : IRequest<Response>;
        // Handler
        public class Handler : IRequestHandler<Command, Response>
        {
            MovieDbContext movieDbContext;
            public Handler(MovieDbContext movieDbContext)
            {
                this.movieDbContext = movieDbContext;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                Console.WriteLine("Here => "+request.Booking.seats.Count);
                // Saving Booking to database;
                if (!movieDbContext.Booking.Any(b => b == request.Booking))
                {
                    movieDbContext.Booking.Add(request.Booking);
                    // Saving Seats to database;
                    movieDbContext.SaveChanges();
                }

                return new Response(true);
            }
        }

        // Response

        public record Response(bool Saved);
    }
}
