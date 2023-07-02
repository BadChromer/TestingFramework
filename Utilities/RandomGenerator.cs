namespace Framework.Utilities
{
    public class RandomGenerator
    {
        private static readonly Random random = new();
        public static string GenerateRandomString(int stringLength)
        {

            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+=-?:;";
            return new string(Enumerable.Repeat(chars, stringLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}