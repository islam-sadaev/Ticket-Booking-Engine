using TicketBooking.Data.Repositories;
using TicketBooking.Models;

namespace TicketBooking.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Event> Events { get; }
        IGenericRepository<Ticket> Tickets { get; }

        Task Complete();

    }
}
