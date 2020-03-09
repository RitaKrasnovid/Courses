// Дана строка длины N.Найти длину максимальной подстроки в которой каждый последующий символ больше предыдущего в лексикографическом порядке.
// Результат:
//  1. Реализованный алгоритм (ссылка на репозиторий, другое)
//2. Провести асимптотический анализ реализованного алгоритма

using System;

namespace Algorithms
{
    class Task_1
    {
        static void Main(string[] args)
        {
            int letterCounter = MaxLecsicSubstring("abaabcd");     
            Console.WriteLine("Max length - " + letterCounter);
            Console.ReadLine();
        }

        static int MaxLecsicSubstring(string inputString)          // итого асимптотическая сложность алгоритма составляет O(n)
        {
            if(string.IsNullOrEmpty(inputString))                  // O(1)
            {
                return 0;
            }

            int letterCounter = 1;                                 // O(1)
            int result = 0;                                        // O(1)

            for (int i = 1; i < inputString.Length; i++)           // O(n)
            {
                if (inputString[i] > inputString[i - 1])           // O(1)
                {
                    letterCounter++;
                }
                else {                                              // O(1)
                    result = Math.Max(letterCounter, result);
                    letterCounter = 1;
                }
            }

            result = Math.Max(letterCounter, result);               // O(1)

            return result;
        }
    }
}
