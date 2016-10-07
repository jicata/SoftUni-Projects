namespace EventsSandbox.Models
{
    public abstract class Employee
    {
        private string name;
        private int workHoursPerWeek;

        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
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

        public int WorkHoursPerWeek
        {
            get
            {
                return workHoursPerWeek;
            }

            set
            {
                workHoursPerWeek = value;
            }
        }
    }
}
