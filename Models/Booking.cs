using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AirlineReservationApp.Models
{
    [Table("Boookings")]
    public class Booking

    {
        [Key]
        public int BookingId { get; set; }

        public int UserId { get; set; }

        public int Passport { get; set; }

        public int FligthId { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal TicketPrice { get; set; }
        public string Status { get; set; }

        public virtual User User { get; set; }
        public virtual Flight Flight { get; set; }


    }
}