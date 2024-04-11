namespace hello_word // 소스의 가장 큰 단위 namespace == project
{
    internal class Program // 접근제한자 class 파일명
    {
        static void Main(string[] args)  // 정적 void Main    // C#은 모든 메소드를 쓸 때 대문자로 시작
        {
            // System 네임스페이스 > Console 클래스에 있는 정적메서드 WriteLine()
            // Console.WriteLine("Hello, World!");  
            if (args.Length == 0)
            {
                Console.WriteLine("사용법 : hello_world.exe <이름>");
                return;
            } else
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
        }
    }
}
