using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ACWS_Services.ServiceInterfaces;
using ACWS_Data;
using ACWS_Data.Models;

namespace ACWS_Services.Services
{
    public class PariticipantService : IParticipantService
    {
        private ApplicationDbContext _context;
        
        public PariticipantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Participant> CreateParticipant(string firstName, string lastName, string email){
            return new Participant();
        }

        public async Task<Participant> GetParticipant(string email, string serialNumber)
        {
            Participant participant = await _context.Participants
                .Include(p => p.SerialNumbers)
                .FirstOrDefaultAsync(p => p.Email == email);

            if (participant.SerialNumbers.Count(s => s.SerialKey == serialNumber) > 0)
            {
                return participant;
            }

            return new Participant();
        }
    }
}