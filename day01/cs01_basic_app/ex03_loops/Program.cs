﻿// date : 2024-04-11
// file : ex03_loops

namespace ex03_loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            foreach (var item in arr)   // var는 int타입
            {
                Console.WriteLine($"현재 수 : {item}");
            }
        }
    }
}
