using System.Collections.Generic;
using System.Reflection.Emit;
namespace ACWS_ClassLib.Models
{
    public class SerialNumber
    {
        public int SerialNumberID { get; set; }
        public int ParticipantID { get; set; }
        public string SerialKey { get; set; }

        public Participant Participant { get; set; }
        public ICollection<PoolEntry> PoolEntries { get; set; }
    }
}