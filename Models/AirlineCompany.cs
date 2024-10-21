using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineReservationApp.Models
{
    [Table("AirlineCompanies")]
    public class AirlineCompany
    {
        [Key]
        public int AirlineCompanyId { get; set; }

        public string? AirlineCompanyName { get; set; }
       
        public virtual ICollection<Aeroplane> Aeroplanes { get; set; } = new List<Aeroplane>();
    }
}
