namespace Constructor_Destructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BV CBV = new BV(); //아래와 같이 생성자가 명시적으로 구현된 경우, 매개변수가 없는 생성자 메소드도 명시적으로 구현해야 한다. -> 구현하지 않으면 에러
            BV KBV = new BV(3, 7);
            BV EBV = new BV(3, 14, 100);
            GC.Collect();
            Console.WriteLine("End of Line");
        }
    }

    public class BV
    {
        public int PIR;
        public int MOTD;
        public int DSP;

        public BV()
        {
            Console.WriteLine("BV Initialize X");
        }

        public BV(int pir, int motd)
        {
            PIR = pir;
            MOTD = motd;
            Console.WriteLine("BV Initialize PIR : {0}, MOTD : {1}", PIR, MOTD);
        }

        public BV(int pir, int motd, int dsp)
        {
            PIR = pir;
            MOTD = motd;
            DSP = dsp;
            Console.WriteLine("BV Initialize PIR : {0}, MOTD : {1}, DSP : {2}", PIR, MOTD, DSP);
        }

        ~BV()
        {
            Console.WriteLine("BV log off"); // 콘솔창에 출력X
        }
    }
}
