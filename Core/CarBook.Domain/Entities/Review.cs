namespace CarBook.Domain.Entities
{
    public class Review : IEntity
    {
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public int RaytingValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
