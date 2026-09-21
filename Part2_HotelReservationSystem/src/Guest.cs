namespace Part2_HotelReservationSystem;

public class Guest
{
    public int Id { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }
    
    private List<Reservation> _reservations;
    public IReadOnlyList<Reservation> Reservations => _reservations;
    
    public Guest(int id, string fullName, string phoneNumber)
    {
        Id = id;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }
}