using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACWS_Data.Models
{
    public class Participant
    {
        public int ParticipantID { get; set; }

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
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool ToSPP { get; set; }

        public ICollection<SerialNumber> SerialNumbers { get; set; }
    }
}