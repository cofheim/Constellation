using Constellation.Core.Enums;
using Constellation.Core.Enums.MasterClass;
using Constellation.Core.Models.UserModels;
using Constellation.Core.Utilities;

namespace Constellation.Core.Models.MasterClassModels
{
    public class MasterClassTemplate
    {
        private const int MAX_TITLE_LENGTH = 100;
        private const int MAX_DESCRIPTION_LENGTH = 2000;
        private const int MAX_PHOTOS = 10;

        public MasterClassTemplate(
            string title,
            string description,
            decimal basePrice,
            TimeSpan approximateDuration,
            AgeGroup recommendedAge,
            Category category)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            BasePrice = basePrice;
            ApproximateDuration = approximateDuration;
            RecommendedAge = recommendedAge;
            Category = category;
        }

        public Guid Id { get; }

        // Основная информация
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal BasePrice { get; private set; }
        public TimeSpan ApproximateDuration { get; private set; }
        public bool IsActive { get; private set; } = true;

        // Характеристики
        public AgeGroup RecommendedAge { get; private set; }
        public Category Category { get; private set; }
        public SkillLevel RequiredSkillLevel { get; private set; }
        public int MaxParticipants { get; private set; }

        // Медиа
        public List<Photo> Photos { get; private set; } = [];
        public List<Review> Reviews { get; private set; } = [];

        // Статистика
        public int TotalBookings { get; private set; }
        public double AverageRating { get; private set; }

        // Мета-информация
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public User Creator { get; }

    }
}
