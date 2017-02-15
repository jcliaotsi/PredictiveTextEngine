using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PredictiveTextEngine
{
    public class Analyzer
    {
        private string _fullText { get; set; }
        private List<string> _sentences { get; set; }
        private List<WordObject> _filteredWords { get; set; }
        private List<string> _rawWords { get; set; }
        private bool _ready { get; set; }

        public bool Ready
        {
            get
            {
                return _ready;
            }
        }

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

        /// <summary>
        ///     Flow:
        ///         1. Instantiate with fulltext
        ///         2. Split sentences
        ///         3. Split words
        ///         4. Build unique wordlist
        ///         5. Itterate through unique wordlist and build up likely word occurrences
        /// </summary>

        public Analyzer(string inputText)
        {
            _ready = false;
            _fullText = inputText;
            _sentences = new List<string>();
            _filteredWords = new List<WordObject>();
            _rawWords = new List<string>();

            if (_fullText != string.Empty)
            {
                SplitSentences();
                SplitWords();
                FilterWords();
                RankWords();
                _ready = true;
            }
        }

        private void SplitSentences()
        {
            // TODO: Make sensitive to multiple punctuation marks, like elipses
            _sentences = new List<string>(Regex.Split(_fullText, @"(?<=[.!?])"));

            char[] trimCharacter = { ' ', '.', ',', '!', '?' };

            for (int i = 0; i < _sentences.Count; i++)
            {
                _sentences[i] = _sentences[i].TrimStart(trimCharacter);
                _sentences[i] = _sentences[i].TrimEnd(trimCharacter);
                _sentences[i] = _sentences[i].ToLower();
            }
        }

        private void SplitWords()
        {
            _rawWords = new List<string>(Regex.Split(_fullText, @"(?<=[.!?, ])"));

            char[] trimCharacter = { ' ', '.', ',', '!', '?' };

            for (int i = 0; i < _rawWords.Count; i++)
            {
                _rawWords[i] = _rawWords[i].TrimStart(trimCharacter);
                _rawWords[i] = _rawWords[i].TrimEnd(trimCharacter);
                _rawWords[i] = _rawWords[i].ToLower();
            }

            _rawWords.RemoveAll(RemoveBlanks);
        }

        private static bool RemoveBlanks(String s)
        {
            if (s.Equals(" ") || s.Equals(string.Empty))
            {
                return true;
            }
                
            return false;
        }

        private void FilterWords()
        {
            IEnumerable<string> enumerableWords = _rawWords.Select(x => x).AsParallel().Distinct();
            foreach (string s in enumerableWords)
            {
                _filteredWords.Add(new WordObject(s));
            }
        }

        private void RankWords()
        {
            for (int i = 0; i < _filteredWords.Count(); i++)
            {
                for (int n = 0; n < _rawWords.Count() - 1; n++)
                {
                    if (_filteredWords[i].Word == _rawWords[n])
                    {
                        _filteredWords[i].AddLikelyWord(_rawWords[n + 1]);
                    }
                }
            }
        }
    }
}
