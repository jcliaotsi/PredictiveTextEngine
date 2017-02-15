using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveTextEngine
{
    public class WordObject
    {
        private string _word { get; set; }
        // Suggestion: Break this and its related functions off into another class
        private List<RankedWord> _likely { get; set; }
        private int _total { get; set; }

        public WordObject(string word)
        {
            _word = word;
            _likely = new List<RankedWord>();
        }

        public string Word
        {
            get
            {
                return _word;
            }
        }

        public List<RankedWord> Likely
        {
            get
            {
                return _likely;
            }
        }

        public int Total
        {
            get
            {
                return _total;
            }
        }

        public void AddLikelyWord(string word)
        {
            bool found = false;

            foreach(RankedWord w in _likely)
            {
                if (w.Word == word)
                {
                    w.Rank++;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                _likely.Add(new RankedWord(word, 1));
            }

            SortRanks();
        }

        public void ChangeRank(string word, int rank)
        {
            _likely.First(d => d.Word == word).Rank = rank;
        }

        private void SortRanks()
        {
            List<RankedWord> SortedList = _likely.OrderByDescending(o => o.Rank).ToList();
            _likely = SortedList;
            TrimList();
        }

        private void TrimList()
        {
            int max = 100;

            while (_likely.Count() > max)
            {
                _likely.RemoveAt(_likely.Count - 1);
            }

            UpdateRanks();
        }

        private void UpdateRanks()
        {
            int runningTotal = 0;

            foreach (RankedWord w in _likely)
            {
                runningTotal += w.Rank;
            }

            _total = runningTotal;

            foreach (RankedWord w in _likely)
            {
                w.Probability = Convert.ToDecimal(w.Rank) / _total;
            }
        }
    }
}
