using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema6
{
    internal class Theme
    {
        public String Name { get; set; } = "";

        public Level CurrentLevel { get; set; }

        public List<Level> Levels { get; set; } = new List<Level>();

        public Theme(string name) { 
            Name = name;
        }

        public void AddLevel(Level level)
        {
            Levels.Add(level);
            if (Levels.Count == 1)
            {
                CurrentLevel = level;
            }
        }

        public void NextLevel()
        {
            for (int i = 0; i < Levels.Count; i++)
            {
                if (Levels[i] == CurrentLevel)
                {
                    if (i < Levels.Count - 1)
                    {
                        CurrentLevel = Levels[i + 1];
                        return;
                    }
                }
            }
        }
    }
}
