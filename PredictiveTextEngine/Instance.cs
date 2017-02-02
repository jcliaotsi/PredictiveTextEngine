using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveTextEngine
{
    public class Instance
    {
        private Reader _reader { get; set; }
        private string _allText { get; set; }
        private List<string> _sentences { get; set; }
        public List<string> Sentences
        {
            get
            {
                return _sentences;
            }
        }

        public Instance()
        {
            _reader = new Reader();
        }

        public void Read(string file)
        {
            _allText = _reader.Read(file);
            SplitSentences();
        }

        public void SplitSentences()
        {
            // TODO: Make this reusable
            ReaderSentences rs = new ReaderSentences(_allText);
            _sentences = rs.AllSentences;
        }
    }
}
