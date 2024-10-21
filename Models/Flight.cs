using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationApp.Models
{
    [Table("Flights")]
    public class Flight
    {
        [Key]

        public int FlightId { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public int? PlaneID { get; set; }
        public string AircraftType { get; set; }
        public int? SeatingCapacity { get; set; }
        public int? AvailableSeats { get; set; }

        [Required]
        public string Status { get; set; }
        public virtual Aeroplane Aeroplane { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
       
    }
}