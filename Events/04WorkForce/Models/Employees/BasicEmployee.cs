using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04WorkForce.Interfaces;

namespace _04WorkForce.Models.Employees
{
    public abstract class BasicEmployee : IEmployee
    {
        protected BasicEmployee(string name, int weeklyWorkHours)
        {
            this.Name = name;
            this.WeeklyWorkHours = weeklyWorkHours;
        }

        public string Name { get; private set; }

        public int WeeklyWorkHours { get; private set; }
    }
}
