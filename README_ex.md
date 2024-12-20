# pcc010

## 김주현

## 201820791


## Class 1 - 23/2/6
> 강의순서
---
1. 강의 오리엔테이션
2. git.ajou.ac.kr에 pcc project 생성
3. 생성한 프로젝트 URL을 구글 드라이브 스프레드 시트에 추가함
4. ssh pcc010@ssh.ajousw.kr로 ssh server에 접속(password는 pcp0101234)
5. terminal 색 바꾸기 -> options - Terminal -xterm256 color
6. options - Looks - cursor - Block and Blinking설정
7. lab01 directory생성후 hello.c file 생성 -> hello world! 출력을 위한 코드 작성 및 compile
8. pcc000의 lab01에 학번 file 생성
9. stdio file 탐험
10. hello2.c생성 및 stdin, stdout, stderr 사용
11. 리디렉션(0< 1> 2> &>)

>linux 명령어 모음
---
| name | Description |
| ----------- | ----------- |
| passwd | 비밀번호를 바꾸는 명령어 (enqn102812!) |
| ls -al | 현재 디렉토리의 파일을 검색하는 명령어(last modification time이 보여진다) |
| ls -l FILE | 특정 FILE의 상태를 보여주는 명령어|
| ls -l -h | file의 크기를 byte단위로 보여주는 명령어 |
| pwd(print working directory) | 현재 위치를 파악하는 명령어 |
| mkdir | 디렉토리를 만드는 명령어 |
| cd | 디렉토리를 이동하는 명령어 |
| :wq | vi editor에서 작업한 파일을 저장 및 종료하는 명령어 |
| cc | vi edit한 파일을 compile하는 명령어 |
| man | 특정 명령어의 메뉴얼을 보여주는 명령어 |
| vi | vi editor로 파일을 edit하는 명령어 |
| touch | file의 타임스탬프(modification time 및 access time)를 현재 시간으로 바꾸는 명령어 (단 file이 존재하지 않으면 fiel을 생성)|
| tty | 현재 terminal의 위치를 알려줌|

> vi 명령어 모음
---
1. % : 괄호에 혹은 주석에 짝이되는 괄호 또는 주석으로 이동
2. : set number : line number를 표시
3. 명령어 mode에서 /"n" : n이라는 것을찾음
4. yy : 한줄 복사
5. "숫자"s : 숫자만큼의 단어 삭제 및 insert mode로 전환
6. p : 복사한 내용 붙여넣기

> 강의 내용
---
- 함수의 scope = global
- linux는 file system이 tree구조로 되어있다.
- windows file systme은 forest구조이다. - device마다 독립된 경로가 있다
- working directory
- shell : 프롬프트가 나타나고 cursor가 깜빡거리는 이 프로그램을 말한다.
- login시 자신의 home directory만 접속이 가능하다
- ~ = home directory
- -file : 아카이브 file
- dfile : directory
- 가장 최근에 수정한 날짜가 ls -al했을때 나온다.
- last modification, last creation time, last access 
time
- / : root file
- bin에 보통 명령어들이 들어 있다
- internationalization : 국제화 -> i18n (i와 n사이 18글자)
- localization : 지역화 -> l10n(l과 n사이 10글자)
- 함수 argument에 ...사용 : argument를 여러개 받는다는 뜻
- 실행파일에 0< "file"을 입력하여 입력 resource를 terminal에서 특정 파일로 바꿀수 있다
(사실 terminal도 /dev 아래있는 파일로구성되어있다.)
- 1> "file"는 stdout, 2> "file"은 stderr이고 &> "file" 는 stdout과 stderr를 동시에 적용시킨다
- &>를 사용하면 stdout과 stderr를 동시에 적용시키지만 순서를 보장하지는 않는다.
- 실행파일과 리디렉션의 순서는 상관없다.
- output buffer는 stdout buffer와 stderr buffer두개가 생성된다
```
touch [OPTION] ... FILE ...

- [] : 생략가능한 부분
- ... : 여러개 올 수 있는 부분
```
## Class 2 - 23/2/7
> 강의순서
---
1. ssh server에 git repository download
2. pcc directory에 lab01과 .gitignore생성
3. add -> commit -> push(Username : cocosome/password : rlawngus0807)
4. README.md 수정후 commit -> pull to ssh
5. input buffer와 output buffer에 대한 고찰
6. 고아 process
7. clobber option
8. buffer control
9. scanf의 return값
10. full buffer, line buffer, no buffer
11. pipe

>linux 명령어 모음
---
| name | Description |
| ----------- | ----------- |
|  mv | file을 옮기거나 file의 이름을 바꾸는데 사용되는 명령어 |
| rm | file을 지우는 명령어 |
| cc -o | file을 compile하고 output option을 주는 명령어 |
| ps [-l]| 현재 실행중인 프로세스를 보는 명령어|
| set -C| clobber금지 명령어 | 
| set +o noclobber | 덮어씌우기 허용 명령어 | 
| wc | line수 단어수 글자수를 세는 명령어|
| who | 누가 시스템에 로그인했는지를 보여주는 명령어 |
|sort | 정렬 명령어|
| ^g^h | 윗 명령어에서 g를 h로 바꿔서 다시 실행해 달라는 의미|
| ! |  history를 의미|
| !"명령어" | 가장 최근에 한 명령어를 실행 |


> 강의 내용
---
## Redirction
- 2>&1 : stderr를 stdout에도 보내는 리디렉션
- <<< : stdin에다가 <<<옆에 있는 값을 바로 넣어주는 리디렉션
- 2>> : stderr를 설정하되 결과값이 누적되도록 하는 리디렉션

```
cat << ENDEND
> 100
> 200
> 300
> ENDEND // 입력이 종료됨 이때까지 입력한 값들이 한번에 출력
100
200
300
- << : 마지막 line의 값을 설정(위의 예시에서는 ENDEND를 마지막 line으로 설정함)
```
## Pipe
- pipe : 앞 프로그램의 stdout을 뒤 프로그램의 stdin으로 전달하는 것
```
> cmd1 | cmd2
- cm1과 cmd2는 동시에 병렬로 실행된다.
- cmd1이 cmd2보다 빠르면 write가 block되고 cmd2가 cmd1보다 빠르면 read가 block된다.
- cmd1이 먼저 종료하면 pipe는 close되고 cmd2는 바로 EOF를 인식하여 종료한다.
- cmd2가 먼저 종료하면 pipe는 close되고 cmd1은 다음번 write에 SIGPIPE 신호를 받게되어 종료한다.
```
```
> echo 666 | .hello3.out 
> STDOUT : 666
> STDERR : 666
- echo 666의 output인 666을 .hello3.out의 input으로 들어간다
```
```
> |& 
- stdout과 stderr를 모두 뒤 프로그램의 stdin으로 보내는것
```

## Buffer
- buffer에 있는 값들을 인위적으로 방출하기 위해 fflush코드를 사용한다.

