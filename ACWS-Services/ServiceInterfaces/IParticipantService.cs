using ACWS_Data.Models;

namespace ACWS_Services.ServiceInterfaces
{
    public interface IParticipantService
    {
         Participant GetParticipantEmail(int id);
         Participant CreateParticipant(string firstName, string lastName, string email);
    }
}