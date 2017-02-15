using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveTextEngine
{
    public class RankedWord
    {
        private string _word { get; set; }
        private int _rank { get; set; }
        private decimal _probability { get; set; }

        public string Word
        {
            get
            {
                return _word;
            }
        }

        public int Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                _rank = value;
            }
        }

        public decimal Probability
        {
            get
            {
                return _probability;
            }
            set
            {
                _probability = value;
            }
        }

        public RankedWord(string word, int rank)
        {
            _word = word;
            _rank = rank;
        }
    }
}
