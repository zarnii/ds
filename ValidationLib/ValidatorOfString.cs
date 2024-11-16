namespace ValidationLib
{
    public static class ValidatorOfString
    {
        public static void CheckStringIsNotNull(
            string value, 
            string nameof = null, 
            string message = null)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof, message);
            }
        }
    }
}
