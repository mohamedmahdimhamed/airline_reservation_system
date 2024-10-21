using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationApp.Models
{
    [Table("Aeroplanes")]
    public class Aeroplane
    {
        [Key]
        public int PlaneID { get; set; }
        public string AeroplaneName { get; set; }
        public int SeatingCapacity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float Price { get; set; }
        public string? Image { get; set; }

        public int? AirlineCompanyId { get; set; }
        
        public virtual AirlineCompany? AirlineCompanyNavigationKey { get; set; }
        public virtual ICollection<AeroplaneImage> AeroplaneImages { get; set; } = new List<AeroplaneImage>();
        public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }


    

}