namespace ACWS_Data.Models
{
    public class PoolEntry
    {
        public int PrizePoolID { get; set; }
        public int SerialNumberID { get; set; }

        public PrizePool PrizePool { get; set; }
        public SerialNumber SerialNumber { get; set; }
    }
}