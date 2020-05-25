using System;
using System.Threading.Tasks;
using ACWS_Data.Models;

namespace ACWS_Services.ServiceInterfaces
{
    public interface IParticipantService
    {
         Task<Participant> CreateParticipant(string firstName, string lastName, string email, DateTime dateOfBirth, bool toSPP);
         Task<Participant> GetParticipantByEmail(string email);
         Task<Participant> GetParticipantByID(int participantID);
         Task<Participant> ParticipantAuthentication(string email, string serialNumber);
         Task<int> GetEntriesLeft(int participantID);
         Task<bool> UseEntry(int prizePoolID, int participantID);
    }
}