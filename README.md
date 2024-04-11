# C# 기본 학습
2024년 IoT 개발자 과정 C# 리포지토리

## 1일차(2024-04-11)
- C# 소개
    - MS에서 개발한 차세대 프로그래밍 언어
    - 2000년 최초 발표, 앤더스 하일버그(파스칼, 델파이 개발자)
    - 1995년 Java 발표되면서 경쟁하기 위해서 개발
    - 객체지향 언어, C/C++ 과 Java를 참조해서 개발
    - OS플랫폼 독립적, 메모리관리 쉬움
    - 다양한 분야에서 사용 중
    - 2024년 12버전

- .NET Framework(닷넷 프레임워크) (CLR) 
    - Windows OS에 종속적
    - OS 독립적인 새로운 틀을 제작하기 시작(2022년 ~) -> .NET 5.0
    - 2024년 현재 .NET 8.0
    - C / C++은 gcc 컴파일러, Java는  JDK, C#은 .NET 5.0 이상이 필요 
    - 이제는 신규 개발시, .NET Framework는 사용하지 말 것!

- Hello, C#!
    - Visual Studio 시작
    - 프로젝트 : 프로그램 개발 최소단위 그룹
    - 솔루션 : 프로젝트의 묶음
    - Ctrl + K + C 누르면 주석 처리

    ```cs
    namespace hello_word // 소스의 가장 큰 단위 namespace == project
    {
        internal class Program // 접근제한자 class 파일명
        {
            static void Main(string[] args)  // 정적 void Main    // C#은 모든 메소드를 쓸 때 대문자로 시작
            {
                // System 네임스페이스 > Console 클래스에 있는 정적메서드 WriteLine()
                Console.WriteLine("Hello, World!");
            }
        }
    }
    ```

- 변수와 상수
    - C++과 동일
    - 모든 C#의 객체는 Object를 조상으로 한다
    - 프로그램 메모리에는 스택(값형식, 정수, 실수 ...), 힙(참조형식, 클래스, 문자열, 리스트, 배열 ...)
    - 박싱, 언박싱
    ```cs
    int a 20;
    object b = a; // 박싱(object 박스에 담는다) -> 힙에 올리는 것

    int c = (int) b; // 언박싱(object를 각 타입으로 변환)
    ```

    -- 상수는 const 키워드 사용
    -- var는 컴파일러가 자동으로 타입을 지정해주는 변수. 지역 변수에만 사용 가능

- 연산자
    - C++과 동일!
    - ++, --가 파이썬에 없다는 것
    - and, or가 C++, C#에서는 &&, ||라는 것

- 흐름제어
    - C++과 동일!
    - if, switch, while, do ~ while, for, break, continue 모두 동일!
    - C#에는 foreach가 존재 -> python의 for item in []과 동일 (foreach를 잘 쓰면 C#이 편하다)



## 2일차(2024-04-12)