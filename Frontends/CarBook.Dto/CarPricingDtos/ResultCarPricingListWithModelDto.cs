namespace CarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingListWithModelDto
    {
        public int ID { get; set; }
        public string model { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal HourlyAmount { get; set; }
        public string CoverImageUrl { get; set; }
        public string Brand { get; set; }
    }
}
