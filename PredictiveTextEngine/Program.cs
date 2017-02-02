using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveTextEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\thomas.hanby\Desktop\Misc\Documents\LoremIpsum.txt";

            Instance i = new Instance();
            i.Read(path);
            Console.WriteLine("Ready");
            Console.ReadLine();

            List<string> sentences = i.Sentences;
            foreach (string s in sentences)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
