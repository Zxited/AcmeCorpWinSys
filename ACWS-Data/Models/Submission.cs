using System;
using System.ComponentModel.DataAnnotations;
namespace ACWS_Data.Models
{
    public class Submission
    {
        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(8)]
        public string SerialNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Required]
        public bool ToSPP { get; set; }
    }
}