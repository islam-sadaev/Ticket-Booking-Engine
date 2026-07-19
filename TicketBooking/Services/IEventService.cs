using TicketBooking.Models;

namespace TicketBooking.Services
{
    public interface IEventService
    {

        Task<IEnumerable<Event>> GetAllEventsAsync();

    }
}
