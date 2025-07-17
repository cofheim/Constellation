using Constellation.Core.Models.MasterClassModels;
using Constellation.Core.Utilities;

namespace Constellation.Core.Models.UserModels
{
    public class Review
    {
        public Guid Id { get; }
        public User Author { get; }
        public int Rating { get; private set; }
        public string Comment { get; private set; }
        public DateTime CreatedAt { get; }
        public List<Photo> Photos { get; private set; } = [];
        public MasterClassEvent? Event { get; } // Может быть null если отзыв общий
        public MasterClassTemplate Template { get; }
    }
}
