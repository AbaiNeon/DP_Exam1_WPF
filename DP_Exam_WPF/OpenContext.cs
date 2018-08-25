using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Exam_WPF
{
    public class OpenContext
    {
        public IOpenStrategy OpenStrategy { private get; set; }

        public OpenContext(IOpenStrategy strategy)
        {
            OpenStrategy = strategy;
        }

        public void Open()
        {
            OpenStrategy.Open();
        }
    }
}
