namespace Core.Helpers
{
    public class ValidityHelper
    {
        public static int Yes = 1;
        public static int No = 2;

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