namespace TicketBooking.Models
{
    public class Ticket
    {
        public Guid Id { get; set; } // Primary Key
        public int EventId { get; set; } // Foreign Key
        public string CustomerEmail { get; set; }
        public DateTime PurchaseDateUtc { get; set; }

        public Event Event { get; set; }
    }
}
