using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveTextEngine
{
    public class SentenceObject
    {
        private string _sentence { get; set; }
        private int _minimumLength { get; set; }
        private int _maximumLength { get; set; }
        private Random _r;
        private List<WordObject> _wordList;
        private bool _interrogative { get; set; }
        public bool Interrogative
        {
            get
            {
                IsInterrogative();
                return _interrogative;
            }
        }

        public string Sentence
        {
            get
            {
                return _sentence;
            }
        }

        public SentenceObject()
        {
            _sentence = string.Empty;
            _wordList = new List<WordObject>();
            _r = new Random();
            _minimumLength = _r.Next(1, 4);
            _maximumLength = _r.Next(_minimumLength, 25);
        }

        public void AddWord(WordObject word)
        {
            _wordList.Add(word);
        }

        private void DetermineEnd()
        {
            if (_wordList.Count > _maximumLength)
            {
                BuildSentence();
            }
        }

        private void BuildSentence()
        {
            // TODO: Add function for determining punctuation.
            // TODO: Transform first character
            for (int i = 0; i < _wordList.Count(); i++)
            {
                _sentence += (_wordList[i].Word + " ");
            }

            _sentence += EndingPunctuation();
        }

        public string ReturnSentence()
        {
            // TODO: Add function for determining punctuation.
            // TODO: Transform first character
            if (_wordList.Count >= _minimumLength)
            {
                for (int i = 0; i < _wordList.Count() - 1; i++)
                {
                    _sentence += (_wordList[i].Word + " ");
                }

                _sentence += _wordList[_wordList.Count - 1].Word;
                _sentence += EndingPunctuation();
            }

            else
            {
                throw new Exception("Word length did not meet minimum sentence length of " + _minimumLength.ToString());
            }

            return _sentence;
        }

        private void IsInterrogative()
        {
            // TODO: Improve algorithm
            if (_wordList[0].Word.ToLower() == "what" || _wordList[0].Word.ToLower() == "where" || _wordList[0].Word.ToLower() == "when" ||
                _wordList[0].Word.ToLower() == "why" || _wordList[0].Word.ToLower() == "is" || _wordList[0].Word.ToLower() == "do" ||
                _wordList[0].Word.ToLower() == "how" || _wordList[0].Word.ToLower() == "isn't" || _wordList[0].Word.ToLower() == "isnt")
            {
                _interrogative = true;
            }

            else
            {
                _interrogative = false;
            }
        }

        private string EndingPunctuation()
        {
            // TODO: Build support for exclamations
            if (Interrogative)
            {
                return "?";
            }

            else
            {
                return ".";
            }
        }
    }
}
