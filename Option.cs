using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema6
{
    internal class Option
    {
        public String Value { get; set; } = "";

        public bool IsCorrect { get; set; } = false;

        public Option(String value, bool isCorrect) {
            Value = value;
            IsCorrect = isCorrect;
        }
    }
}
