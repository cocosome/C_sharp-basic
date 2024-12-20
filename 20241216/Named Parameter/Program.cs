namespace Named_Parameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculateOld calOld = new CalculateOld();
            int mainA = 10;
            int mainB = 20;
            double mainC = 5.5;
            double mainD = 7.3;
            string mainE = "hello";
            string mainF = "world";


            //Console.WriteLine("old Int : {0}", calOld.plusInt(mainA : 10, mainB : 20)); // 컴파일 에러
            Console.WriteLine("old Int : {0}", calOld.plusInt(localA : 10, localB : 20)); // -> main함수에서 변수를 만들 필요 X
            Console.WriteLine("old double : {0}", calOld.plusDouble(mainC, mainD));
            Console.WriteLine("old string : {0}", calOld.plusString(mainE, mainF));

            Console.WriteLine("End of Line");
        }
    }

    public class CalculateOld
    {
        public int plusInt(int localA, int localB)
        {
            return localA + localB;
        }
        public double plusDouble(double localC, double localD)
        {
            return localC + localD;
        }

        public string plusString(string localE, string localF)
        {
            return localE + localF;
        }
    }
}
