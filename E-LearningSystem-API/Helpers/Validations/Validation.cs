namespace E_LearningSystem_API.Helpers.Validations
{
    public static class Validation
    {
        public static bool IsValidPass(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            var hasMinimum8Chars = password.Length >= 8;
            var hasUpperCase = password.Any(char.IsUpper);
            var hasLowerCase = password.Any(char.IsLower);
            var hasDigit = password.Any(char.IsDigit);
            var hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasMinimum8Chars && hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }
    }
}
