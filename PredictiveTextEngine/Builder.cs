using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveTextEngine
{
    public class Builder
    {
        private List<WordObject> _textPool { get; set; }
        private List<string> _sentences { get; set; }
        private List<SentenceObject> _sentenceObjects { get; set; }
        private string _fullText { get; set; }
        private Random _r { get; set; }
        private List<int> _sentenceLength { get; set; }
        private int _numberOfSentences { get; set; }
        private bool _ready { get; set; }

        public List<WordObject> TextPool
        {
            get
            {
                return _textPool;
            }
        }

        public List<string> Sentences
        {
            get
            {
                return _sentences;
            }
        }

        public List<SentenceObject> SentenceObjects
        {
            get
            {
                return _sentenceObjects;
            }
        }

        public string FullText
        {
            get
            {
                return _fullText;
            }
        }

        public bool Ready
        {
            get
            {
                return _ready;
            }
        }

        public Builder(List<WordObject> words)
        {
            _ready = false;
            _textPool = new List<WordObject>();
            _sentences = new List<string>();
            _sentenceObjects = new List<SentenceObject>();
            _sentenceLength = new List<int>();
            _r = new Random();

            _textPool = words;

            DetermineNumberOfSentences(_r);
            DetermineSentenceLength(_r);
            // foreach (sentence) PickFirstWords(_r);
            // foreach (sentence) GenerateSentence(_r);
            // _ready = true;
        }

        private void DetermineNumberOfSentences(Random r)
        {
            _numberOfSentences = r.Next(1, Convert.ToInt16(Math.Floor(Convert.ToDouble(_textPool.Count()) / 2)));
        }

        private void DetermineSentenceLength(Random r)
        {
            for (int i = 0; i < _numberOfSentences; i++)
            {
                _sentenceObjects.Add(new SentenceObject(r.Next(1, 4), r.Next(5, 25)));
            }
        }
    }
}
