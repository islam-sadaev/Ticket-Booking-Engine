using Microsoft.AspNetCore.Mvc;
using TicketBooking.Data;
using TicketBooking.Models;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        


        [HttpGet]
        public ActionResult<List<Event>> GetAllEvents()
        {
            List<Event> events= _appDbContext.Events.ToList();

            return events;

        }

    }
}