- setvbuf : buffering 형태를 정하는 코드
```
> setvbuf(stdoout, NULL, "모드", "버퍼크기")
- 모드에는 _IOFBF(full), _IOLBF(line), _IONBF(no)이렇게 3가지가 있다.
- _IONBF를 사용하면 buffering없이 바로 fflush를 한다. 또한 _IONBF는 버퍼크기가 의미가 없다.
```
### 이외에 배운 내용
- init process : 모든 process의 조상으로 0번 process이다
- clobber : 값을 덮어 씌우는것
- Enter : line buffer
- man 옆의 숫자의미 : section번호
- defense code : 어떻게든 무한루프에 빠지지 않도록 하는 코드
- $? : 가장 직전에 실행한 main 함수의 return값을 의미한다
- scanf : 함수 성공시 스캔한 숫자의 갯수를 return한다 EOF입력시 EOF를 반환한다.
```
> PATH="경로":$PATH
- "경로"를 path에 넣는 방법
```
## Class 3 - 23/2/8
> 강의순서
---
1. 전날 강의 복습
2. job control
3. named pipe
4. process 상태
5. git에 대한 간략한 설명
6. C 개발용 좋은 tool
7. c compiler
>linux 명령어 모음
---
| name | Description |
| ----------- | ----------- |
| jobs | 현재 수행중인 job목록을 보여줌 |
| fg [%"jobid"] | job이 fore ground에서 실행되도록 명령|
| bg [%"jobid"] | job이 back ground에서 실행되도록 명령 |
| kill "pid" or kill "%jobid"| process 혹은 job을 강제종료시키는 명령어 |
| ipconfig | 내 컴퓨터의 ip를 알 수 있는 명령어|
| cp -r | directory를 포함한 모든 file을 복사하는 명령어 (이미 복사된 것들은 덮어씌워진다) |
|mkfifo | named pipe를 만드는 명령어|
|sleep "숫자" | 숫자만큼 shell을 정지시키는 명령어|
|tee [FILE] | 왼쪽에서 받은 입력값을 stdout에 출력함과 동시에 오른쪽의 FILE에게 stdin으로 전달하는 명령어|
|tee [FILE] -a | tee명령을 실행할때 받은 입력값을 FILE에 기존에 입력되어있던 값을 바꾸지 않고 그 아래에 누적시키는 명령어|
| hostname | 내 위치를 정확히 알려주는 명령어|
|which "명령어"| 명령어의 저장 위치를 알려주는 명령어( shell 명령어는 which로 찾을 수 없다(ex cd:bash명령어))|
|whereis "명령어"| 명령어의 저장 위치 뿐만 아니라 해당 명령어의 메뉴얼 section위치까지 알려주는 명령어|
|file |파일을 읽어보고 어떤 파일인지를 판단하여 알려줌(확장자명 만으로판단 X) (ex : c source code : ASCII text) |
> 강의 내용
---

## process의 상태
1. run : process가 실행중인 상태 (fore ground와 back ground로 나눠짐)
2. suspend : process가 일시중지되어있는 상태
3. kill : process가 종료된 상태
```
> [1] - Running (sleep 90; echo "break") &
> [2] + Running (sleep 900; echo "break") &
- job이 run인 경우

> [1] - Done (sleep 90; echo "break")
- job이 끝난 경우

> [3] + killed (sleep 900; echo "break")
- job이 kill signal을 받은 경우
```
## fore ground와 back ground
- fore ground : process가 현재 shell에서 보이는 프롬프트에서 실행되고 있어 프롬프트를 사용할 수 없는 상태 - 만약 입력을 필요로 한다면 입력값이 들어오기를 대기하고 있음
- back ground : process가 현재 shell의 back ground에서 실행되고 있는 상태 - jobs 명령어를 통해 확인 가능하며 default stdin(key board)로는 값을 전달할 수 없기 떄문에 입력을 필요로 하는 프로그램인 경우 파일을 통해 입력값을 전달해야함
## Subshell
- subshell : 여러 작업이 병렬적으로 수행되도록 도와주는 또 하나의 shell을 생성하는 것
- pipe 작업시에도 두개 이상의 명령어의 출력 및 입력값이 전달 되기 위해 subshell이 생성된다.
- 하나의 명령을 소괄호에 넣어서 subshell로 수행시키는 것은 불가능
## Job Control
- ;(semicolon) : 여러개의 명령어를 순차적으로 연결할때 사용함(연결된 명령어들은 앞에서부터 차례대로 실행됨)
- & : 명령어 뒤에 &을 붙이면 해당 process는 background에서 실행됨
- ("명령어") : 명령어를 소괄호로 감싸면 해당 process는 subshell에서 실행됨
- { "명령어" ; "명령어" ... ;} : 여러개의 명령어를 순차적으로 연결한 후 해당 명령모음을 background에서 실행되도록 하는 방법 - 소괄호로 감싸면 subshell에서 실행되므로 반드시 중괄호로 감싸야 하며 중괄호를 닫기전 semicolon을 적어야 한다.

## Code Optimize
- if문은 프로그램 성능저하의 주된 원인이므로 가급적 사용을 자제한다
- if문 사용시 가장 발생률이 높은 조건순서대로 if - else if - else를 작성하는 것이 효율적이다. 최대한 else if 혹은 else문이 실행되지 않도록 하기 위함이다.
- if문 사용시 조건에 &&가 있는 경우, 최대한 결과가 false로 예상되는 조건을 앞에두어 여러개의 true이후 false를 발견하여 시간이 지연되는 것을 막는다. 
- if문 사용시 조건에 ||가 있는 경우, 최대한 결과가 true로 예상되는 조건을 앞에두어 여러개의 false이후 true를 발견하여 시간이 지연되는것을 막는다.

## Named Pipe and tee
- named pipe :
    기존의 cmd1 | cmd2와 같이 두 프로그램 사이에 pipe를 사용하지 않고 좀더 유연하게 pipe를 사용하기 위해 사용자 정의 pipe를 생성하는 것
- named pipe command : mkfifo "pipe이름"

- tee [FILE]: 왼쪽에서 받은 입력값을 stdout에 출력함과 동시에 오른쪽의 FILE에게 stdin으로 전달하는 명령어 - 왼쪽에서의 입력은 > 혹은 | 로 전달받을수 있으며 아무것도 없는 경우 stdin값을 입력으로 받아들인다. 또한 오른쪽에 FILE이 없는 경우에는 stdout이외에 따로 입력값을 전달하진 않는다|

## git cycle
1. untracked - git에서 version 관리가 되지 않은 file
2. modified - git에서 version 관리가 된적이 있고 현재 수정된 file
3. staged - repository에 upload하기전 upload 대상을 지정하는 것
4. commited - repository에 현재 staged된 file을 upload했다는 것
5. push - 다른 repository에 현재 repository에 commit된 file들을 upload한 것

## Compile and Excution
1. preprocessor directive : code내 #부분을 처리한다. - #define과 #include를 처리함 이후 .i file을 생성
```
> cpp gen.c > gen.i
```
2. compile user source code - generate assembly : assembly code를 생성한다
```
> gcc(cc) -S gen.i
> gcc(cc) -S gen.c
```
3. link assembler - generate excutable code : object code 생성후 link를 통해 excutable code를 생성한다
```
> as gen.s -o gen.o //object code 생성
> gcc(cc) -c gen.c //object code 생성
```
4. loader - load the excutable code into memory

- .c 파일을 비롯한 .i .s .o파일 모두 cc를 통해 .out파일을 생성할 수 있다.

### 이외에 배운 내용

