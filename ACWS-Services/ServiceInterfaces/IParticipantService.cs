using System.Threading.Tasks;
using ACWS_Data.Models;

namespace ACWS_Services.ServiceInterfaces
{
    public interface IParticipantService
    {
         Task<Participant> CreateParticipant(string firstName, string lastName, string email);
         Task<Participant> GetParticipant(string email, string serialNumber);
         Task<int> GetUnusedEntries(int participantID);
    }
}