using System;
using System.IO;
using System.Collections.Generic;


namespace ConsoleApplication1
{
    class Program
    {
        static void OutputList(List<string[]> list)
        {
                foreach (string[] item in list)
                Console.WriteLine( "Слово " + item[0] + " встретилось  " +   item[1] + " раз");
                Console.WriteLine();
         }
     
        class CountComparer : IComparer<string[]>
        {
            public int Compare(string[] o1, string[] o2)
            {
                int a = Convert.ToInt32(o1[1]);
                int b = Convert.ToInt32(o2[1]);

                if (a < b)
                {
                    return 1;
                }
                else if (a > b)
                {
                    return -1;
                }

                return 0;
            }
        }
        static void Main()
        {

            string text = File.ReadAllText("C:/Users/svlozovskoy/source/repos/ConsoleApp3/ConsoleApp3/Program.cs"); // читаем файл в строку
            string[] allwords = text.Split(' ', ',', '"', '.', '<', '>', '(', ')', '[',']'); // делим в строке слова по разделителю split  и пишем их в массив allwords
            int count = 0; //метрика кол-ва вхождений слова в массив
            string[] words = {"while" , "break", "char", "as", "byte", "checked", "bool", "const", "catch",
                "base", "case", "class", "continue", "decimal", "default", "delegate",
                "do", "double", "else", "enum", "event","explicit" ,"extern", "false","finally", "fixed", "float", "for",
                "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal","is", "lock", "long", "namespace",
                "new", "null", "object", "operator","out", "override","params","private","protected", "public", "readonly", "ref",
                "return",   "sbyte", "sealed", "short","sizeof","stackalloc","static", "string","struct", "switch", "this", "throw",
                "true","try","typeof","uint","ulong","unchecked","unsafe", "ushort","using","virtual", "void","volatile","abstract" }; //ключевые слова из доки ms
            Array.Sort(words); //Сортируем массив words по алфавиту по возрастанию
            string count_string;
            Dictionary<string, string> final = new Dictionary<string, string>();
            List<string[]> result = new List<string[]>();
            int m = words.Length; //переменная метрики длинны массива ключевых слов. 
            string[,] result_table = new string[m, 2]; // переменная result_table, являющаяся двумерным массивом m*2. все элементы - string

            for (int i = 0; i < m-1; i++)
            {
                string word = words[i];//на каждой итерации получаем новое слово для анализа из массива words
                foreach (string s in allwords)
                {
                    if (s == word) count++;//проверяем совпадает ли текущее слово с словами из массива words

                }
                
                count_string = count.ToString();//приводим int к string
                result.Add(new string[] {word,count_string});
                count = 0;//сбрасываем метрику 
            }

            OutputList(result);
            CountComparer CountWord = new CountComparer();
            result.Sort(CountWord);
           
            Console.WriteLine();

         


            Console.ReadLine();
        }
       
    }
}