- 리디렉션은 명령어의 어디에 있든 상관 없다
- shell에서는 모든 입력을 문자로 인식 - 한글자를 1byte로 계산한다
-  \`명령어\`: 명령어의 결과값으로 대체된다
return 값 255 : ctrl + d를 의미
- *는 글로빙이다.
- shell에서는 main 함수의 return값이 0이면 true이다
- linux명령 철학 : 할수있는 작업은 모두 수행하고 불가능한 작업에 대해서는 에러를 발생시킨다 - 에러가 발생했다고 해서 모든 작업이 수행되지 않은것은 아니다 - 수행 가능한 작업은 완료되어있음
- control z : 작업을 suspend 시키는 명령어
- CUI : character base interface

* 내 pc에 git clone 하고 readme.md 파일 수정했어요

## Class 4 - 23/2/9
> 강의순서
---
1. file과 inode
2. cpp - assembly - link - load
3. dynamic link 와 static link
4. basic data type
5. 음수 표현 방식
6. float
>linux 명령어 모음
---
| name | Description |
| ----------- | ----------- |
|  ls -li| file의 inode 값을 보여주는 명령어 |
| ls -ld [directory]| [directory]가 해당 명령 뒤에 있다면 해당 [directory] 에 대한 정보를 보여주는 명령어|
| date | 시간을 보여주는 명령어 |
|ldd | 실행파일을 load and excute할때 필요로 하는 library가 무엇인지 보여주는 명령어|
|uname| 현재 system 정보를 출력|
|uname -a | 현재 system 정보를 더 자세히 출력|
|cc --static [FILE]| 기존에 dynamic linking으로 하던 작업을 static linking으로 전환하여 compile하는 명령어|
|nm [FILE]| 실행파일이 loading될때 필요로 하는 memory 정보를 출력하는 명령어|
|cc -m32 -o [실행FILE]|실행 FILE을 32bit형식으로 compile하는 명령어 |
> vi 명령어 모음
---
| name | Description |
| ----------- | ----------- |
| dw| 한 단어 삭제 |
| cw | 한 단어 수정 |
| c | 한 글자 수정|
> 강의 내용
## Dynamic link and Static link
---
- dynamic link(shared library link) : 자주 사용하는 외부 함수를 실행 프로그램에 포함시켜 거대한 크기의 외부 library를 다시 compile해야하는 부담을 줄이기 위해 공유 library를 생성해 놓고 compile시점에 필요한 library만 link하는 방식  
- static link : 외부 함수를 포함해서 프로그램을 만드는 것 - 프로그램의 규모가 커지는 부담이 있다. 
- 기본적으로 compile시 default link 방식은 dynamic link이다.
## Basic Data type
---
- 기본적으로 사용하는 자료형에는 char, short, int, long, long long, float, double등이 있으며 부호의 여부에 따라 signed와 unsigned로 나눠진다.
- 각 자료형은 시스템(os)에 따라 할당되는 크기가 다르다
- C data model table
![alt text](/c%20data%20table.png)

## 음수 표현 방식
---
1. signed magnitude(부호 절댓값 방식)
- MSB부분을 sign bit로 사용하고 나머지 bit를 value로 사용한다.
- sign bit가 0이면 양수, sign bit가 1이면 음수로 표현한다
2. one's complement
- 양수로 표현된 bit의 complement시킨 값을 음수로 사용한다
- ex) 01011(11) -> 10100(-11)
- +0 과 -0이 생성되는 문제 발생

3. two's complement
- 양수로 표현된 bit의 complement시킨 값에 + 1을 더한 값을 음수로 사용한다.
- 0001(1) -> 1110 + 1 = 1111(-1)
- 음수로 표현된 bit를 양수로 바꿀 때는 음수 bit를 complement한 후 1을 빼주면 된다.
- 1100(-4) -> 1100 -1 = 1011 -> 0100(4)

## Float
---
![alt text](/float.png)
- sign : 부호 표현 bit
- exponent : 지수 표현 부분 - 2^(exp-127)에서 exp값에 해당함
- fraction : 숫자의 magnitude를 담당
- half, double, quadruple 모두 비슷한 구조로 되어있으나 전체 bit수가 다르다.

### 이외에 배운 내용
---
- 부모 directory가 파손되었을때 하위 file들은 disk1의 lost + found directory에 옮겨진다.
- /  = root directory를 의미한다.
- UTC : 세계 표준 시간
- 프로그램의 성능을 높이다 보면 프로그램의 크기가 커질 수 있다 
- macro를 사용시, 변수를 사용할때는 변수앞뒤로 괄호를 넣어야 추후 문제가 발생하는 것을 막을 수 있다.
- 시스템 마다 return 값의 범위가 정해져 있어 return값이 해당 범위를 벗어났을 때 return 값이 바뀔수 있음을 고려해야한다 - bash에서는 return값이 0~255를 벗어난 경우, 해당 return값을 255로 나눈 나머지를 return값으로 사용한다.
```
> gcc(cc) -E gen.c // i file 생성
> cpp gen.c > gen.i // i file 생성
```
- code내에서 사용하지 않은 library 혹은 헤더파일을 include 하면 compile시간만 늘어나므로 주의해야 한다.
- 자연수는 끝이 없기 때문에 컴퓨터의 유한한 메모리로는 자연수를 표현할 수 없다
- !$ : 이전 명령어의 파라미터

## Class 5 - 23/2/10
>linux 명령어 모음

| name | Description |
| ----------- | ----------- |
|cc -m32 -D"macro" | 32bit compile과 동시에 "macro"정의 |
|cc -m32 -D"macro"="value" | 32bit compile과 동시이 "macro"를 정의하고 해당 "macro"에 "value"를 할당|
| cc -Wall | compile시 모든 warning을 표시하도록 하는 명령어|
| alias 명령어1='명령어2' | 명령어1을 입력했을때 명령어2가 수행되도록 설정하는 명령어 |
| unix2dos | file 형식을 unix에서 dos로 바꾸는 명령어|
| od [file] | FILE을 8진수 형태로 전환하여 stdout으로 출력하는 명령어 - os에 따라 endian과 LF, CR 사용 유무가 달라진다 |
|od -x [file] | FILE을 16진수 형태로 전환하여 stddout으로 출력하는 명령어 - os에 따라 endian과 LF, CR 사용 유무가 달라진다|
| strings | object파일 혹은 실행파일에 string이 있다면 이를 출력해주는 명령어|
|cpp -trigraphs [FILE]| trigraphs 옵션을 추가하여 전처리 하는 명령어|
|time | 프로그램의 실행시간을 측정하는 명령어|
|clear | terminal buffer초기화|

> vi 명령어 모음

| name | Description |
| ----------- | ----------- |
| % | 괄호 위에서 %입력시 짝이 되는 괄호로 이동 - 없는 경우 소리가 울림 |
> 강의 내용

## C Preprocessing
---
### 1. 정의
- c code 이외에 포함된 헤더파일이나 #define으로 정의된 macro를 c code로 바꾸는 작업

### 2. 순서
1. Character set : utf-8
2. Initial processing
3. Tokenization with space
4. Preprocessing language

### 3. Initial processing
1. LF, CR LF, CR processing : file내 줄바꿈사용시 unix는 LF, dos-window는 CR LF, MAC os는 CR값등등 서로 다른 값이 들어가기 때문에 C compile이전에 cpp에서 unix2dos 혹은 dos2unix와 같은 명령어로 이를 통일 하는 작업

2. trigraphs processing : \, *,  & 와 같은 기능을 가진 문자들을 문자 그대로 사용하기 위해 trigraphs를 사용 하여 표현 후 이를 복구 하는 작업

    ![alt text](/trigraph.png)

3. " \ " merge

4. commet 제거

### 4. Tokenization with space
- macro로 정의된 identifier를 value로 바꾸는 작업이 수행된다 - 이때 항상 공백도 같이 토큰화된다.

### 5. Preprocessing language
1. Conditional Compile
    - compile time에 preprocessing directive를  조정함으로 code를 직접 수정하지 않고도 code내 특정 부분의 조건을 다르게 설정할 수 있다.
    ```
    > cc -m32 -D__pcc_32

    - 32bit로 compile함과 동시에 __pcc_32라는 macro를   선언
    ```
    ``` 
    > cc -m32 -D__pcc_32=10

    - 32bit로 compile함과 동시에 __pcc_32라는 macro선언 및 해당 macro에 10 할당
    ```
    - -m32 옵션 대신에 -m64를 사용하거나 -m32를 생략하는 경우 64bit로 compile

    ```
    > cc -m32 -U__pcc_32

    - 32bit로 compile함과 동시에 __pcc_32라는 macro 선언을 삭제(?)
    ```
    - \#if [조건] : 조건이 참인 경우 하위 code에 진입 
    ```
    #if 0 
    ...
    #endif

    - 조건이 항상 false 이므로 ...에 위치한 code는실행되지 않는다.
    ```
    - \#ifdef [identifier] : identifier가 정의 되어있는 경우 하위 code에 진입
    - \#ifndef [identifier] : identifier가 정의 되어있지 않은 경우 하위 code에 진입
    - \#endif : #if, #ifdef, #ifndef와 항상 쌍으로 존재하는 directive
    - 위의 directive 이외에 #elif 와 #else도 존재한다.
    ```
    #ifndef _MATH_
    #include <math.h>
    #endif

    - _MATH_ 가 정의되어 있지 않다면 <math.h> file을 include 하는 code
    ```
    - #pragma once : include가 여러번 되어 있더라도 cpp했을때 include가 한번만 처리되도록 하는 지시어
    - \#define [symbol] [value]에 value값이 없다면 symbol에는 null값이 할당된다.
2. Line Control
    - \#line 숫자 "file 이름" : file내에서 #line macro가 정의된 위치의 line number값을 숫자 값으로 변환 - 아래 line부터는 숫자+1이 된다. 
3. Macro Expansion
    - 기본적으로 macro는 정의된 위치 부터 사용이 가능하며, 정의된 위치보다 위에서 해당 macro를 사용할 순 없다.
    - 일반적인 macro 형태 : #define [identifier] [replacement token list] - identifier는 한번에 여러개 지정하여 token으로 바꿀 수 없으며 identifier에는 operator를 쓸 수 없다
    ```
    > #define AAA BBB 10 20 

    - 위와 같이 AAA와 BBB를 동시에 정의 불가능
    ```
    - 함수형 macro : #define f(a) [replacement token list] -> text string을 replace한다
    ```
    > #define f(a) a*a
    > b=f(20+13) / 20+13*20+13으로 값이 바뀌어 본래 목적인 제곱이 아닌 다른 계산이 이루어진다

    - 위와 같이 text string replace가 일어나기 때문에 함수형 파라미터를 작성할 때는 모든 파라미터에 괄호를 사용해야 한다.
    ```
    - stringization : token앞에 #을 붙여 string으로 변환할 수 있다. 
    ```
    > #define f(a) #a 
    > #define foo 4
    > str(foo)

    - 출력값 : "foo"
    ```
    - concatenation : 두 token사이에 ##을 사용하여 token을 연결시킨다.
    - strinization, concatenation, variadic, minesting은 가급적 사용하지 않도록 한다.
## Compile option
---
```
> gcc -c [FILE] //object code 생성
> gcc -E [FILE] //cpp 수행
> gcc -S [FILE] //asembly code 생성
> gcc -g [FILE] //debug mode(성능저하, 프로그램 크기 증가)
> gcc -pg [FILE] // 코드의 성능 분석 옵션
> gcc -O "숫자" [FILE] // 코드 최적화 옵션
> gcc -o // output file 이름 지정
- debug mode와 optimize mode는 동시에 지정 불가능
```
## Charater Set
---
- ! : bat
- @ : at
-  \# : pound mark
- $ : dollar
- % : percent
- ^ : caret
- & : ampersand
- \* : star or asterisk
- \- : dash or minus
- _ : underscore or underbar
- | : pipe
- \ : backslash
- () : parentheses
- {} : brace
- [] : square parentheses
- " : quotation mark
- "" : double quote
- ` : back quote

