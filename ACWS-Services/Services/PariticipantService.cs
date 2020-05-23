using System.Threading.Tasks;
using ACWS_Services.ServiceInterfaces;
using ACWS_Data.Models;

namespace ACWS_Services.Services
{
    public class PariticipantService : IParticipantService
    {
        public async Task<Participant> CreateParticipant(string firstName, string lastName, string email){
            return new Participant();
        }
    }
}