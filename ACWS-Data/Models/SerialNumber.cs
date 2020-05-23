using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ACWS_Data.Models
{
    public class SerialNumber
    {
        public int SerialNumberID { get; set; }
        public int ParticipantID { get; set; }

        [Required]
        [StringLength(8)]
        public string SerialKey { get; set; }

        public Participant Participant { get; set; }
        public ICollection<PoolEntry> PoolEntries { get; set; }
    }
}