### 이외에 배운 내용
---
- .c file은 추후 debug를 생각했을때 #include로 포함시키지 않는 것이 좋다.
- BS : backspace(0x08) = ctrl + h
- CR : carriage return(0x0D)
- LF : linefeed(0x0A)
- terminal에서 보이는 window에도 buffer가 존재하기 때문에 clear 명령어를 통해 buffer의 내용을 삭제할 필요가 있다.
- compile error시에는 a.out
load중 error시에는 a.out가 지워진다.
warning시에는 일단 a.out를 새로 만들긴 한다
- undefine 아래에서는 위의 함수가 작동하지 않는다
- \_\_FILE__ : 현재file 이름을 반환하는 macro
- \_\_LINE__ : 현재 line의 번호를 반환하는 macro

## Class 6 - 23/2/13
> vi 명령어 모음

| name | Description |
| ----------- | ----------- |
| :r [FILE] | vi하는 도중 특정 file의 내용을 읽어버린다 |
> 강의 내용

## Memory Model
---
### 1. Models
1. manual : heap영역에 할당되는 변수
    - malloc : memory를 할당하는 함수(쓰레기 값이 있을 수 있다)
    - realloc : 할당된 memory의 크기를 재할당하는 함수 
    - calloc : memory를 할당한 후 0으로 값을 초기화하는 함수
    - free : 할당된 memory 해제
    - 기본 형식 : int \*pi = (int \*)malloc(sizeof(int)\*10);
    - malloc으로 할당한 pointer앞에 static keyword는 사용할 수 없다.
    ```
    free(pi); pi = NULL;

    - pi를 free하는동안 누군가 pi를 사용할 수 있으므로 pi에 NULL을 할당하여, pi 사용시 error가 발생시키는 기법
    ```
2. auto : 지역변수
3. static : compile시 memory공간이 할당되며, program이 실행될때 부터 종료될 때까지 같은 memory 공간에 할당되어 있는 변수 - 전역변수와 특징이 같다
    - static으로 정의된것이 배열이라면 그 크기는 고정이고 그안에 값은 바꿀 수 있다.
    - main 함수가 실행되기전 초기화 된다 - 전역변수와 특징이 같다.
    - static으로 선언된 변수를 다른 file에서 extern을 이용하여 사용할 수 없다. - file scope이다.
### 2. Model Property
---  
![alt text](/memory_model.png)
1. Set to zero on startup : 선언시 자동으로 0으로 초기화 된다.
    ```
    static int a;

    - a는 0으로 값이 초기화 되어있다.
    - 그럼에도 명시적으로 값을 써주는 것이 좋다.
    ```
2. Scope-limited
    - static과 auto의 경우 {} 에 의해 scope가 결정되며 manual은 scope제한이 없다.
3. Can set values on init
    - 선언과 동시에 value를 초기화 할 수 있다.
    ```
    static int a = 10;
    int b = 20;

    - static과 auto는 위와같이 선언과 동시에 value를 지정할 수 있다. manual은 불가능!
    ```
4. Can set nonconstant values on init
    ```
    int f(int a, int b)
    {
        int z = a;
    }

    - auto의 경우 위와 같이 z를 초기화 할때 constant값이 아닌 변수 a로 초기화 가능하다 
    ```
5. Sizeof measures array size
    - static과 auto는 sizeof로 변수의 크기를 잴 수 있지만 manual의 경우 pointer의 크기를 잴 순 있지만 pointer가 가리키는 memory의 크기는 잴 수 없다.

6. Persists across function calls
    - static과 manual은 파라미터로 memory주소값을 주기 때문에 함수를 나오더라도 변경된 값이 계속 유지되지만 auto는 함수를 나가는 순간 사라진다.
7. Can be global
    - static과 manual은 전역으로 사용가능하지만 auto는 지역변수로 밖에 사용할 수 없다.
8. Array size can be set at runtime
    - manual은 malloc과 calloc을 통해 runtime에 array size를 설정할 수 있다.
    ```    
    int f(unsigned int size){
        int buf[size];
    }

    - auto는 위와 같이 runtime에 array size를 설정할 수 있다
    ```
    - static은 불가능하다.
9. Can be resized
    - manual의 경우 realloc을 이용하면 runtime에도 size를 조절할 수 있지만 static과 auto는 불가능하다.

## Const
---
- const는 const 앞에 위치한 다른 keyword를 상수화 하여 한번 값이 할당되면 값을 바꾸지 못하도록 하는 기능을 한다.
- 만약 const 변수의 값을 바꾸려고 한다면 compiler가 error를 발생시킨다.
- const 변수값 자체는 바꿀수 없지만 해당 변수의 주소를 이용하여 pointer를 통해 값을 인위적으로 compiler모르게 바꿀순 있으나 이는 좋은 방법이 아니다 - 잠재적 error
```
< int const A ( == const int ) >

- const가 int를 수식한다. A는 한번 값이 할당되면 바뀌지 않는 자료형 int변수이다.

< int const * A (variable) >

- const가 int를 수식하며 *가 있으므로 A는 pointer이다. A는 주소를 가리키는 pointer이며 해당 주소의 value는 적어도 A를 통해서는 바꿀 수 없다.

int a[2] = {10,10};
int const *b = a;
b* = 200; // error O
a[0] = 150; // error X

< int * const A> 

- const가 int*을 수식하며 *가 있으므로 A는 pointer이다. A는 주소를 가리키는 pointer이며 A가 한번 주소를 point하면 다른 주소로의 point는 불가능하다.

int a[2] = {10,10};
int * const b = a;
b = a[1] // error O
b* = 200; // error X
```
### 이외에 배운 내용
---
- project관련 내용
    1. 주어진 bit로 표현할 수 있는 가장 큰 수와 가장 작은 수를 기재해야 한다.
    2. -m32와 -m64환경에서 compile이 서로 다르게 동작해야 한다
    3. resolution(해상도) : 주어진 bit로 표현할 수 있는 가장작은 단위 수 - I : 8, F : 4인경우 00000000.0001이 해상도 값이다.
- global variable의 이름은 전역에서 사용되기 떄문에 다른 지역변수와 이름이 겹쳐서는 안된다. 그래서 변수명을 길게 작성하는것이 좋다.
- extern으로 선언된 변수에는 값을 지정할 수 없다.
- unsigned 변수의 가장 작은 숫자는 0이다.
- -1은 자료형 크기와 상관없이 모든 자릿수를 1로 채운 값이다.
- 같은성능일때, cpu보다 gpu로 graphic작업을 수행하는게 전력을 더 적게 소비한다.
- 전역변수는 memory를 할당해줘야 하기 때문에 .h file이 아닌 .c file에 작성해야 한다.

