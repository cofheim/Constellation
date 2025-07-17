namespace Constellation.Core.Models
{
    public class MasterClass
    {
        const int MAX_TITLE_LENGTH = 100;
        const int MAX_DESCRIPTION_LENGTH = 1000;
        const int MAX_PHOTOS = 10;

        public MasterClass(string title, string? description = null)
        {
            Title = title;
            Description = description;
        }

        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; private set; }
        public string? Description { get; private set; } = null;
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }

        // users registered for the master class
        public List<User> RegisteredUsers { get; private set; } = new List<User>();
        
        // photos associated with the master class
        public List<Photo> Photos { get; private set; } = new List<Photo>();

        public (MasterClass? MasterClass, string Error) Create(string title, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_LENGTH)
            {
                return (null, $"Title cannot be empty or longer than {MAX_TITLE_LENGTH} characters");
            }

            if (description != null && description.Length > MAX_DESCRIPTION_LENGTH)
            {
                return (null, $"Description cannot be longer than {MAX_DESCRIPTION_LENGTH} characters");
            }

            var masterClass = new MasterClass(title, description);
            return (masterClass, string.Empty);
        }

        public void UpdateInfo(string title, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_LENGTH)
            {
                throw new Exception($"Title cannot be empty or longer than {MAX_TITLE_LENGTH} characters");
            }

            if (description != null && description.Length > MAX_DESCRIPTION_LENGTH)
            {
                throw new Exception($"Description cannot be longer than {MAX_DESCRIPTION_LENGTH} characters");
            }

            Title = title;
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddPhoto(Photo photo)
        {
            if (Photos.Count >= MAX_PHOTOS)
            {
                throw new Exception($"Cannot add more than {MAX_PHOTOS} photos to a master class");
            }

            Photos.Add(photo);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemovePhoto(Guid photoId)
        {
            var photo = Photos.FirstOrDefault(p => p.Id == photoId);
            if (photo == null)
            {
                throw new Exception("Photo not found");
            }

            Photos.Remove(photo);
            UpdatedAt = DateTime.UtcNow;
        }

        public void RegisterUser(User user)
        {
            if (RegisteredUsers.Any(u => u.Id == user.Id))
            {
                throw new Exception("User is already registered for this master class");
            }

            RegisteredUsers.Add(user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void UnregisterUser(Guid userId)
        {
            var user = RegisteredUsers.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User is not registered for this master class");
            }

            RegisteredUsers.Remove(user);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
