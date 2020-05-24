using System.Collections.Generic;
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
        
         public async Task<IEnumerable<PrizePool>> GetPrizePools()
         {
             return await _context.PrizePools
             .Include(p => p.Prizes)
                .ThenInclude(p => p.Product)
             .ToListAsync();
         }
    }
}