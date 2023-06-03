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
            var res = new List<double>();
            var counter = 0;
            foreach (var line in inputLine)
            {    
                if (double.TryParse(line, out double result))
                {
                    res.Add(result);
                    counter++;
                }
                else
                {
                    switch (line)
                    {
                        case ("+"):
                            res[counter - 2] = res[counter - 2] + res[counter - 1];
                            break;
                        case ("-"):
                            res[counter - 2] = res[counter - 2] - res[counter - 1];
                            break;
                        case ("*"):
                            res[counter - 2] = res[counter - 2] * res[counter - 1];
                            break;
                        case ("/"):
                            res[counter - 2] = res[counter - 2] / res[counter - 1];
                            break;
                    }
                    res.RemoveAt(counter - 1);
                    counter--;
                }
            }
            return (int)res[0];
        }
    }
}