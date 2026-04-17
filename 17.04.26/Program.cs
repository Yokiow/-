using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace ClasWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Sum, Count, Min/Max ---

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            //int result = numbers.Sum();
            int result = numbers.Max(x => x%2);

            string[] worlds = { "Hello", "my", "dear", "f" };
            result = worlds.Min(x => x.Length);
            int result2 = worlds.Count(x => x.Length % 2 == 0);

            Example[] examples = new Example[3];
            for (int i = 0; i < 3; i++)
            {
                examples[i] = new Example();
            }
            result = examples.Sum(x => x.Num);

            // --- Any/All ---
            bool f1 = worlds.Any(x => x.Length % 3 == 0);
            bool f2 = worlds.All(x => x.Length > 1);
            Console.WriteLine(f1);
            Console.WriteLine(f2);

            // --- Select, Where, GroupBy, Disctinct ---
            int[] worldsLenght = worlds.Select(x=> x.Length).ToArray();// из одного массива в другой
            string[] longWorlds = worlds.Where(x => x.Length > 2).ToArray();

            int[] worldResult = worlds.Select(x=>x.Length)
                                .Where(x => x>2)
                                .ToArray();

            string world = "hello123";
            bool f = world.Any(x =>char.IsDigit(x));
        }
        public struct Example
        {
            private int _num;
            public int Num => _num;
        }
    }
}
