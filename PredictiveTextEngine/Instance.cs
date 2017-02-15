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
        private List<string> _rawWords { get; set; }
        private Analyzer _analyzer { get; set; }
        private List<WordObject> _filteredWords { get; set; }
        public List<string> Sentences
        {
            get
            {
                return _sentences;
            }
        }
        public List<string> RawWords
        {
            get
            {
                return _rawWords;
            }
        }

        public List<WordObject> FilteredWords
        {
            get
            {
                return _filteredWords;
            }
        }

        public Instance()
        {
            _reader = new Reader();
            _sentences = new List<string>();
            _rawWords = new List<string>();
            _filteredWords = new List<WordObject>();
        }

        public void Read(string file)
        {
            _allText = _reader.Read(file);
        }

        public void Analyze()
        {
            _analyzer = new Analyzer(_allText);
            _sentences = _analyzer.Sentences;
            _rawWords = _analyzer.RawWords;
            _filteredWords = _analyzer.FilteredWords;
        }
    }
}
