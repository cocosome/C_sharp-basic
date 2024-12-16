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
## 1. ref 키워드
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
## 1. out 키워드
- out 키워드와 ref 키워드의 공통점 : 
    * out 키워드의 동작방식은 호출한 함수의 변수를 호출받은 함수의 매개변수로 사용한다는(메모리 주소 동일) 점에서는 ref 키워드와 동일하다.
- out 키워드와 ref 키워드의 차이점 : 
    * out 키워드는 반환 전용 변수앞에 붙이는 키워드이다. 
    * 때문에 호출한 함수로부터 전달받은 매개변수가 호출받은 함수내에서 값이 할당 되지 않아도 상관없던 ref 키워드와 달리 out 키워드는 값이 할당 되어야 한다.
    * 값이 할당되지 않으면 컴파일러가 에러를 발생시킨다.

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