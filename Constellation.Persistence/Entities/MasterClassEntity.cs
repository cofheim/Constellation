using Constellation.Core.Models;

namespace Constellation.Persistence.Entities
{
    public class MasterClassEntity
    {
        public Guid Id { get; set;  } = Guid.NewGuid();
        public string Title { get; set; }
        public string? Description { get; set; } = null;
        public double? Price { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // users registered for the master class
        public List<UserEntity> RegisteredUsers { get; set; } = [];

        // photos associated with the master class
        public List<PhotoEntity> Photos { get; set; } = new List<PhotoEntity>();
    }
}
