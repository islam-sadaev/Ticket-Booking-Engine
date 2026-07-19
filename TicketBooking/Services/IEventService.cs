using Microsoft.AspNetCore.Mvc;
using TicketBooking.DTOs.Events;
using TicketBooking.Models;

namespace TicketBooking.Services
{
    public interface IEventService
    {

        ActionResult<List<Event>> GetAllEvents();
        Task<BookEventDto> BookEventAsync(int eventId, BookEventDto dto);

    }
}
