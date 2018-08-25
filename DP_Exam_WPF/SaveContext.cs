using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Exam_WPF
{
    public class SaveContext
    {
        private ISaveStrategy SaveStrategy;

        public SaveContext(ISaveStrategy strategy)
        {
            SaveStrategy = strategy;
        }

        public void Save()
        {
            SaveStrategy.Save();
        }
    }
}
