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

        public String ID {get; set;} = "";

        public String Text {get; set;} = "";

        public String ImagePath {get; set;} = "";

        public Question(int points, string id, string text, string ImagePath)
        {
            Points = points;
            ID = id;
            Text = text;
            this.ImagePath = ImagePath;
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
