using Microsoft.AspNetCore.Mvc;
using TicketBooking.DTOs.Events;
using TicketBooking.Models;

namespace TicketBooking.Services
{
    public interface IEventService
    {

        Task<List<Event>> GetAllEventsAsync();
        Task<BookEventDto> BookEventAsync(int eventId, BookEventDto dto);

    }
}
