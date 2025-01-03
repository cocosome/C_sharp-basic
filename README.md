# C_sharp-basic

## 2024.11.17
> 학습 목차

1. using 키워드
2. WriteLine()함수내 { } 키워드
3. switch expression
4. 패턴 매칭 기법
---
> 학습 내용
### 1. using 키워드
- using : using abc 선언시, abc의 하위 keyword를 사용 
할 때 abc를 생략하고 쓸 수 있다.

---
### 2. WriteLine()함수내 { } 키워드
- WriteLine()의 큰 따옴표 내부에 적힌 {0}, {1}는 C언어
에서 %d와 비슷한 역할을 하는것으로 추정된다.

<예시>
```
static void Main(string[] args)
{
    if(args.Length == 0)
    {
        WriteLine("사용법 : Hello.exe <이름>");
        return;
    }

    WriteLine("Hello, {0} {1}", args[0], args[1]); 
}

// WriteLine 함수내에서 {0}과 {1}에는 args[0]과 args[1]에 저장된 값이 들어간다.
```
---
### 3. switch expression
- switch expression을 사용하면 switch case문보다 간결 
하게 분기문을 작성 할 수 있다.(case X, break X, 람다식 O)

<예시>
```
//switch case
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
}

//switch expression
string grade = score switch
{
    90 => "A",
    80 => "B",
    70 => "C",
    60 => "D",
    _ => "F" 
};

//_는 switch case문의 default와 같다.
```
---
### 4. 패턴 매칭 기법
- 패턴 매칭 기법에서 사용되는 is keyword는 is 좌변이 is 우변과 자료형이 같은지 판단할 때 사용한다.
---
## 2024.12.11
> 학습 목차

1. ref 키워드

---
> 학습 내용
### 1. ref 키워드
- ref 키워드 동작 형태 :
    * ref키워드를 사용하면, 매개변수가 있는 함수 호출시, 메모리에 새로 영역을 할당 후 값을 저장하는 과정 없이, 호출했던 영역에 선언되었던 변수(매개변수)를 그대로 함수 내에서 사용한다. 
    * 떄문에 함수 내에서 변수의 값이 변경되면, 호출했던 영역에 선언되었던 변수의 값에도 그대로 반영된다. 
    * 이는 두 변수의 메모리 주소가 같기 때문이다.

<예시>
```
// Main함수에서 할당한 두 변수의 값만 복사하여 새로운 주소에 메모리를 할당한 후 복사한 값을 넣어 함수내에서 사용함(left, right)
   public static void valueSwap(int left, int right)
   {
       int temp;
       temp = left;
       left = right;
       right = temp;
       return;
   }

   // Main함수에서 할당한 두 변수를 그대로 함수내에서 사용함, 새로운 주소에 메모리를 할당하는 작업X
   // 때문에 함수내에서 변수들의 값 변화는 곧 Main함수에서 할당한 그 변수의 값이 변하는 것과 같다(why? -> 그변수가 그변수니까 == 가가가니까)
   public static void refSwap(ref int left, ref int right)
   {
       int temp;
       temp = left;
       left = right;
       right = temp;
       return;
   }
```
---
## 2024.12.12
> 학습 목차

1. out 키워드

---
> 학습 내용
### 1. out 키워드
- out 키워드와 ref 키워드의 공통점 : 
    * out 키워드의 동작방식은 호출한 함수의 변수를 호출받은 함수의 매개변수로 사용한다는(메모리 주소 동일) 점에서는 ref 키워드와 동일하다.
- out 키워드와 ref 키워드의 차이점 : 
    * out 키워드는 반환 전용 변수앞에 붙이는 키워드이다. 
    * 때문에 호출한 함수로부터 전달받은 매개변수가 호출받은 함수내에서 값이 할당 되지 않아도 상관없던 ref 키워드와 달리 out 키워드는 값이 할당 되어야 한다.
    * 값이 할당되지 않으면 컴파일러가 에러를 발생시킨다.
- out 키워드 사용 시기 :
    * return할 변수가 여러개인 경우, out 키워드를 사용하면 된다. 

