using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Models
{
    public class StaffPersonalDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NationalInsuranceNumber{ get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        
        public string? OtherForeNames { get; set; }
        [Required]
        public string surname { get; set; }
        
        public string? Initials { get; set; } //Only needed if all full names are unknows
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string ForeignCountry { get; set; }
        [Required]
        public string MobileNumber { get; set; }

        public string? HomeNumber { get; set; }
        [Required]
        public string Email { get; set; }

        public string? folder { get; set; }

    }

}
