using Microsoft.AspNetCore.Mvc;
using TicketBooking.Data;
using TicketBooking.DTOs.Events;
using TicketBooking.Models;
using TicketBooking.Services;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }


        [HttpGet]
        public ActionResult<List<Event>> GetAllEvents()
        {
            return _eventService.GetAllEvents();

        }

        [HttpPost("{id}")]
        public Task BookResult(int id, BookEventDto dto)
        {
            return _eventService.BookEventAsync(id,dto);
        }
    }
}
