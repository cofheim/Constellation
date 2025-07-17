using Constellation.Core.Enums.Users;
using Constellation.Core.Models;

namespace Constellation.Persistence.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } = UserRole.DefaultUser;
        public long? TelegramId { get; set; } = null;
        public PhotoEntity? Avatar { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public List<MasterClassEntity> MasterClasses { get; set; } = [];
    }
}