## Class 7 - 23/2/14
> 강의 내용

## Pointer
---
- pointer는 특정 memory의 주소를 가리키기 위한 자료형이다.
- 배열은 선언한 순간 그 주소값이 바뀌지 않지만 pointer는 주소값이 바뀔수 있다.
- 자주 사용되는 표현 :
    ```
    int vector[5] = {1, 2, 3, 4, 5};
    int *pv = vector;

    - *(pv + i) == pv[i] == *(vector + i) // 세가지 표현 모두 같은 의미를 가진다
    ```
- 선언시 유의점 :
    ```
    int* a, b;

    - 위와 같이 선언한 경우 a는 int pointer, b는 int 자료형을 가지게 되므로 a와 b모두 pointer로 선언하고 싶다면 int *a, *b; 이렇게 작성하는것이 옳다.
    ```
- Function Pointer
    - 함수가 memory상에 저장된 위치를 가리키기 위한 pointer
    - 기본형태 : float(*f)(int, double) // int와 double을 파라미터 return은 float
    - 여러가지 함수중 하나를 runtime에 입력값을 통해 선택하려할때 funtion pointer를 사용하면 유용하다.
    - 예시 : 
    ```
    int add(int a, int b){
        return a+b;
    }

    int mul(int a, int b){
        return a*b;
    }
    int (*ff[2])(int, int) = {add, mul};

    - 포인터를 배열형태로 선언하여 ff[0]은 함수 add를, ff[1]은 함수 mul을 point한다.
    - ff[0](10 , 20)과 같이 작성하면 add함수가 작동하여 10 + 20값인 30이 반환된다
    ```

- void poiner
    - 모든 데이터 자료형을 가리킬 수 있는 특별한 타입의 pointer
    - 자료형이 무엇이든 주소값만을 point하기때문에 pointer가 가리키고 있는 주소의 값을 읽기 위해서는 다른 자료형으로 typecasting을 해야 한다.
    - 예시 :
    ```
    #include <stdio.h>
    
    int main() {
        int a = 10;
        void *b = &a;
        printf("%d\n", *(int*)b);
    }

    - 위코드 에서는 void pointer인 b앞에 (int*)로 type casting을 해주었다.
    ```

## Function Call Memory
---
![alt text](/function%20call%20memory.png)
1. Stack : 함수 호출시 지역변수, return 주소, 다른 함수의 파라미터등이 저장되는 부분 - return시 해당 함수가 할당받은 부분은 사라진다
2. Heap : 동적 memory를 할당하는 부분 - malloc과 같은 함수를 사용할 때 compiler가 미리 필요로 하는 heap memory 크기를 측정함
3. Static data : 전역변수 혹은 함수내 static변수가 저장되는 부분 - process시작시 초기화된다.
4. Literals : #define macro와 같은 symbol이 저장된 부분
5. Instructions : 실제 code가 저장되어있는 부분 - read만 가능

![alt text](/stack.png)
- Stack에는 함수호출시 함수의 Parameters, Return address, Locals(지역변수)가 순서대로 저장된다.
- Parameters는 함수 호출시 자신을 부른 함수로 부터 받은 인자값들이다.
- 그림상에서 Stack의 가장 아래부분에는 처음으로 호출을 받은 main함수가 있고 그 위로 다른 함수들이 stack형식으로 쌓인다.
- 또한 stack pointer와 frame pointer가 존재하여 현재 stack에 어느 위치에 있는지를 표시한다. 만약 함수가 return되면 pointer들은 이전에 함수를 호출했던 위치로 돌아가게 된다.
## po2.c 노트
---
- code(po2.c)
```
#include <stdio.h>
#include <stdlib.h>
int func(int **p){

        printf("Func:%p %p\n",p,&p);
        *p = (int *)malloc(8);
        *p[0]=500;
        printf("Func:%d %p %p %p\n",*p[0],*p,p,&p);
        return  0;
}
int main(){
        int *ppp=NULL;
        printf("Main:%p %p\n", ppp, &ppp);
        func(&ppp);
        printf("Main:%d %p %p\n",*ppp, ppp, &ppp); 
        return 0;
}
```
- 결과값(./a.out)
```
pcc010@ssh:~/pcc/lab07$ ./a.out 
Main:(nil) 0x7ffe4f1e3bd0
Func:0x7ffe4f1e3bd0 0x7ffe4f1e3ba8
Func:500 0x55aa5a2716b0 0x7ffe4f1e3bd0 0x7ffe4f1e3ba8
Main:500 0x55aa5a2716b0 0x7ffe4f1e3bd0
```
- 분석
    1. p의 값 : func함수에서 파라미터 **p는 main 함수로 부터 &ppp를 전달받았으므로 p의 값은 ppp의 주소값과 동일하다
    2. *p의 값 : *p는 ppp가 가진 값이므로 다시말하면 ppp가 point하고 있는 값이다. main에서 처음으로 ppp가 선언되었을 때는 NULL이지만 *p에 malloc을 통해 memory를 할당한 이후에는 heap영역의 주소값을 가지게 된다. 그래서 결과값 첫번째줄에서 ppp의 값은 (nil)이었지만 마지막줄에서 ppp의 값은 0x55aa5a2716b0를 가지게 된다. 또한 세번째 줄을 보면 func함수내에서 *p값은 0x55aa5a2716b0로 ppp와 동일한 값을 가지고 있음을 알 수 있다.
    3. *p[0]의 값 : *p[0]는 malloc함수로 할당한 영역의 첫번째 index에 있는 값을 의미한다. func함수에서 *p[0]에 500을 할당하였으므로 결과값 세번째 줄을 보면 *p[0]값이 500으로 나와있는 것을 확인할 수 있다. 또한 *p와 ppp가 가리키는 주소값이 같기 때문에 *p[0]에 작성한 값은 main 함수에서 *ppp를 통해 구할 수 있다. 그래서 결과값 마지막줄을 보면 *ppp값이 500으로 *p[0]와 같은 값을 가지고 있음을 알 수 있다.
### 이외에 배운 내용
---
- 함수포인터로 쓰레드를 만든다.
- 프로그램 실행중 memory 부족시 shell 혹은 os가 system call을 통해 process를 중단시킨다.
- 함수 안에서 static 변수를 선언하면 runtime에 static 변수가 계속 초기화 되지 않는다.
```
int func(int a){
    static int counter = 0;
    counter++;
    printf("%d\n",counter);
    return 0;
}

- 위와같이 code를 작성하면 func함수가 호출될 때마다 counter가 0으로 초기화되지 않고 값이 1씩 증가한다. - static이므로 memory 공간이 함수 호출할 때 마다 만들어 지는 것이 아니라  프로그램 종료 전까지 유지되기 때문이다.
```
- array를 보내는 함수에서는 size를 파라미터로 보내주는 것이 좋다 - size 이상의 범위를 참조하여 error가 발생할 가능성을 줄여준다.
- pointer에 관련된 것은 #define macro형태로 만들지 않는것이 좋다.

- project 관련 내용
    1. 입력값은 주어진 S, I, F내에서 만들 수 있는 float 숫자이다. - unsigned 56 - 8인 경우 0xFFFFFFFFFFFFFF.FF ~ 0이다
    2. 범위내에서 랜덤으로 입력값을 1000개 생성 후 이들의 덧셈 뺄셈 곱셈 나눗셈을 구한다. - 랜덤값은 시드를 바꾸지 않고 생성하면 늘 같은 랜덤값이 생성된다.
    3. 범위내 숫자들의 사칙연산에서 overflow의 발생을 막을 필요는 없다. 다만 발생했음을 기재해야 한다.
    4. float숫자들을 입력받았을 때 기본적으로 주어진 F bit 만큼을 left shift한 후 int 혹은 long long 형태로 type casting을 하고나서 계산을 해야 한다 - 이는 float형 계산이 아닌 int형 계산을 하기 위함이다.
    5. 덧셈과 뺄셈은 크게 고려할 사항이 없다.
    6. 곱셈의 경우 두 숫자는 (I1 * 2 ^ -F) * (I2 * 2 ^ -F)형태를 취하고 있다. 우리가 원하는 것은 결과값은 I3 * 2 ^ -F 형태를 취해야 하므로 실질적으로 I1 * I2 * 2 ^ -F를 해주어야 한다. - 총 3종류의 곱셈방법을 구현해야 한다.
    7. 나눗셈의 경우 (I1 * 2 ^ -F) / (I2 * 2 ^ -F) 계산을 해야 한다.
    8. 또한 프로그램이 32bit compile과 64bit compile 모두 가능하도록 설계해야 한다.
    9. 자주 사용하는 상수인 PI, log 10, log 2, e, 2 ^ F, 2 ^ -F는 팀원과 상의하여 정의해두어야 한다.
    10. 추가로 sin, cos, tan, square에 관한 표를 교수님께서 제작해 주시면 이에대한 것도 구현시 + 점수를 얻는다.(필수X)
    11. 프로그램 구현 완료시 성능 분석을 한 후 보고서를 작성해야 한다.

