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
        public List<Option> Options {get; set;} = new();

        public int Points {get; set;} = new();

        public String Text {get; set;} = "";

        public String ImagePath {get; set;} = "";

        public Question(int points, string text, string imagePath)
        {
            Points = points;
            Text = text;
            ImagePath = imagePath;
        }

        public Question(string text = "", string imagePath = "", int points = 5)
        {
            Points = points;
            Text = text;
            ImagePath = imagePath;
        }

        public void AddOption(Option option)
        {
            Options.Add(option);
        }

        public void SetOptions(List<Option> options)
        {
            Options = options;
        }
    }
}
