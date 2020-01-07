using System;

namespace AlgoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int uniqueElems = Algo.ReplaceDuplicatesInPlace.Execute(new int [] {1, 1, 2});
            System.Console.WriteLine($"Result is: {uniqueElems}");
        }
    }
}
