namespace Constellation.Core.Models
{
    public class User
    {
        const int MAX_FIRST_NAME_LENGTH = 25;
        const int MAX_LAST_NAME_LENGTH = 25;

        public User(Guid id,
            string firstName,
            string lastName,
            int age,
            string phoneNumber,
            string email,
            string passwordHash,
            long? telegramId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
            PasswordHash = passwordHash;
            TelegramId = telegramId;
        }
        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public long? TelegramId { get; private set; } = null;


        public (User? User, string Error) Create(Guid id,
            string firstName,
            string lastName,
            int age,
            string phoneNumber,
            string email,
            string passwordHash,
            long? telegramId = null)
        {
            var error = string.Empty;
            var validPhoneNumber = Validator.IsValidPhoneNumber(phoneNumber);
            var validEmail = Validator.IsValidEmail(email);

            if (string.IsNullOrWhiteSpace(firstName) ||  firstName.Length > MAX_FIRST_NAME_LENGTH)
            {
                error = $"First name cannot be empty or longer than {MAX_FIRST_NAME_LENGTH}";

                return (null, error);
            }
            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > MAX_LAST_NAME_LENGTH)
            {
                error = $"Last name cannot be empty or longer than {MAX_LAST_NAME_LENGTH}";

                return (null, error);
            }
            if(age <= 0)
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

            var user = new User(id, firstName, lastName, age, phoneNumber, email, passwordHash, telegramId);

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
    }
}
