namespace NetStore.Api.Helpers
{
    public static class Ex
    {
        public static string Check(string oldString, string newString)
        {
            var result = string.IsNullOrEmpty(newString) ? oldString : newString;
            return result;
        }
    }
}