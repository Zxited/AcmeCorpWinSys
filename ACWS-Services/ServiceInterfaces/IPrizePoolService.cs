using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACWS_Data.Models;

namespace ACWS_Services.ServiceInterfaces
{
    public interface IPrizePoolService
    {
         Task<IEnumerable<PrizePool>> GetPrizePools();
    }
}