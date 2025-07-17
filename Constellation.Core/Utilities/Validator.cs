using System.Text.RegularExpressions;

namespace Constellation.Core.Utilities
{
    public static class Validator
    {
        public static bool IsValidPassword(string password, int maxCharsInOrderCount)
        {
            if (password == null)
                throw new NullReferenceException($"{nameof(password)} был null");
            if (maxCharsInOrderCount < 2)
                throw new ArgumentException($"{nameof(maxCharsInOrderCount)} должно быть больше, чем 1");
            if (password.Length < maxCharsInOrderCount)
                return true;

            int current = 1;
            int max = 1;

            var cleanPassword = password.Select(c => c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' ? c : '\0');

            char lastChar = '\0';
            int direction = 0;
            foreach (char c in cleanPassword)
            {
                int diff = c - lastChar;
                if (Math.Abs(diff) == 1)
                {
                    if (current == 1)
                        direction = diff;
                    if (diff == direction)
                    {
                        current++;
                        if (current > max)
                            max = current;
                    }
                    else
                        current = 1;
                }
                else
                    current = 1;
                lastChar = c;
            }
            return max < maxCharsInOrderCount;
        }
        public static bool IsValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        public static bool IsValidPhoneNumber(string number)
        {
            string pattern = @"^\+7\s?\(\d{3}\)\s?\d{3}-\d{2}-\d{2}$";
            return Regex.IsMatch(number, pattern);
        }
    }
}
