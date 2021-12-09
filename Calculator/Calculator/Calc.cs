namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            // checks arithmetic operations for overflow and throws OverflowException
            // because option is enabled in project settings
            // alternative: return checked(a+b);
            return a + b;
        }

        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Saturday
                || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}