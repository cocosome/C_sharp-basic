namespace OverLoading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculateOld calOld = new CalculateOld();
            CalculateNew calNew = new CalculateNew();
            int a = 10;
            int b = 20;
            double c = 5.5;
            double d = 7.3;
            string e = "hello";
            string f = "world";
            int g = 30;

            Console.WriteLine("old Int : {0}",calOld.plusInt(a, b));
            Console.WriteLine("old double : {0}", calOld.plusDouble(c, d));
            Console.WriteLine("old string : {0}", calOld.plusString(e, f));

            Console.WriteLine(); //개행

            Console.WriteLine("new Int : {0}", calNew.plus(a, b));
            Console.WriteLine("new double : {0}", calNew.plus(c, d));
            Console.WriteLine("new string : {0}", calNew.plus(e, f));
            Console.WriteLine("new Int3 : {0}", calNew.plus(a, b, g));
            Console.WriteLine("new Int3 : {0}", calNew.plus(a, b, c));


            Console.WriteLine("End of Line");
        }
    }
    //Overloading X
    public class CalculateOld
    {
        public int plusInt(int a, int b)
        {
            return a + b;
        }
        public double plusDouble(double a, double b)
        {
            return a + b;
        }

        public string plusString(string a, string b)
        {
            return a + b;
        }
    }

    //Overloading O
    public class CalculateNew
    {
        public int plus(int a, int b)
        {
            return a + b;
        }
        public double plus(double a, double b)
        {
            return a + b;
        }

        public string plus(string a, string b)
        {
            return a + b;
        }

        public int plus(int a, int b, int c)
        {
            return a + b + c;
        }

        public double plus(int a, int b, double c)
        {
            return a + b + c;
        }
        //public double plus(int a, int b)
        //{
        //    return a + b;
        //}
        // 기존함수와 반환형식만 다른(매개변수의 자료형과 갯수가 같은) 함수의 overloading은 불가능 -> 컴파일러가 어떤 함수를 호출해야 할지 모름

    }
}
