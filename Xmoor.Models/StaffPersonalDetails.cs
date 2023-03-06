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
        [MaxLength(20)]
        public string NationalInsuranceNumber{ get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [DisplayName("First Name")]
        [MaxLength(20)]
        public string FirstName { get; set; } = string.Empty;

        [DisplayName("Other Forenames")]
        [MaxLength(100)]
        public string? OtherForeNames { get; set; } = string.Empty;

        [Required]
        [DisplayName("Surname/Last name")]
        [MaxLength(30)]
        public string surname { get; set; } = string.Empty;

        [Required]
        [DisplayName("Initials")]
        [MaxLength(10)]
        public string? Initials { get; set; } = string.Empty; //Only needed if all full names are unknows

        [Required]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateOnly  DateOfBirth { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string StreetAddress { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [DisplayName("Foreign Country")]
        public string Country { get; set; } = string.Empty;

        [Required]
        [DisplayName("Postal Code")]
        [MaxLength(20)]
        [DataType(DataType.PostalCode)]
        //[RegularExpression("^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\\s?[0-9][A-Za-z]{2})", ErrorMessage ="Invalid Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [DisplayName("Moblile Number")]
        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; } = string.Empty;

        [DisplayName("Home Number")]
        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string? HomeNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(60)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
    }

}
