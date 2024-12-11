namespace Ref
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int valueLeft = 10;
            int valueRight = 20;
            Console.WriteLine("Before valueSwap : " + valueLeft + " " + valueRight);
            Program.valueSwap(valueLeft, valueRight);
            Console.WriteLine("After valueSwap : " + valueLeft + " " + valueRight);

            int refLeft = 15;
            int refRight = 25;
            Console.WriteLine("Before refSwap : " + refLeft + " " + refRight);
            Program.refSwap(ref refLeft, ref refRight);
            Console.WriteLine("After refSwap : " + refLeft + " " + refRight);

            Console.WriteLine("End of Line");
        }

        // Main함수에서 할당한 valueLeft, valueRight의 값만 복사하여 새로운 주소에 메모리를 할당한 후 복사한 값을 넣어 함수내에서 사용함(left, right)
        public static void valueSwap(int left, int right)
        {
            int temp;
            temp = left;
            left = right;
            right = temp;
            return;
        }

        // Main함수에서 할당한 refLeft, refRight를 그대로 함수내에서 사용함, 새로운 주소에 메모리를 할당하는 작업X
        // 때문에 함수내에서 변수들의 값 변화는 곧 Main함수에서 할당한 그 변수의 값이 변하는 것과 같다(why? -> 그변수가 그변수니까 == 가가가니까)
        public static void refSwap(ref int left, ref int right)
        {
            int temp;
            temp = left;
            left = right;
            right = temp;
            return;
        }
    }
}
