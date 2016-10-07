namespace EventsSandbox.Models
{
    public class StandartEmployee : Employee
    {
        private const int workHoursPerWeek = 40;
        public StandartEmployee(string name) 
            : base(name, workHoursPerWeek)
        {
        }
    }
}
