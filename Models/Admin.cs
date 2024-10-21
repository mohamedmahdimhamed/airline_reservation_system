using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AirlineReservationApp.Models
{
    [Table("Admins")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        //First Name

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "Name")]
        [MinLength(3, ErrorMessage = "Min 3 characters allowed"), MaxLength(30, ErrorMessage = "Max 30 characters")]
        public string AdminName { get; set; }

        //Email

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string AdminMail { get; set; }

        //Role
        [Required(ErrorMessage = "Role is required"),Range(0, 1)]
        public int Role { get; set; }

        //Password

        [Required(ErrorMessage = "Password is required"), MinLength(8), MaxLength(20), DataType(DataType.Password), RegularExpression(@"^([a-zA-Z0-9\.\*]+)$", ErrorMessage = "Must be alpha-numeric")]
        public string Password { get; set; }


        //Confirm Password

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not matched ")]
        [MinLength(8, ErrorMessage = "Min 8 characters allowed"), MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string CPassword { get; set; }
      
    }
}
