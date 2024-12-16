namespace Out
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculate cal1 = new Calculate();
            int a = 20;
            int b = 3;
            int c;
            int d;

            cal1.Divide(a, b, out c, out d);
            Console.WriteLine("change - Quotient : {0}, Reminder {1}", c, d);

            //cal1.noChange(a, b, out c, out d);
            Console.WriteLine("NoChange - Quotient : {0}, Reminder {1}", c, d);
            Console.WriteLine("End of Line");
        }
    }

    public class Calculate
    {
        public void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
            return;
        }
        // 위의 함수처럼, out 키워드가 붙은 매개변수는 호출받은 함수 내에서 값할당이 되어야함

        // public void noChange(int a, int b, out int quotient, out int remainder)
        // {
        //     return;
        // }
        // 위의 함수처럼, out 키워드가 붙은 매개변수가 호출받은 함수 내에서 값할당되지 않은 경우, 컴파일 에러 발생

    }
}
