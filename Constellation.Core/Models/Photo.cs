namespace Constellation.Core.Models
{
    public class Photo
    {
        public Photo(string fileName, string contentType, string url)
        {
            FileName = fileName;
            ContentType = contentType;
            Url = url;
        }

        public Guid Id { get; } = Guid.NewGuid();
        public string FileName { get; private set; }
        public string ContentType { get; private set; }
        public string Url { get; private set; }
        public DateTime UploadedAt { get; } = DateTime.UtcNow;

        public (Photo? Photo, string Error) Create(string fileName, string contentType, string url)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return (null, "File name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(contentType))
            {
                return (null, "Content type cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(url))
            {
                return (null, "URL cannot be empty");
            }

            var photo = new Photo(fileName, contentType, url);
            return (photo, string.Empty);
        }

        public void UpdateUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new Exception("URL cannot be empty");
            }
            
            Url = url;
        }
    }
} 