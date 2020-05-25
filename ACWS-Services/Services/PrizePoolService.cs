using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ACWS_Data;
using ACWS_Data.Models;
using ACWS_Services.ServiceInterfaces;

namespace ACWS_Services.Services
{
    public class PrizePoolService : IPrizePoolService
    {
        private ApplicationDbContext _context;

        public PrizePoolService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PrizePool> GetPrizePoolByID(int prizePoolID)
         {
             return await _context.PrizePools
                .Include(p => p.PoolEntries)
                .FirstOrDefaultAsync(p => p.PrizePoolID == prizePoolID);
         }
        
         public async Task<IEnumerable<PrizePool>> GetPrizePools()
         {
             return await _context.PrizePools
             .Include(p => p.Prizes)
                .ThenInclude(p => p.Product)
             .ToListAsync();
         }

         public async Task<int> GetParticipantEntriesInPool(int prizePoolID, int participantID)
         {
             var prizePool = await GetPrizePoolByID(prizePoolID);

             var serialNumbers = await _context.SerialNumbers
                .Include(s => s.PoolEntries)
                .Where(s => s.ParticipantID == participantID)
                .ToListAsync();

            int result = 0;
            foreach (var serialNumber in serialNumbers)
            {
                result += serialNumber.PoolEntries.Count(p => p.PrizePoolID == prizePoolID);
            }

             return result;
         }
    }
}