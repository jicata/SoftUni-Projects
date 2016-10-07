using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04WorkForce.Models
{
    public class JobDoneEventArgs : EventArgs
    {
        public JobDoneEventArgs(Job job)
        {
            this.DoneJob = job;
        }

        public Job DoneJob { get; private set; }
    }
}
