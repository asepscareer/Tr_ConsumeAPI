using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_M_Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only alphabet is allowed.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }
        [Display(Name = "Join Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        public DateTime JoinDate { get; set; }
        public int Salary { get; set; }
    }
}