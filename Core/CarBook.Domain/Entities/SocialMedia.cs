namespace CarBook.Domain.Entities
{
    public class SocialMedia : IEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
