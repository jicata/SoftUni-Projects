using System;
using System.Data;
using _04WorkForce.Interfaces;

namespace _04WorkForce.Models
{
    public delegate void JobDoneEventHandler(object sender, JobDoneEventArgs args);

    public class Job
    {
        public event JobDoneEventHandler JobDone;

        public Job(string name, int hoursRequired, IEmployee employee)
        {
            this.Name = name;
            this.WorkHoursRequired = hoursRequired;
            this.Employee = employee;
        }

        public string Name { get; private set; }
        public int WorkHoursRequired { get; private set; }
        public IEmployee Employee { get; private set; }

        public void Update()
        {
            this.WorkHoursRequired = this.WorkHoursRequired - this.Employee.WeeklyWorkHours;
            if (this.WorkHoursRequired <= 0)
            {
                Console.WriteLine("Job {0} done!", this.Name);
                OnJobDone(new JobDoneEventArgs(this));
            }
        }

        protected void OnJobDone(JobDoneEventArgs args)
        {
            if (JobDone != null)
            {
                JobDone(this, args);
            }
        }

        public override string ToString()
        {
            return string.Format("Job: {0} Hours Remaining: {1}", this.Name, this.WorkHoursRequired);
        }
    }
}
