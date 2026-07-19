namespace TicketBooking.Models
{
 public class Event
{
    public int Id { get; set; } // Primary Key
    public string Name { get; set; }
    public DateTime EventDate { get; set; }
    public int TotalCapacity { get; set; }
    public int AvailableTickets { get; set; }
    
    public ICollection<Ticket> Tickets { get; set; }
    
    public byte[] RowVersion { get; set; }

    // CRITICAL FOR THE BOSS FIGHT: 
    // Research how to add a [Timestamp] or a Concurrency Token property here 
    // to prevent two users from buying the same ticket at the same time.
}
}
