using System.Collections.Generic;
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

        public static List<string> GenerateSerialKeys(int keyQuantity, int keyLength)
        {
            List<string> keys = new List<string>();

            for (int i = 0; i < keyQuantity; i++)
            {
                keys.Append(KeyGenerator(keyLength));
            }

            return keys;
        }

        // Do not use for security, use RNGCryptoServiceProvider instead.
        private static string KeyGenerator(int keyLength)
        {
            var rnd = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var charArr = new char[keyLength];

            string serialKey = "";
            for (int j = 0; j < charArr.Length; j++)
            {
                serialKey += chars[rnd.Next(chars.Length)];
            }
            return serialKey;
        }
    }
}