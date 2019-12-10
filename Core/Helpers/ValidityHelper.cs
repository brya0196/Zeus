namespace Core.Helpers
{
    public class ValidityHelper
    {
        public static int Yes { get; set; }
        public static int No { get; set; }

        public static bool IsActive(int value)
        {
            return value == Yes;
        }

        public static bool IsNotActive(int value)
        {
            return value == No;
        }
    }
}