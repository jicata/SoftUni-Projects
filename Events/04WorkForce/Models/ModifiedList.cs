using System;
using System.Collections.Generic;

namespace _04WorkForce.Models
{
    public class ModifiedList : List<Job>
    {
        public void HandleJobDone(object sender, JobDoneEventArgs args)
        {
            this.Remove(args.DoneJob);
        }
    }
}
