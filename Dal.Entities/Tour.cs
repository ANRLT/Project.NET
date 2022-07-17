namespace Dal.Entities;

public class Tour : BaseEntity
{
    public string Name { get; set; }
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int TourTypeId { get; set; }
    public virtual TourType TourType { get; set; }
    public int TransportId { get; set; }
    public virtual Transport Transport { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }

}