- 궁금한 점
    1. 32bit compile과 64bit compile의 차이점이 무엇인가?
    2. 나눗셈의 경우 long long형태로 계산하면 몫과 나머지가 발생하는데 나머지에 대한 계산은 어떻게 처리할 것인가?


## Class 8 - 23/2/15
>linux 명령어 모음

| name | Description |
| ----------- | ----------- |
| diff [FILE1][FILE2] | 두 파일의 차이점만을 출력해서 보여주는 명령어|
| ls -l \| grep [항목] | ls -l한 결과값중 항목에 부합하는 값만을 출력하는 명령어|
| cc -g [FILE] | -g option으로 compile하는 명령어|
| gdb [exeFILE] | gdb mode로 전환하는 명령어|
| cc -pg [FILE] | FILE을 profile option으로 compile한다.|
| gprof [실행파일] [gmon.out] | 해당 명령어 입력시 실행파일에 대한 profile내용을 출력한다.|
| gprof -b [exeFILE] [gmon.out] | 해당 명령어 입력시 실행파일에 대한 profile내용중 flat profile과 call graph만을 출력한다.|
|cc -pg -g [FILE] | profile 및 debug option으로 compile|
| gprof -A | cc -pg -g [FILE]명령어 수행 이후 gprof -A명령어 입력시 source code에 특정함수가 얼만큼 호출되었는지를 주석처리한 후 stdout으로 출력하는 명령어|
|time [실행파일] | 해당 실행파일을 실행하는데 얼만큼의 시간이 걸렸는지를 출력하는 명령어|
> 강의 내용
## Debugging(gnu)
---
- gdb 사용법
    1. compile시 -g option으로 compile한다.( cc -g [FILE] )
    2. 만들어진 실행파일(exeFILE)을 가지고 gdb [exeFILE] 명령어를 실행시킨다
    3. gdb mode로 전환된다.
- gdb 기능
    1. run : process를 새로 실행한다. 이미 실행중이라면 재시작 한다. (error 발생시 발생 위치를 알려준다.)
    2. print [variable or address] : 변수 혹은 주소값을 출력한다.
    3. list : 현재 process의 code를 10줄씩 출력해서 보여준다. (linenumber도 출력됨)
    4. break [linenumber] : 해당 linenumber에 breakpoint를 찍는다.
    5. continue : 다음 중단점까지 프로그램을 재개한다.
    6. conitnue n : 프로그램을 재개한다. 중단점을 n번 건너뛴다.
    7. next : 실행중인 프로세스를 한줄 실행한다. 함수 실행시 내부로 진입 X
    8. next n : 실행중인 프로세스를 n줄 실행한다. 함수 실행시 내부로 진입 X
    9. step : 실행중인 프로세스를 한줄 실행한다. 함수 실행시 내부로 진입
    10. step n : 실행중인 프로세스를 n줄 실행한다. 함수 실행시 내부로 진입
    11. finish : 현재 함수를 수행하고 빠져나간후 리턴값을 출력한다.

- 그냥 gdb만 입력하면 default로 gdb ./a.out을 수행한다.
- segmentation fault 발생시 /var/lib/apport/coredump 에 위치한 파일중 가장 최근에 만들어진 core파일을 대상으로 gdb [exeFILE] [core파일] 입력시 debug내용을 보여준다.

## Optimization
---
- Golden Rule(최적화의 기본 규칙)
    1. speed : CPU > Memory(register > cache > main) > Storage > IO > Human 순서로 빠르다.
    2. Locality를 고려 : 한번 참조된 memory주소는 다시 참조될 가능성이 높으며 해당 memory의 주변 주소또한 참조될 가능성이 높다 - 이를 고려해야 한다.
    3. Pipeline유지 : pipeline을 막는 조건 제어문의 사용을 줄이는 것이 좋다.
    4. Error 방지 및 줄이기

## Pipeline
---
- 정의 : 단계가 n개일 때, pipe를 사용하지 않았을 때 보다 최대 n배에 가까운 성능을 보여주는 병렬적 data 처리 방식
- pipebroke : pipe가 stall된 상태 - (예시) if문과 같은 조건문을 사용했을때 조건의 참 거짓을 판단하기 전까지 다른 작업이 불가능하여 발생

## Gcc Optimization
---
- O0(기본값) 최적화를 수행하지 않는다.
- O1 코드 크기와 실행 시간을 줄이는 것을 제외한 최적화는 실행하지 않는다.
- O2 메모리 공간과 속도를 희생하지 않는 범위내의 모든 최적화를 수행한다.loop unrolling과 function inlining에 대한 최적화를 수행하지 않는다.
- O3 -O2 최적화에 인라인 함수와 레지스터에 대한 최적화를 추가로 수행한다.
- Os -O2 최적화 기능을 사용하지만, 코드 크기를 증가시키는 최적화는 생략한다.

## GNU Profiling
---
- profile은 프로그램의 성능을 측정하기위해 시행한다.
- profile을 통해 프로그램에서 어떤 함수가 얼마나 호출되고 함수간 수행속도를 비교할 수 있다.
- profile 순서 :
    1. cc -pg [FILE] : FILE을 profile option으로 compile한다.
    2. compile 이후 생성된 실행파일을 실행한다.
    3. 실행파일 실행시 gmon.out파일이 생성된다.
    4. gprof [실행파일] [gmon.out] : 해당 명령어 입력시 실행파일에 대한 profile내용을 출력한다.
    5. gprof -b [exeFILE] [gmon.out] : 해당 명령어 입력시 실행파일에 대한 profile내용중 flat profile과 call graph만을 출력한다.
- flat profile : code에 작성한 함수들의 총 실행시간(self second)와 총 호출 횟수(call) 그리고 호출당 실행시간(ns/call)등을 출력한다 - 해당 자료에 나온 second는 절대적인 지표로 사용하기 보단 함수간의 상대적인 차이를 비교하기 위한 지표로 사용해야 한다.
- call graph : 특정함수가 다른 함수를 얼만큼 호출하였고 자신은 얼만큼 호출되었는지가 적혀있다.
 - c -pg -g [FILE]명령어 수행 이후 gprof -A명령어 입력시 source code에 특정함수가 얼만큼 호출되었는지를 주석처리한 후 stdout으로 출력한다.

- time [실행파일] : 해당 실행파일을 실행하는데 얼만큼의 시간이 걸렸는지를 출력하는 명령어
- time 명령어 예시
    ```
    time ./main 
    100
    1000 / 10000
    00000000000000000000000001100100
    777

    real    0m2.614s // 실제로 걸린 시간
    user    0m0.001s // user가 사용한 cputime
    sys     0m0.000s // system이 사용한 cputime
    ```
### 이외에 배운 내용
---
- 64bit 컴퓨터에서는 32bit compile시 이뮬레이트를 통해 compile한다.
- automatic type casting : 연산의 첫번째 항에 type casting을 해주면 그 결과값 또한 정상적으로 type casting 된다
- automatic type casting 예시
    ```
    int a, int b
    1.0f * a * b; - float형태로 바뀜
    a * b * 1.0f; -  오류가 날 수도 있다
    ```
