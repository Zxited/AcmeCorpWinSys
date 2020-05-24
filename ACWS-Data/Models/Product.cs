using System.Collections.Generic;

namespace ACWS_Data.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int AvailableQuantity { get; set; }

        public ICollection<Prize> Prizes { get; set; }
    }
}