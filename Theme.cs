﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema6
{
    internal class Theme
    {
        public int ID
        {
            get
            {
                return m_id;
            }
        }

        public String Name
        { 
            get
            {
                return m_name;
            }
        }

        public Level CurrentLevel
        {
            get
            {
                return m_currentLevel;
            }
        }

        public Theme(int id, string name) { 
            m_id = id;
            m_name = name;
        }

        public void AddLevel(Level level)
        {
            m_levels.Add(level);
            if (m_levels.Count == 1)
            {
                m_currentLevel = level;
            }
        }

        public void NextLevel()
        {
            for (int i = 0; i < m_levels.Count; i++)
            {
                if (m_levels[i] == m_currentLevel)
                {
                    if (i < m_levels.Count - 1)
                    {
                        m_currentLevel = m_levels[i + 1];
                        return;
                    }
                }
            }
        }

        int m_id;
        String m_name;
        List<Level> m_levels = new List<Level>();
        Level m_currentLevel;
    }
}
