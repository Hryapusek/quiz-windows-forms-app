using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema6
{
    internal class Question
    {
        public List<Option> options {
            get {
                return m_options;
            }
        }

        public int points
        {
            get
            {
                return m_points;
            }
        }

        public String id
        {
            get
            {
                return m_id;
            }
        }

        public String Text
        { 
            get
            {
                return m_text;
            }
        }

        public String image_path
        {
            get
            {
                return m_image_path;
            }
        }

        public Question(int points, string id, string text, string image_path)
        {
            m_points = points;
            m_id = id;
            m_text = text;
            m_image_path = image_path;
        }

        public void AddOption(Option option)
        {
            m_options.Add(option);
        }

        public void SetOptions(List<Option> options)
        {
            m_options = options;
        }

        List<Option> m_options;
        int m_points;
        String m_id;
        String m_text;
        String m_image_path;
    }
}
