using Constellation.Core.Enums.Users;
using Constellation.Core.Models.MasterClassModels;
using Constellation.Core.Utilities;

namespace Constellation.Core.Models.UserModels
{
    public class User
    {
        const int MAX_FIRST_NAME_LENGTH = 25;
        const int MAX_LAST_NAME_LENGTH = 25;

        public User(string firstName,
            string lastName,
            int age,
            string phoneNumber,
            string email,
            string passwordHash,
            UserRole role,
            long? telegramId)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            TelegramId = telegramId;
        }
        public Guid Id { get; } = Guid.NewGuid();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; } = UserRole.DefaultUser;
        public long? TelegramId { get; private set; } = null;
        public Photo? Avatar { get; private set; } = null;
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public List<MasterClassEvent> MasterClasses { get; private set; } = [];


        public (User? User, string Error) Create(string firstName,
            string lastName,
            int age,
            string phoneNumber,
            string email,
            string passwordHash,
            UserRole role,
            long? telegramId = null)
        {
            var error = string.Empty;
            var validPhoneNumber = Validator.IsValidPhoneNumber(phoneNumber);
            var validEmail = Validator.IsValidEmail(email);

            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > MAX_FIRST_NAME_LENGTH)
            {
                error = $"First name cannot be empty or longer than {MAX_FIRST_NAME_LENGTH}";

                return (null, error);
            }
            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > MAX_LAST_NAME_LENGTH)
            {
                error = $"Last name cannot be empty or longer than {MAX_LAST_NAME_LENGTH}";

                return (null, error);
            }
            if (age <= 0)
            {
                error = "Age number cannot be less than zero";

                return (null, error);
            }
            if (!validPhoneNumber)
            {
                error = "Wrong phone number format";

                return (null, error);
            }
            if (!validEmail)
            {
                error = "Wrong email format";

                return (null, error);
            }

            var user = new User(firstName, lastName, age, phoneNumber, email, passwordHash, role, telegramId);

            return (user, error);

        }
        public void UpdatePersonalInfo(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > MAX_FIRST_NAME_LENGTH)
            {
                throw new Exception($"First name cannot be empty or longer than {MAX_FIRST_NAME_LENGTH}");
            }
            if (string.IsNullOrWhiteSpace(lastName) || firstName.Length > MAX_LAST_NAME_LENGTH)
            {
                throw new Exception($"Last name cannot be empty or longer than {MAX_LAST_NAME_LENGTH}");
            }
            FirstName = firstName;
            LastName = lastName;
        }

        public void UpdateEmail(string email)
        {
            var validEmail = Validator.IsValidEmail(email);

            if (!validEmail)
            {
                throw new Exception("Wrong email format");
            }
            Email = email;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            var validPhoneNumber = Validator.IsValidPhoneNumber(phoneNumber);

            if (!validPhoneNumber)
            {
                throw new Exception("Wrong phone number format");
            }
            PhoneNumber = phoneNumber;
        }

        public void UpdateTelegramId(long telegramId)
        {
            TelegramId = telegramId;
        }

        public void UpdateAvatar(Photo photo)
        {
            Avatar = photo;
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveAvatar()
        {
            if (Avatar == null)
            {
                throw new Exception("Avatar is not set");
            }

            Avatar = null;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
