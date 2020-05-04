using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void OutputResult(Dictionary<int, double> data)
        {
            foreach (var element in data)
                Console.WriteLine(element.Key + "  " + element.Value);
        }

        static void GetResult(Dictionary<int, int> data)
        {
            var sum = 0;
            foreach (var element in data)
                sum += element.Value;
            var result = new Dictionary<int, double>();
            foreach (var element in data)
                result.Add(element.Key, element.Value * 1.0 / sum);
            OutputResult(result);
        }

        static void GetMathDictionary(List<int> list)
        {
            list.Sort();
            var result = new Dictionary<int, int>();
            foreach(var element in list)
            {
                if (!result.ContainsKey(element))
                    result.Add(element, 1);
                else
                    result[element]++;
            }
            GetResult(result);
        }

        static void MathStatistics(string line)
        {
            List<int> data = new List<int>();
            foreach (var element in line.Split(' '))
                data.Add(int.Parse(element));
            GetMathDictionary(data);
        }

        static void Main()
        {
            var path = @"sample.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    MathStatistics(line);
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
    }
}
