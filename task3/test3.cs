using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    internal class test3
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine().Split(' ');
            Console.WriteLine(Calculate(inputLine));
        }
        static int Calculate(string[] inputLine)
        { 
            var operations = new Dictionary<string, Func<double, double, double>>();
            operations.Add("+", (y, x) => x + y);
            operations.Add("-", (y, x) => x - y);
            operations.Add("*", (y, x) => x * y);
            operations.Add("/", (y, x) => x / y);

            var res = new Stack<double>();
            foreach (var line in inputLine)
            {    
                if (double.TryParse(line, out double result))
                    res.Push(result);
                else if (operations.ContainsKey(line))
                    res.Push(operations[line](res.Pop(), res.Pop()));
                else
                    throw new ArgumentException();
            }
            return (int)res.Pop();
        }
    }
}
