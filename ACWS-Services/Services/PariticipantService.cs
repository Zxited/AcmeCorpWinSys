using System.Runtime.CompilerServices;
using System;
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

        public async Task<Participant> GetParticipantByID(int participantID)
        {
            Participant participant = await _context.Participants
                .Include(p => p.SerialNumbers)
                .FirstOrDefaultAsync(p => p.ParticipantID == participantID);

            if (participant != null)
            {
                return participant;
            }

            throw new Exception("Paticipant not found.");
        }

        public async Task<Participant> GetParticipantByEmail(string email)
        {
            Participant participant = await _context.Participants
                .Include(p => p.SerialNumbers)
                .FirstOrDefaultAsync(p => p.Email == email);

            if (participant != null)
            {
                return participant;
            }

            throw new Exception("Paticipant not found.");
        }

        public async Task<Participant> CreateParticipant(string firstName, string lastName, string email, DateTime dateOfBirth, bool toSPP)
        {
            try
            {
                var participant = await GetParticipantByEmail(email);
            }
            catch (Exception)
            {
                if (toSPP)
                {
                    var participant = new Participant
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        DateOfBirth = dateOfBirth,
                        ToSPP = toSPP
                    };

                    await _context.AddAsync(participant);
                    await _context.SaveChangesAsync();
                }
            }

            return await GetParticipantByEmail(email);
        }

        public async Task<Participant> ParticipantAuthentication(string email, string serialNumber)
        {
            Participant participant = await _context.Participants
                .Include(p => p.SerialNumbers)
                .FirstOrDefaultAsync(p => p.Email == email);

            if (participant.SerialNumbers.Count(s => s.SerialKey.ToUpper() == serialNumber.ToUpper()) == 1)
            {
                return participant;
            }

            throw new Exception("Paticipant not found.");
        }

        public async Task<int> GetEntriesLeft(int participantID)
        {
            var participant = await _context.Participants
                .Include(p => p.SerialNumbers)
                    .ThenInclude(s => s.PoolEntries)
                .FirstOrDefaultAsync(p => p.ParticipantID == participantID);
            
            int total = participant.SerialNumbers.Count() * 2;

            foreach (var serialNumber in participant.SerialNumbers)
            {
                total -= serialNumber.PoolEntries.Count();
            }

            return total;
        }

        public async Task<bool> UseEntry(int prizePoolID, int participantID)
        {
            var participant = await _context.Participants
            .Include(p => p.SerialNumbers)
                .ThenInclude(s => s.PoolEntries)
            .FirstOrDefaultAsync(p => p.ParticipantID == participantID);

            foreach (var serialNumber in participant.SerialNumbers)
            {
                if(serialNumber.PoolEntries.Count() < 2)
                {
                    PoolEntry poolEntry = new PoolEntry
                    {
                        PrizePoolID = prizePoolID,
                        SerialNumberID = serialNumber.SerialNumberID
                    };

                    await _context.PoolEntries.AddAsync(poolEntry);
                    await _context.SaveChangesAsync();

                    return true;
                }
            }

            throw new Exception("No entries left.");
        }
    }
}