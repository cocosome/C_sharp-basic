using System; // System 하위의 keyword를 사용할 수 있게됨, ex) Console.WriteLine()... , 그러나 그냥 WriteLine()은 사용불가
using static System.Console; // Console 하위의 Keyword를 사용할 수 있게됨, ex) WriteLine()...
//using ~~~를 적음으로써 해당 ~~~ keyword를 생략할 수 있게됨

namespace Hello
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                WriteLine("사용법 : Hello.exe <이름>");
                return;
            }

            WriteLine("Hello, {0} {1}", args[0], args[1]); // {0}이라고 적으면 args[0]에 있는 값을 가져와서 출력함, C언어의 %d랑 비슷한 역할 수행
        }
    }
}
