namespace EventsSandbox
{
    using System;
    using Models;

    public class JobDoneEventArgs : EventArgs
    {
        private Job job;

        public JobDoneEventArgs(Job job)
        {
            this.Job = job;
        }
        public Job Job
        {
            get
            {
                return job;
            }

            set
            {
                job = value;
            }
        }
    }
}
