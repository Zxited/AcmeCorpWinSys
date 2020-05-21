using System.Collections.Generic;
namespace ACWS_ClassLib.Models
{
    public class PrizePool
    {
        public int PrizePoolID { get; set; }
        public string PrizePoolName { get; set; }
        public string PrizePoolDescription { get; set; }
        public string PrizePoolImage { get; set; }
        public int PrizePoolQuantity { get; set; }

        public ICollection<Prize> Prizes { get; set; }
        public ICollection<PoolEntry> PoolEntries { get; set; }
    }
}