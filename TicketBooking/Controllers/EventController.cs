using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
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
        public async Task<List<Event>> GetAllEvents()
        {
            return await _eventService.GetAllEventsAsync();

        }

        [HttpPost("{eventId}/book")]
        public async Task<IActionResult> BookResult(int eventId, [FromBody] BookEventDto dto)
        {
            try
            {
                var result = await _eventService.BookEventAsync(eventId, dto);
                return Ok(result);
            }
            catch (DbUpdateConcurrencyException) // De specifieke Entity Framework concurrency fout
            {
                // Status 409 Conflict 
                return Conflict(new { message = "Dit ticket is zojuist door iemand anders geboekt. Probeer het opnieuw." });
            }
            catch (ArgumentException ex) // Voor validatiefouten in de service (te veel tickets, etc.)
            {
                // Status 400 Bad Request
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception) // De absolute fallback voor als de server ECHT crasht
            {
                // Status 500 Internal Server Error
                return StatusCode(500, new { message = "Er is een onverwachte fout opgetreden op de server." });
            }
        }

    }
}