- project 관련 내용
    - 곱셈과 나눗셈에 관련된 함수를 작성할 때 기준이 되는 float 계산 함수를 먼저 작성해야 한다 -> 그냥 float * float 혹은 float / flaot 값을 도출하는 함수이다
    - 사칙연산에 입력값으로 받은 fixed들은 실제 값은 fixed값에 2^-F가 붙은 값이고 그래서 현재는 원래 값에서 2^F이 곱해진 값이다.
    - fixed.h는 마지막 팀프로젝트로 제출전 4명이 합친 파일을 제출해야 한다.
    - 합쳐진 프로젝트에서 test를 할때는 한명의 main.c로만 test해도 무방하다.
    - 또한 여러개의 곱셈 함수를 만들었더라도 합쳐진 프로젝트의 main.c에서 test할 때는 하나의 함수만 사용하면 된다.
    - overflow또한 확인한다.
    - 정밀도 분석
        1. 곱셈, 나눗셈 함수를 작성 한 후 testcase값을 입력하여 계산이 정확한지 printf로 출력한다 - 정밀도 분석은 성능이 낮아도 되기 때문에 printf를 사용해도 상관X
        2. 여러개의 함수들로 부터 계산된 출력값들이 기준이 되는 float함수와 비교했을 때 얼만큼 다른지를 확인한다 - fixed로 계산된 결과값을 다시 float화 하여 기준함수의 결과값과 비교한 후 오차를 분석한다
        3. 어떤 값에서 오차가 발생하는지, 어느 숫자부터 오차가 커지는지를 파악해야 한다. - 오류가 나는 지점 파악
        4. 64bit와 32bit에서도 차이가 발생하는지 확인
    - 성능 분석
        1. 곱셈, 나눗셈 함수를 작성 한 후 testcase값을 입력하여 얼마나 시간이 걸렸는지를 측정한다
        2. printf를 사용하여 결과값을 출력하면 성능이 떨어지기 때문에 가급적 사용하지 않는다
        3. 함수가 정확히 계산했는지는 정밀도 분석에서 하는 것이기 때문에 속도만 확인한다.
        4. 속도 확인은 profile작업을 통해 확인한다
        5. 64bit와 32bit에서도 차이가 발생하는지 확인

- project 보고서 관련(README.md) - table of content를 이용해볼것
    1. 가지고 있는 bit로 만들 수 있는 최대, 최소, 해상도값이 들어가야 한다.
    2. 특정 계산 함수에 어떤 값을 넣었을 때 오류가 나고 왜 오류가 나는지 작성해야 한다.
    3. 어떤 상수값을 define했는지 작성한다 - 소수부길이, 변환시 사용하는상수, PI 등등을 fixed.h에 선언한다
    4. conversion macro를 작성한다 - int, long, short, long long double, float에서 fixed로 서로 변환하는 매크로 함수
    5. 여러가지 곱셈, 나눗셈 함수를 작성한 후 각 함수를 option을 통해 사용할 수 있도록 설계한다.
    6. 오차에 관한 내용도 적어야 하며 사용자의 판단을 돕는 주석이 있으면 좋다.

## Class 9 - 23/2/16
>linux 명령어 모음

| name | Description |
| ----------- | ----------- |
|grep [string] [FILES] | 여러 file중에서 해당 string이 존재하는 file명을 출력하는 명령어|
| make | Makefile의 첫번째 target의 compile을 실행시키는 명령어 |
|make [target] | Makefile의 특정 target을 지정하여 compile을 실행시키는 명령어|
| cmake [CMakeLists.txt] | Makefile을 생성하는 명령어|

> vi 명령어 모음

| name | Description |
| ----------- | ----------- |
| yw | 한 단어 복사 |
|d% | 괄호위에서 누를 경우 괄호에서 부터 짝이 되는 괄호까지 삭제|
|/[찾고싶은 내용] | 특정 단어를 찾는다 - 여기서 n을 누르면 다음 항목으로 넘어간다|
> 강의 내용

## Makefile
--- 
- Makefile 이란 : 여러 file을 compile하여 실행파일을 생성할 때, 최초에는 모든 file을 compile하여 .o 파일을 생성한 후 실행파일을 생성해야 하지만 한번 .o 파일이 생성된 이후 .c파일의 수정 사항이 없다면 다시 .o파일을 생성할 필요가 없다. 그런데 만약 file수가 많고 또 그중 여러 file을 수정했다면 compile 시간을 줄이기 위해선 어떤 file을 수정하였는지 일일이 확인해야 한다. 또한 .h파일이 수정되었다면 그 파일을 include하고 있는 .c파일을 모두 찾아내서 다시 compile을 해줘야 하는 번거로움이 발생한다. 이와같은 불편함을 해소하기위해 개발된 것이 makefile이다.

- Makefile의 이점 : makefile을 사용하면 file간의 dependency를 파악하여 어떤 실행파일을 만들기 위해 필요한 .o file이 무엇인지 파악하고 해당 .o file이 없거나 .c file혹은 .h file이 수정되었다면 .c file을 compile하는 등의 작업을 수행하여 사용자가 일일이 file간의 dependency를 확인해야하는 수고를 덜어준다.

- Makefile 실행관련
    - Makefile 작성 후 make 입력시 Makefile에 적혀있는 target중 가장 위에 적혀있는 target에 대한 compile을 수행한다. 그래서 가장 위에는 1순위 compile대상을 적어 둔다.
    - make 입력후 가장 상위의 compile 대상에 대한 dependency list file이 없거나 재 compile이 필요한 경우 하위 target의 compile이 수행된다.
    - dependency를 고려하였을 때 수정사항이 없다면 up to date라는 문구가 출력된다.
    - source code를 touch하면 timestamp를 바꾸게 되므로 source code를 수정한것과 같은 기능을 한다 - 그래서 모든 file을 다시 compile하고 싶다면 모든 source code를 touch한 후 make를 입력하면 된다.

- Makefile 작성관련
    - 맨 처음 Makefile을 생성한 후 다음과 같이 작성한다.
    ```
    생성 file : 생성하려는 file에 dependency가 있는 file list
        compile 명령어(예시: cc -o main main.o tobin.o func.o)

    - 항상 target아래 부분에서 tab을 쓰고 명령어를 입력해야 한다
    - depedency가 있는 file list를 생성 file 옆에 적지 않으면 source code를 수정한 이후에도 해당 code를 compile하지 않게 되므로 dependency가 있는 file list는 꼭 적어야 한다 
    ```
    -  실행파일 생성 이후 필요없는 file을 지울 때는 아래와 같이 작성한다
    ```
    clean :
        \rm [지우려는 file list]

     - 이후 terminal에서 make clean입력시 필요없는 file들이 지워진다.
    ```
    -  변수에 string을 저장할 수 있고, $()로 그 값을 사용 가능하다.
    ```
    OBJ = main.o func.o tobin.o
    main : $(OBJ)
            cc -o main main.o func.o tobin.o

    - 위 code에서는 dependency에 들어갈 file을을 변수에 저장하여 사용하고 있다.
    ```
    - 특정 파일들과 dependency가 있는 모든 파일의 경로를 확인하고 싶을때 gccmakedep 명령어를 사용하여 아래와 같이 makefile을 작성하면 된다.
    ```
    dep :
            gccmakedep [file list]
    
    - 이후 terminal에서 make dep입력시 기존의 Makefile내용은 Makefile.bak에 저장되고 Makefile에는 file list의 dependency와 관련된 다른 파일들의 경로가 추가된다.
    ```
- Automatic variable

    ![alt text](./automatic%20variables_basic.png)

    ![alt text](./automatic%20variables_file%26dir.png)

    - automatic variable 예시
    ```
    main : main.o func.o tobin.o
        cc -o main main.o func.o tobin.o
    ```

    - $@ : target이름을 대신할 수 있다 (main)

    ```
    main : main.o func.o tobin.o
        cc -o $@ main.o func.o tobin.o
    ```
     - $^ : dependency file list전부를 대신할 수 있다 (main.o func.o tobin.o)

    ```
    main : main.o func.o tobin.o
        cc -o main $^
    ```

     - $< : dependency file list중 첫번째 항목을 대신할 수 있다 (main.o)
    ```
    main : main.o func.o tobin.o
        cc -o main $< func.o tobin.o
    ```
    - $? dependency file list중 timestamp가 바뀐 file만을 선택할 수 있다.
    - 이외에 sufix rule도 존재한다

