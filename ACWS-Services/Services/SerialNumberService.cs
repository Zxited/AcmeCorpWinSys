using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ACWS_Services.ServiceInterfaces;
using ACWS_Data;
using ACWS_Data.Models;

namespace ACWS_Services.Services
{
    public class SerialNumberService : ISerialNumberService
    {
        private ApplicationDbContext _context;
        
        public SerialNumberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SerialNumberExists(string serialKey)
        {
            return (await GetSerialNumber(serialKey)).SerialKey == serialKey ? true : false;
        }

        public async Task<bool> SerialNumberUnused(string serialKey)
        {
            return (await GetSerialNumber(serialKey)).ParticipantID == null ? true : false;
        }

        public async Task<SerialNumber> GetSerialNumber(string serialKey)
        {
            var serialNumber = await _context.SerialNumbers.FirstOrDefaultAsync(s => s.SerialKey == serialKey);

            return serialNumber == null ? throw new Exception("Serial number not found.") : serialNumber;
        }

        public async Task<SerialNumber> SubmitSerialNumber(string serialKey, int participantID)
        {
            SerialNumber serialNumber = await GetSerialNumber(serialKey);

            if (await SerialNumberUnused(serialKey))
            {
                serialNumber.ParticipantID = participantID;

                await _context.SaveChangesAsync();
            
                return await GetSerialNumber(serialKey);
            }

            throw new Exception("Serial number is already claimed.");
        }
    }
}