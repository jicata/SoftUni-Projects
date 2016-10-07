namespace _04WorkForce.Models.Employees
{
    public class StandartEmployee : BasicEmployee
    {
        private const int StandartEmployeeWorkHours = 40;

        public StandartEmployee(string name) : base(name, StandartEmployeeWorkHours)
        {
        }
    }
}