- Makefile 예시
    ```
    main : main.o func.o tobin.o
            cc -o main main.o func.o tobin.o
    main.o : main.c func.h
            cc -c main.c
    func.o : func.c func.h
            cc -c func.c
    tobin.o : tobin.c
            cc -c tobin.c

    clean:
            \rm *.o main

    dep :
            gccmakedep main.c func.c tobin.c
    ```

## Cmake
---
- Cmake 기능 : 만들려는 실행 프로그램이름과 관련 file을 작성하기만 하면 Makefile을 생성한다.

- Cmake 활용방법
    1. CMakeLists.txt를 생성한다.
    2. txt file에 다음과 같이 작성한다
    ```
    project(실행파일)
    ADD_EXECUTABLE(dependency file list)
    ```
    3. cmake [CMakeLists.txt]를 입력하면 Makefile이 생성된다.
    4. 만약 dependency file이 늘어나면 CMakeLists.txt의 ADD_EXECUTABLE 항목에 추가하면 된다.

- 다만 만들어진 Makefile은 알아보기 힘든 형태로 생성된다.
## Thread
---
- thread 정의 : 한 작업을 여러개의 작은 단위로 나눠서 병렬처리할 때 작업을 수행하는 가상의 component

- thread의 배경 : 과거에는 process 단위로 작업을 수행하였으며 여러 작업을 수행할 때 fork를 통해 process를 더 생성하여 작업을 수행하였다. 하지만 fork명령어는 기존 process의 memory 공간을 하나 더 복사하기 때문에 overhead를 발생시킨다. 게다가 process간 context switching시에도 overhead가 발생하여 context switch가 일어날 때마다 프로그램의 성능은 크게 떨어졌다. thread는 위와 같은 overhead를 줄이기 위해 고안된 것이다. thread 생성시, 기존 thread의 memory공간의 일부는 복사하고 일부는 공유하는 형태로, proces와 달리 memory 공간을 통째로 복사할 필요가 없기 때문에 context swtiching속도 또한 process 보다 빠르다.

### 이외에 배운 내용
---
- project 관련 내용
    1. 단위 기능 테스트 : 내가 생성한 함수가 원하는 방식으로 작동을 하는가를 테스트
    2. 테스트 데이터는 일관성이 있어서는 안된다
    3. float 계산시에는 계산 순서가 중요하다. 256을 먼저 곱하고 두 수의나눗셈을 해주어야 data loss가 일어나지 않는다 - 곱셈을 먼저 해주는 것이 좋다
    4. 각 함수당 견해를 적어야 한다 - 어느 범위에서 사용가능한지, 속도는 빠른지, 등등
    5. 개인 프로젝트용 Makefile과 팀 프로젝트용 Makefile을 만들어야 한다.

## Class 10 - 23/2/17
>linux 명령어 모음

| name | Description |
| ----------- | ----------- |
| cc [FILE.c] -lpthread| compile시 pthread관련 library를 link하는 명령어 |

> 강의 내용

## Thread
--- 
- Thread의 이점 : context switching overhead가 적다.
- Thread 사용 방법
    - linux, unix계열 os에서 c언어로 thread 사용시, pthread.h를 include 해야한다. (POSIX)
    - code내에서 thread 변수인 pthread_t [variable]; 을 선언한 후, pthread관련 함수에서 해당 변수를 사용한다.
    - 코드 작성 이후 compile 옵션으로 -lpthread를 추가한다.
    ```
    cc [FILE.c] -lpthread
    ```
- Thread 관련 함수
    1. pthread_create : 새로운 thread는 start_routine으로받은 함수의 주소와 arg로 받은 파라미터의 주소로 함수를 실행시키는 과정에 생성된다. 이때 thread에는 이전에 생성한 pthread_t [variable]이다. <U>주의해야할 점은 함수와 파라미터의 타입은 반드시 void*여야 한다.</U>
    ```
    pthread_create(pthread_t  *  thread, pthread_attr_t \*attr, void * (*start_routine)(void *), void * arg);
    ```
    2. pthread_join : 특정 thread th가 종료될 때까지 기다리는 함수이다. thread th가 종료된 후 반환한 return값은 thread_return에 저장된다.
    ```
    pthread_join(pthread_t th, void **thread_return);
    ```
    3. pthread_cancel : 특정 thread를 종료시킬 때 사용하는 함수이다.
    ```
    pthread_cancel(pthread_t thread);
    ```
    4. pthread_self : 현재 thread의 식별자값을 반환한다.
    ```
    pthread_t pthread_self(void);
    ```
- Thread의 병렬처리방식 : thread는 작업을 병렬처리 하는데 특화되어있다. 그런데 만약 여러 thread중 하나의 thread에만 작업이 몰려있다면, 전체 작업을 sequential하게 처리하는 것과 병렬 처리하는 것의 속도가 별반 다르지 않을 것이다. 즉 thread를 이용한 작업처리 방식은 항상 작업 처리 속도가 가장 느린 thread에 bound되기 때문에 각각의 thread가 비슷한 양의 작업량을 분배받는 것이 중요하다.
## Mutex
---
- mutex 사용 배경 : thread는 process와 달리 memory의 일정 부분을 다른 thread와 공유한다. 때문에 여러 thread에서 동시에 전역변수 혹은 static변수의 값을 읽고 쓸 때는 overwrite 발생을 고려해야 한다. overwirte 발생을 막기위해선 static변수와 전역변수를 사용하지 않는것이 가장 확실하지만, 상황에 따라 해당 변수들을 사용해야만 할 수도 있다. 이때 overwrite문제를 막기 위해 고안된 것이 mutex이다. 

- mutex 정의 : 특정 code공간을 하나의 thread만 접근할 수 있도록 일종의 lock을 걸어두는 것이다.

- mutex 사용 예제
    ```
    static pthread_mutex_t [변수이름] = PTHREAD_MUTEX_INITIALIZER;

    pthread_mutex_lock(&[변수이름])
    ... //전역변수 혹은 static변수를 write하는 부분 
    pthread_mutex_unlock(&[변수이름])

    - 위와 같이 code를 작성하면 ... 부분에는 오직 하나의 thread만 접근할 수 있게 된다.
    ```

- mutex의 단점 : mutex로 특정 구간에 lock을 걸어두면 해당 영역에 다른 thread가 몰리더라도 반드시 하나의 thread만 접근할 수 있기 때문에, 다른 thread는 대기해야한다. 이는 곧 성능 저하로 이어진다. 사용하는 static 변수 혹은 전역변수가 많다면 각각 mutex lock해주는 것이 좋지만 어찌됬든 mutex lock은 성능 저하를 유발 시키기 때문에 결과적으로 thread를 이용하여 성능을 높이려 했던 목적에 부합하지 않게된다. - 최대한 지역변수를 사용하는 것이 좋다.



### 이외에 배운 내용
---
 - pthread에 관련된 자료형 및 함수를 사용하기 위해 -lpthread를 link해야 하는데 이때 link 순서가 중요하다.

- coverage : code에서 발생할수 있는 모든 경우의수를 고려했을때 얼마만큼을 테스트 했는가에 대한 척도 - 모든 경우(if, else, while 등등)를 테스트 완료한 경우 coverage 100% 이다.

- Glib : 수많은 자료구조에 대한 API가 있는 프로그램 - ppt 183p 참고

- POSIX : 서로 다른 UNIX OS의 공통 API를 정리하여 이식성이 높은 유닉스 응용 프로그램을 개발하기 위한 목적으로 IEEE가 책정한 애플리케이션 인터페이스 규격이다.

- performance 척도 : 프로그램 성능을 재는 척도에는 Throughput과 Latency가 있다. Throughput은 초당 처리하는 작업의 개수를 말하며 Latency는 하나의 작업을 처리하는데 걸리는 시간을 말한다.


- code내에서 fork 함수로 process를 생성한 후 system함수 혹은 exec함수를 통해 해당 process에게 프로그램실행을 시킬 수 있다.
    ```
    #include <stdlib.h>

    int main(){
            system("ls");
            return 0;
    }

    -위code를 실행시키면 ls명령어가 실행된 결과가 stdout에 출력된다
    ```
--- 
- 질문할 것
1. 왜 library link시 순서에 맞게 해야하는가?

