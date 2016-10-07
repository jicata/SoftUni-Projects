using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04WorkForce.Interfaces;

namespace _04WorkForce.Models.Employees
{
    public class PartTimeEmployee : BasicEmployee
    {
        private const int PartTimeEmployeeWorkHours = 20;

        public PartTimeEmployee(string name) : base(name,PartTimeEmployeeWorkHours)
        {
        }
    }
}
