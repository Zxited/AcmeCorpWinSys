using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACWS_Data.Models;

namespace ACWS_Services.ServiceInterfaces
{
    public interface IPrizePoolService
    {
        Task<PrizePool> GetPrizePoolByID(int prizePoolID);
         Task<IEnumerable<PrizePool>> GetPrizePools();
         Task<int> GetParticipantEntriesInPool(int prizePoolID, int participantID);
         Task<IEnumerable<PrizePool>> GetAllPrizePoolWithParticipants();
    }
}