using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("National Insurance Number")]
        public string NationalInsuranceNumber{ get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Other Forenames")]
        public string? OtherForeNames { get; set; }

        [Required]
        [DisplayName("Surname/Last name")]
        public string surname { get; set; }

        [Required]
        [DisplayName("Initials")]
        public string? Initials { get; set; } //Only needed if all full names are unknows

        [Required]
        [DisplayName("Date of Birth")]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }


        [DisplayName("Foreign Country")]
        public string ForeignCountry { get; set; }

        [Required]
        [DisplayName("Moblile Number")]
        public string MobileNumber { get; set; }

        [DisplayName("Home Number")]
        public string? HomeNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string? folder { get; set; }

    }

}
