using AutoMapper;
using TicketBooking.DTOs.Events;
using TicketBooking.Models;
namespace TicketBooking.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Event, BookEventDto>();     
        }
    }
}
