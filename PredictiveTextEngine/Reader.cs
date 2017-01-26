using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PredictiveTextEngine
{
    public class Reader
    {
        public Reader()
        {

        }

        public string Read(string file)
        {
            string allText = string.Empty;

            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    allText = sr.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                // TODO: Implement messenger system
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return allText;
        }
    }
}
