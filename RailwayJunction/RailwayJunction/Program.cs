using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RailwayJunction
{
    class Program
    {
        static void Main()
        {
            var queueManeuvers = new Queue<string>();
            var queue = new Queue<string>();
            var stack = new Stack<string>();
            var countTrain = 0;
            var countManeuvers = 0;

            Console.WriteLine("Обработка");
           
            try
            {
                using(StreamReader sr = new StreamReader("carriages.txt"))
                {
                    string line;
                    
                    while((line = sr.ReadLine()) != null)
                        queue.Enqueue(line);
                }
            }
            catch { }

            countTrain = queue.Count;
            string train;

            while(queue.Count != 0)
            {
                train = queue.Dequeue();
                if(train[0] != 'A')
                {
                    stack.Push(train);
                    queueManeuvers.Enqueue($"Вагон {train} перегнать на запасной путь C");
                }
                else
                {
                    queueManeuvers.Enqueue($"Вагон {train} перегнать на погрузку на путь A");
                }
            }

           
            while (stack.Count != 0)
            {
                train = stack.Pop();
                queueManeuvers.Enqueue($"Вагон {train} перегнать на погрузку на путь B");
            }

            countManeuvers = queueManeuvers.Count;

            
            try
            {
                using(StreamWriter sr = new StreamWriter("orders.txt", false, Encoding.Default))
                {
                    while(queueManeuvers.Count !=0)
                        sr.WriteLine(queueManeuvers.Dequeue());
                }
            }
            catch { }

            Console.WriteLine($"количество поездов - {countTrain}");
            Console.WriteLine($"количество маневров - {countManeuvers}");

            Console.ReadLine();
        }
    }
}
