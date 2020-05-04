using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLongWords
{
    class Program
    {
        
        static string ProcessingWords(string word)
        {
            var result = new StringBuilder();
            
            for (int i = 0; i< word.Length; i++)
                if (char.IsLetter(word[i]))
                    result.Append(word[i]);
            return result.ToString();
        }

        static void Main()
        {
            Console.WriteLine("Введите имя файла:");
            var path = Console.ReadLine();
            Console.WriteLine("Введите минимальную длину слова:");
            var lengthWord = int.Parse(Console.ReadLine());
            string text = " ";
            
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Файл не найден");
                Console.WriteLine(e.Message);
            }

            var words = text.Split(' ');
            var list = new List<string>();
   
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = ProcessingWords(words[i]);
                if (words[i].Length >= lengthWord)
                    list.Add(words[i]);
            }
            var countWords = list.Count();

            try
            {  
                using (StreamWriter sr = new StreamWriter("result.txt", false))
                {
                    foreach (var element in list)
                        sr.WriteLine(element);
                }
            }
            catch { }

            Console.WriteLine("Всего значений:" + countWords);
        }
    }
}
