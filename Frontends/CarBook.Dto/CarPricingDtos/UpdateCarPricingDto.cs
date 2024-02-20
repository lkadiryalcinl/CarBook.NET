namespace CarBook.Dto.CarPricingDtos
{
    public class UpdateCarPricingDto
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public int PricingID { get; set; }
        public decimal Amount { get; set; }
    }
}