<예시>
```
public void Divide(int a, int b, out int quotient, out int remainder)
{
    quotient = a / b;
    remainder = a % b;        
    return;
}
// 위의 함수처럼, out 키워드가 붙은 매개변수는 호출받은 함수 내에서 값할당이 되어야함

public void noChange(int a, int b, out int quotient, outint remainder)
{
    return;
}
// 위의 함수처럼, out 키워드가 붙은 매개변수가 호출받은 함수 내에서 값할당되지 않은 경우, 컴파일 에러 발생
```
---
## 2024.12.16
> 학습 목차
1. Overloading
2. Params : 가변길이 인수
3. 명명된 인수
---
> 학습 내용
### 1.Overloading
- 정의 : 이름은 같으나 매개변수의 자료형이 다른 함수를 선언하여 사용하는 행위
- 사용 시기 :
    1. 기존 함수와 동작은 같으나, 매개변수의 자료형이 다를 때
    2. 기존 함수와 동작은 같으나, 매개변수의 개수가 다를 때
    3. 1번과 2번상황이 혼재되었을 때
    * (2번의 경우 overloading 보다는 기존함수의 매개변수에 params를 적용하는것이 좋다)
- 주의 사항 : 기존 함수와 반환 형식만 다른(= 매개변수의 자료형과 매개변수 갯수는 같음)함수의 overloading은 불가능하다 -> 컴파일러가 어떤 함수를 호출해야하는지 불분명함

<예시1 - overloading의 좋은예>
```
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
public double plus(int a, int b, double c)
{
    return a + b + c;
}

// 함수 이름은 Plus로 동일하나, 자료형이 각각 int double string으로 상이함
```
<예시2 - overloading의 나쁜예>
```
public int plus(int a, int b)
{
    return a + b;
}

public double plus(int a, int b)
{
    return a + b;
}

//위의 경우 컴파일 에러 발생
```
---
### 2. Params : 가변길이 인수
- 정의 : 매개변수 갯수가 특정되지 않은 함수에서 매개변수 앞에 붙이는 키워드
- 주의 사항
    1. params 키워드를 갖는 변수는 항상 <U>매개변수중 맨 마지막에 위치해야 한다</U> -> 아닐시 **컴파일 에러** 발생
    2. params 매개변수를 갖는 함수 또한 <U>overloading이 가능하다.</U>
    3. params 키워드를 갖는 매개변수와 단일 매개변수 둘다 한 함수 내에서 혼용 가능하다.

<예시1 - 기본적인 params 적용 예>
```
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
        return sum;
    }
}

static void Main(string[] args)
{
    Calculate cal = new Calculate();
    Console.WriteLine("total1 : {0}", cal.Sum(1, 2, 3));
    Console.WriteLine("total2 : {0}", cal.Sum(2, 3, 4));
    Console.WriteLine("total3 : {0}", cal.Sum(2, 3, 4, 5, 6));
}

//위의 Main함수에서와 같이, 같은 함수를 호출하지만 매개변수 개수를 달리해도 문제없다.
```

<예시2 - params의 overloading 적용 예>
```
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
        return sum;
    }
}

static void Main(string[] args)
{
    Calculate cal = new Calculate();
    Console.WriteLine("total1 : {0}", cal.Sum(2, 3, 4));
    Console.WriteLine("total2 : {0}", cal.Sum(2, 3, 4, 5, 6));
    Console.WriteLine("totalDouble1 : {0}", cal.Sum(2.1, 3.1, 4.1, 51, 6));
    Console.WriteLine("totalDouble2 : {0}", cal.Sum(2.1, 5.1, 6.5));
}

//위와 같이, 겉보기에는 같은 Sum함수를 호출했지만, 매개변수의 자료형에 따라 다른 함수가 호출될 수 있다.
```
<예시3 - params 매개변수와 단일 매개변수가 혼용된 예>
```
static void Main(string[] args)
{
    Calculate cal = new Calculate();
    Console.WriteLine("totalDouble3 : {0}", cal.Sum(2, 4, 5.3, 2.1, 51,65));
}

public class Calculate
{
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
}

//위와 같이 단일 매개변수와 params 매개변수가 혼용되어도 상관없다.
//다만 주의할 것은 params 매개변수가 항상 맨 마지막에 위치해야 한다.
```
---
### 3. 명명된 인수
- 정의 : 함수를 호출한 곳에서 미리, 호출받은 함수 내에서 사용할 매개변수에, 명시적으로 값을 할당하는 행위
- 장점 : 함수를 호출하는 곳에서 변수 선언 및 값할당을 하지 않아도 된다. (불필요한 변수 사용X)
- 주의 사항 : 매개변수의 값을 명시적으로 할당시, 호출받은 함수 내에서 사용될 매개변수의 이름을 사용해야 한다 -> <U>함수를 호출한 곳에 선언된 변수이름 사용시 **컴파일 에러 발생**</U>

