namespace Params
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculate cal = new Calculate();
            Console.WriteLine("total1 : {0}", cal.Sum(1, 2, 3));
            Console.WriteLine("total2 : {0}", cal.Sum(2, 3, 4));
            Console.WriteLine("total3 : {0}", cal.Sum(2, 3, 4, 5, 6));

            Console.WriteLine("totalDouble1 : {0}", cal.Sum(2.1, 3.1, 4.1, 5.1, 6));
            Console.WriteLine("totalDouble2 : {0}", cal.Sum(2.1, 5.1, 6.5));
            Console.WriteLine("totalDouble3 : {0}", cal.Sum(2, 4, 5.3, 2.1, 5.1, 6.5));



            Console.WriteLine("End of Line");
        }
    }

    public class Calculate
    {
        public int Sum(params int[] nums)
        {
            int cnt;
            int sum = 0;
            for(cnt = 0; cnt < nums.Length; cnt++)
            {
                sum += nums[cnt];
            }
            Console.WriteLine("INT");
            return sum;
        }
        public double Sum(params double[] nums)
        {
            int cnt;
            double sum = 0;
            for (cnt = 0; cnt < nums.Length; cnt++)
            {
                sum += nums[cnt];
            }
            Console.WriteLine("DOBULE");
            return sum;
        }

        public double Sum(int a, int b, params double[] doubleArr)
        {
            int cnt;
            double sum = 0;
            for (cnt = 0; cnt < doubleArr.Length; cnt++)
            {
                sum += doubleArr[cnt];
            }
            return sum + a + b;
        }
        // parmas키워드 매개변수와 params키워드가 아닌 매개변수를 같이 사

        //public double Sum(params double[] doubleArr, params int[] intArr)
        //{
        //    int cnt;
        //    double sum = 0;
        //    for (cnt = 0; cnt < doubleArr.Length; cnt++)
        //    {
        //        sum += doubleArr[cnt];
        //    }
        //    for (cnt = 0; cnt < doubleArr.Length; cnt++)
        //    {
        //        sum += intArr[cnt];
        //    }

        //    return sum;
        //}

        //위와같이 params 키워드를 두개 이상 사용불가 -> params 키워드는 항상 매개변수들중 가장 마지막에만 사용가능
    }
}
