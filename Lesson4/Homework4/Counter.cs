using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    public class Counter
    {
        public delegate void Notifier();
        public event Notifier onCount;

        public void CycleCounter()
        {
            for (int i = 0; i < 100; i++) 
            {
               if (i == 77)
                {
                    onCount();
                }
            }
        }
    }
}