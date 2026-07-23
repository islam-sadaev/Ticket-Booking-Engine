using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Data;
using TicketBooking.Data.UnitOfWork;
using TicketBooking.DTOs.Events;
using TicketBooking.Models;
using TicketBooking.Data.Repositories;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace TicketBooking.Services
{
    public class EventService:IEventService
    {

        private AppDbContext _appDbContext;
        private IUnitOfWork _uow;
        private IMapper _mapper;
        public EventService(AppDbContext appDbContext, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _uow = unitOfWork;
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            List<Event> events = await _appDbContext.Events.ToListAsync();

            return events;

        }

        public async Task<BookEventDto> BookEventAsync(int eventId,BookEventDto dto )
        {
     
            Event evenement = await _uow.Events.GetByIdAsync(eventId);
            int amount = dto.quantity;


            if (amount > evenement.AvailableTickets)
            {
                throw new Exception($"Er zijn nog maar {evenement.AvailableTickets} beschikbaar.");
            }
            if (amount > 4 || amount < 1)
            {
                throw new Exception("Je moet minimaal 1 ticket en mag maximaal 4 tickets bestellen.");
            }

            try
            {
                for (int i = 0; i < amount; i++)
                {
                    Ticket ticket = _mapper.Map<Ticket>(dto);

                    ticket.EventId = eventId;
                    ticket.PurchaseDateUtc = DateTime.UtcNow;
                    ticket.CustomerEmail = dto.email;

                    await _uow.Tickets.AddAsync(ticket);
                    evenement.AvailableTickets -= 1;

                }

                await _uow.Complete();
                return dto;
            }

            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("De tickets zijn uitverkocht. ");
            }
            

            
            
        }

    }
}
