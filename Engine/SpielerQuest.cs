using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SpielerQuest
    {
        public Quest Details { get; set; }
        public bool IsCompleted { get; set; }

        public SpielerQuest(Quest details)
        {
            Details = details;
            IsCompleted = false;
        }
    }
}
