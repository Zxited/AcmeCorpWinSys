using System.Collections.Generic;
namespace ACWS_ClassLib.Models
{
    public class Participant
    {
        public int ParticipantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<SerialNumber> SerialNumbers { get; set; }
    }
}