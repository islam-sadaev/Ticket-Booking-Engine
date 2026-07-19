using TicketBooking.Data.Repositories;
using TicketBooking.Models;

namespace TicketBooking.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private IGenericRepository<Event> _eventRepository;
        private IGenericRepository<Ticket> _ticketRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IGenericRepository<Event> Events =>
            _eventRepository ??= new GenericRepository<Event>(_appDbContext);

        public IGenericRepository<Ticket> Tickets =>
            _ticketRepository ??= new GenericRepository<Ticket>(_appDbContext);



        public async Task Complete()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }

}
