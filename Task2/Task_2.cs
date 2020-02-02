// Дан текст.Вывести в алфавитном порядке все слова, содержащие наибольшее количество гласных букв.
// Результат:
// 1. Реализованный алгоритм (ссылка на репозиторий, другое)
// 2. Провести асимптотический анализ реализованного алгоритма

using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Task_2
    {
        public static readonly ISet<char> vowels = new HashSet<char> { 'а', 'y', 'е', 'и', 'ы', 'ё', 'о', 'э', 'ю', 'я' };

        static void Main(string[] args)
        {
            const string text = "Бык не дает молоко, а корова. даёт молоко апельсин яблоко";

            foreach (var item in SortByVowelLetters(text))
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static SortedSet<string> SortByVowelLetters(string text)        // итого асимптотическая сложность алгоритма составляет O(n)
        {
            int maxCount = 0;
            int counter = 0;
            
            string[] splittedText = text.Split(' ', ',', '.');

            Dictionary<int, SortedSet<string>> counterOnWords = new Dictionary<int, SortedSet<string>>();

            for (int i = 0; i < splittedText.Length; i++)               // O(n)
            {
                for (int j = 0; j < splittedText[i].Length; j++)        // O(n)
                {
                    if (IsVowel(splittedText[i][j]))                    // O(1)
                    {
                        counter++;
                    }
                }

                if (counter == 0)                                       // O(1)
                {
                    continue;
                }
                SortedSet<string> value;

                if (!counterOnWords.TryGetValue(counter, out value))    // O(1)
                {
                    SortedSet<string> words = new SortedSet<string>();
                    words.Add(splittedText[i]);
                    counterOnWords.Add(counter, words);
                }
                else
                {
                    value.Add(splittedText[i]);
                }

                maxCount = Math.Max(maxCount, counter);
                counter = 0;
            }

            SortedSet<string> result;

            if (counterOnWords.TryGetValue(maxCount, out result))         // O(1)
            {
                return result;
            }

            return new SortedSet<string>();
        }

        static bool IsVowel(char letter)
        {
            return vowels.Contains(letter);
        }
    }
}
