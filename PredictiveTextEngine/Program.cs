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
            //string path = @"C:\Users\thomas.hanby\Desktop\Misc\Documents\LoremIpsum.txt";
            string path = @"C:\Users\thomas.hanby\Desktop\Misc\Documents\TestDocument.txt";

            Instance i = new Instance();
            i.Read(path);
            i.Analyze();
            Console.WriteLine("Ready");
            Console.ReadLine();

            List<string> sentences = i.Sentences;
            foreach (string s in sentences)
            {
                Console.WriteLine(s);
            }

            //List<string> words = i.RawWords;
            //foreach (string s in words)
            //{
            //    Console.WriteLine(s);
            //}

            Console.WriteLine("-----------------");

            foreach(WordObject o in i.FilteredWords)
            {
                Console.WriteLine(o.Word);
                foreach (RankedWord r in o.Likely)
                {
                    Console.WriteLine("  " + r.Rank.ToString() + " - " + r.Probability.ToString() + " - " + r.Word);
                }
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
