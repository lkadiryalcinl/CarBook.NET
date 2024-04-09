namespace CarBook.Dto.CarFeatureDto
{
    public class ResultAdminCarFeatureByCarIdDto
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
