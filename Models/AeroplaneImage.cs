using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationApp.Models
{
    [Table("AeroplaneImages")]
    public class AeroplaneImage
    {
        [Key]
        public int ImageID { get; set; }
        public string? ImageData { get; set; }
        public int AeroplaneId { get; set; }
        public Aeroplane? Aeroplane { get; set; }
        public virtual ICollection<Aeroplane> Aeroplanes { get; set; } = new List<Aeroplane>();
    }
}
