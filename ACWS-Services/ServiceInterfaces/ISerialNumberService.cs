using System.Collections.Generic;
using System.Threading.Tasks;
using ACWS_Data.Models;

namespace ACWS_Services.ServiceInterfaces
{
    public interface ISerialNumberService
    {
        Task<bool> SerialNumberExists(string serialKey);
        Task<bool> SerialNumberUnused(string serialKey);
        Task<SerialNumber> GetSerialNumber(string serialKey);
        Task<SerialNumber> SubmitSerialNumber(string serialKey, int participantID);
    }
}