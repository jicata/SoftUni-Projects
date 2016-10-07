namespace EventsSandbox.Models
{
    using System;

    public delegate void JobUpdateHandler(object sender, JobDoneEventArgs e);
    public class Job
    {
        private string name;
        private int workHoursRequired;
        private Employee employee;

        public Job(string name, int workHoursRequired, Employee employee)
        {
            this.Name = name;
            this.WorkHoursRequired = workHoursRequired;
            this.Employee = employee;
        }

        public event JobUpdateHandler JobUpdate;

        public Employee Employee
        {
            get { return this.employee; }
            set { this.employee = value; }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int WorkHoursRequired
        {
            get
            {
                return workHoursRequired;
            }

            set
            {
                workHoursRequired = value;
            }
        }

        public void Update()
        {
            this.WorkHoursRequired = this.workHoursRequired - this.Employee.WorkHoursPerWeek;
            if (this.WorkHoursRequired <= 0)
            {
                Console.WriteLine("Job {0} done!", Name);
                this.OnJobUpdate(new JobDoneEventArgs(this)); // this.JobUpdate() ===== del();
            }
        }

        public void OnJobUpdate(JobDoneEventArgs e)
        {
            if (this.JobUpdate != null)
            {
                this.JobUpdate(this, e);
            }
        }

        public override string ToString()
        {
            return string.Format("Job: {0} Hours Remaining: {1}", this.Name, this.WorkHoursRequired);
        }
    }
}
