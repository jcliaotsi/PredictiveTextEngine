using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PredictiveTextEngine
{
    public class ReaderSentences
    {
        private List<string> _allSentences { get; set; }

        public List<string> AllSentences
        {
            get
            {
                return _allSentences;
            }
        }

        public ReaderSentences(string fullText)
        {
            SplitSentences(fullText);
            char[] trimCharacter = { ' ' };
            
            for (int i = 0; i < _allSentences.Count; i++)
            {
                _allSentences[i] = _allSentences[i].TrimStart(trimCharacter);
            }
        }

        private void SplitSentences(string fullText)
        {
            // TODO: Make sensitive to multiple punctuation marks, like elipses
            _allSentences = new List<string>(Regex.Split(fullText, @"(?<=[.!?])"));
        }
    }
}
