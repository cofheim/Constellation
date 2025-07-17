namespace Constellation.Persistence.Entities
{
    public class PhotoEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Url { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
