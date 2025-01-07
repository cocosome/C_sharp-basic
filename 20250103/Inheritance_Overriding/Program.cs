namespace Inheritance_Overriding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BV bv = new BV();
            bv.Initialize(3, 7);

            EBV ebv = new EBV();
            ebv.Initialize(3, 14);

            RBV rbv = new RBV();
            rbv.Initialize(6, 14, 5);
            Console.WriteLine("End of Line");
        }
    }

    public class BV
    {
        public int UV;
        public int MOTD;
        public BV()
        {
            UV = 0;
            MOTD = 0;
            Console.WriteLine("BV 초기세팅 -> UV : {0}, MOTD : {1}", UV, MOTD);
        }
        public void Initialize(int uv, int motd)
        {
            UV = uv;
            MOTD = motd;
            Console.WriteLine("BV 초기화값 -> UV : {0}, MOTD : {1}", UV, MOTD);
        }
    }
    public class EBV : BV
    {
        public void Initialize(int uv, int motd) 
        {
            UV = uv;
            MOTD = motd;
            Console.WriteLine("EBV 초기화값 -> UV : {0}, MOTD : {1}", UV, MOTD);
            Console.WriteLine("이 BV는 EBV 입니다.");
        }
    }
    public class RBV : BV // RBV Class의 경우, 부모 Class(BV)의 생성자가 먼저 호출된 후 자식 Class(RBV)의 생성자가 호출된다.
    {
        public int CIS;
        public RBV()
        {
            CIS = 0;
            Console.WriteLine("RBV 초기세팅 -> UV : {0}, MOTD : {1}, CIS : {2}", UV, MOTD, CIS);
        }
        public void Initialize(int uv, int motd, int cis)
        {
            UV = uv;
            MOTD = motd;
            CIS = cis;
            Console.WriteLine("RBV 초기화값 -> UV : {0}, MOTD : {1}, CIS : {2}", UV, MOTD, CIS);
            Console.WriteLine("이 BV는 RBV 입니다.");
        }
    }
}
