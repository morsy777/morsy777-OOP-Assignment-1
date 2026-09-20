namespace Part2_HotelReservationSystem;

public class Room
{
    public int Number { get; }
    public RoomType RoomType { get; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }
    
    private readonly List<Reservation> _reservations = [];

    public IReadOnlyList<Reservation> Reservations => _reservations;

    public Room(int number, decimal nightlyRate, RoomType roomType)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number); 
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(nightlyRate); 
        
        Number = number;
        NightlyRate = nightlyRate;
        RoomType = roomType;
    }

    public bool HasReservation(DateTimeOffset checkInDate, DateTimeOffset checkOutDate)
    {
        bool hasReservation = false;
        foreach (var reservation in Reservations)
        {
            if (reservation.Status != ReservationStatus.Cancelled
                && reservation.Status != ReservationStatus.CheckedOut
                && reservation.CheckOutDate > checkInDate
                && reservation.CheckInDate < checkOutDate)
            {
                hasReservation = true;
                break;
            }
        }
        
        return hasReservation;
    }
    
    public void ChangeNightlyRate(decimal newRate)
    {
        if (newRate < 0)
            throw new ArgumentOutOfRangeException(nameof(newRate));

        NightlyRate = newRate;
    }
    
    public void StartMaintenance() 
        => IsUnderMaintenance = true;
    
    public void EndMaintenance()
        => IsUnderMaintenance = false;
}