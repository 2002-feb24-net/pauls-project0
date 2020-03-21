using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Reviews
    {
        private int? _score;
        public int? Score
        {
            get => _score;
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException($"Score ${value} must be between 0 and 10.",
                        nameof(value));
                }
                _score = value;
            }
        }
        public string Text { get; set; }
    }
}
