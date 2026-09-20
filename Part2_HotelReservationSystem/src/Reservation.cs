namespace Part2_HotelReservationSystem;

public class Reservation
{
    public int Id { get; }
    public DateTimeOffset CheckInDate { get; }
    public DateTimeOffset CheckOutDate { get; }
    
    public ReservationStatus  Status { get; private set; }
    public Room Room { get; private set; }
    
    public Reservation(int id, DateTimeOffset checkInDate, DateTimeOffset checkOutDate, Room room)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        
        ArgumentNullException.ThrowIfNull(room);
        
        if(room.HasReservation(checkInDate, checkOutDate))
            throw new ArgumentException("Room already has a reservation.");
        
        if(room.IsUnderMaintenance)
            throw new ArgumentException("Room is under maintenance");
        
        if (!IsValidDate(checkInDate, checkOutDate))
            throw new ArgumentException("Check out date must be after check in date");
        
        Id = id;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        Room = room;
    }

    public decimal GetTotalCost()
    {
        int nights  = (CheckOutDate - CheckInDate).Days;
        return Room.NightlyRate * nights;
    }
    
    // Pending -> Confirm
    public void Confirm()
    {
        if (Status != ReservationStatus.Pending)
            throw new InvalidOperationException("Only pending reservations can be confirmed.");

        Status = ReservationStatus.Confirmed;
    }
    
    // Confirm -> Check in
    public void CheckIn()
    {
        if (Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException("Only confirmed reservations can be checked in.");
        
        Status = ReservationStatus.CheckedIn;
    }
    
    // Check in -> Check out
    public void CheckOut()
    {
        if (Status != ReservationStatus.CheckedIn)
            throw new InvalidOperationException("Only checked in reservations can be checked out.");
        
        Status = ReservationStatus.CheckedOut;
    }
    
    // only pending, confirmed -> canceled
    public void Cancel()
    {
        if (Status != ReservationStatus.Pending && Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException("Only pending or confirmed reservations can be cancelled.");
        
        Status = ReservationStatus.Cancelled;
    }

    private bool IsValidDate(DateTimeOffset checkInDate, DateTimeOffset checkOutDate)
        => checkInDate < checkOutDate;
}