<예시>
```
internal class Program
{
    static void Main(string[] args)
    {
        CalculateOld calOld = new CalculateOld();
        int mainA = 10;
        int mainB = 20;

        Console.WriteLine("old Int : {0}", calOld.plusInt(mainA, mainB)); // 1번 예시
        //Console.WriteLine("old Int : {0}", calOld.plusInt(mainA : 10, mainB : 20)); // 2번 예시
        Console.WriteLine("old Int : {0}", calOld.plusInt(localA : 10, localB : 20)); // 3번 예시
    }
}

public class CalculateOld
{
    public int plusInt(int localA, int localB)
    {
        return localA + localB;
    }
}
// 1번 예시 : 함수를 호출한 곳에서 선언한 변수를, 함수의 매개변수로 전달하는 경우 (일반적인 예시)
// 2번 예시 : 컴파일 에러 (잘못된 예시)
// 3번 예시 : 함수를 호출한 곳에서, 함수 내에서 사용할 매개변수에, 값을 미리 넣어서 전달하는 경우(명명된 인수 적용 예시)
```
---
## 2024.12.20
> 학습 목차
1. Class와 객체
---
> 학습 내용
### 1. Class와 객체
- Class의 특징
    1. 참조형 타입이다.
    2. 필드와 메소드를 멤버로 가지며 멤버앞에 한정자(public, private, ...)를 붙일 수 있다.
    3. 일반적으로 Class 이름 첫글자는 대문자로 선언한다.
---
## 2025.01.02
> 학습 목차
1. Class의 생성자(Constructor)
2. Class의 소멸자(Destructor)
---
> 학습 내용
### 1. Class의 생성자(Constructor)
- 생성자의 특징
    1. Class가 생성될 때 가장 먼저 호출되는 메소드로 Class이름과 같은 이름을 가진다.
    2. 보통 Class 멤버의 초기화를 담당한다.
    3. 다른 메소드와 마찬가지로 Overloading이 가능하다.
    4. return 타입이 존재하지 않는다. (return X)

- 생성자의 명시적 구현과 암묵적 호출
    1. 생성자를 명시적으로 구현하지 않은 경우
        - 객체 생성시, 시스템에서 자동으로 매개변수가 없는 생성자 호출
        - 단, 객체를 생성하면서 생성자에 매개변수를 전달 할 순 없음

        <예시>
        ```
        internal class Program
        {
            static void Main(string[] args)
            {
                BV CBV = new BV();          // 정상 동작
                BV KBV = new BV(3, 7);      // 생성자 구현X -> 매개변수X -> 에러 
            }
        }

        public class BV
        {
            // 생성자 구현 X
        }
        ```

    2. 생성자를 명시적으로 구현한 경우
        - 객체 생성시, 구현한 생성자와 새로 만든 객체간 매개변수 갯수 및 타입이 일치하는 경우, 해당 생성자 호출

        <예시>
        ```
        internal class Program
        {
            static void Main(string[] args)
            {
                BV CBV = new BV();      // 매개변수 없는 생성자 구현X -> 에러
                BV KBV = new BV(1);     // 정상 동작
            }
        }

        public class BV
        {
            public int PIR;
            public int MOTD;
            public BV(int pir, int motd) // 생성자 구현 O
            {
                PIR = pir;
                MOTD = motd;
            }
        }
        ```
---
### 2. Class의 소멸자(Destructor)
- 소멸자의 특징
    1. 객체가 메모리에서 사라질 때 Garbage Collect(GC)에 의해 자동으로 호출되는 메소드로, Class이름과 같은 이름을 가진다.
    2. 프로그래머가 명시적으로 호출할 수 없으며, 일반적으로 명시적으로 구현하지 않는다.
    3. 한 Class당 하나만 존재할 수 있다 -> 때문에 Overloading 불가
    4. return 타입이 존재하지 않는다. (return X)
    5. 매개변수를 갖지 않는다.
    6. 한정자가 붙지 않는다.

<예시>
```
internal class Program
{
    static void Main(string[] args)
    {
        BV CBV = new BV();
        BV KBV = new BV(3, 7);
        GC.Collect();
    }
}

public class BV
{
    public int PIR;
    public int MOTD;

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

    ~BV() // 소멸자의 명시적 구현
    {
        Console.WriteLine("BV log off"); // 콘솔창에 출력X
    }
}
```
---


