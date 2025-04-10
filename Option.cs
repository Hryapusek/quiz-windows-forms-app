using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema6
{
    internal class Option
    {
        public String Value {
            get {
                return m_value; 
            }
        }

        public bool IsCorrect { 
            get {
                return m_isCorrect;
            }
        }

        public Option(String value, bool IsCorrect) {
            m_value = value;
            m_isCorrect = IsCorrect;
        }

        private String m_value;
        private bool m_isCorrect;
    }
}
