using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    internal class test2
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine().Split(' ');
            SortAndPrint(inputLine);
        }
        static void SortAndPrint(string[] inputLine)
        {
            var wordsDict = new Dictionary<string, int>();
            var maxLenghWord = 0;
            var mostUsedWord = 0;
            foreach (var word in inputLine)
            {
                if (word.Length == 0) continue;
                var wordLength = word.Length;
                if (wordLength > maxLenghWord) maxLenghWord = wordLength;
                if (!wordsDict.ContainsKey(word))
                {
                    wordsDict[word] = 1;
                }
                else
                {
                    wordsDict[word]++;
                    if (wordsDict[word] > mostUsedWord) mostUsedWord = wordsDict[word];
                }
            }
            var sortedDict = from entry in wordsDict orderby entry.Value ascending select entry;
            Print(maxLenghWord, mostUsedWord, sortedDict);
        }
        static void Print(int maxLengtWord, int mostUsedWord, IOrderedEnumerable<KeyValuePair<string, int>> sortedDict)
        {
            foreach (var element in sortedDict)
            {
                var word = string.Concat(Enumerable.Repeat("_", maxLengtWord - element.Key.Length)) + element.Key;
                var comparison = (double)element.Value / (double)mostUsedWord;
                var dots = string.Concat(Enumerable.Repeat
                    (".", (int)Math.Round(comparison * 10, MidpointRounding.AwayFromZero)));
                Console.WriteLine(word + " " + dots);
            }
        }
    }
}
