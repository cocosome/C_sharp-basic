using System;
using static System.Console;

namespace Switch_expression
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            int input = Convert.ToInt32(ReadLine());
            int score = (int)(Math.Truncate(input / 10.0) * 10);

            //일반적인 switch case 문
            /*string grade = "";
            switch(score)
            {
                case 90:
                    grade = "A";
                    break;
                case 80:
                    grade = "B";
                    break;
                case 70:
                    grade = "C";
                    break;
                case 60:
                    grade = "D";
                    break;
                default:
                    grade = "F";
                    break;
            }*/
            // switch 식 예제, 위의 switch case문을 아래의 switch식으로 간략화 할 수 있다
            string grade = score switch
            {
                90 => "A",
                80 => "B",
                70 => "C",
                60 => "D",
                _ => "F" //_는 switch case문에서 default를 의미한다.
            };
            WriteLine(grade);

            // 패턴 매칭
            object foo = 220;
            //선언 패턴
            if(foo is int bar) //foo가 int 라면? int 변수 bar를 선언하고 foo값을 bar에 할당 후 아래 구문을 수행.
            {
                //bar = 15;
                WriteLine(bar);
            }
            //형식 패턴
            else if(foo is string) //foo가 string이라면? 아래 구문을 수행.
            {

                string car = "yeah";
                WriteLine(car);
            }
            else
            {
                WriteLine("none");
            }
        }
    }
}
