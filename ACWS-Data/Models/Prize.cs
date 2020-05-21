namespace ACWS_Data.Models
{
    public class Prize
    {
        public int PrizePoolID { get; set; }
        public int ProductID { get; set; }
        public int ProductQuantity { get; set; }

        public PrizePool PrizePool { get; set; }
        public Product Product { get; set; }
    }
}