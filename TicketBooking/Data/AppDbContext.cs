using Microsoft.EntityFrameworkCore;
using TicketBooking.Models;

namespace TicketBooking.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> BookEventDto { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>(entity =>
                {
                    entity.HasKey(t => t.Id);

                    entity.HasOne(t => t.Event)
                    .WithMany(e => e.Tickets)
                    .HasForeignKey(t => t.EventId);
                });

            modelBuilder.Entity<Event>().HasKey(e=>e.Id);

            modelBuilder.Entity<Event>().Property(v => v.RowVersion).IsRowVersion();





        }
    }
}
