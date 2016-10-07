using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04WorkForce.Interfaces;
using _04WorkForce.Models;
using _04WorkForce.Models.Employees;

namespace _04WorkForce
{
    class WorkForce
    {
        static void Main(string[] args)
        {
            ModifiedList jobs = new ModifiedList();
            Dictionary<string, IEmployee> employeesByName = new Dictionary<string, IEmployee>();

            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] parameters = line.Split();
                switch (parameters[0])
                {
                    case "Job":
                        {
                            IEmployee employee = employeesByName[parameters[3]];
                            Job job = new Job(parameters[1], int.Parse(parameters[2]), employee);
                            job.JobDone += jobs.HandleJobDone;
                            jobs.Add(job);
                            break;
                        }
                    case "StandartEmployee":
                        {
                            StandartEmployee employee = new StandartEmployee(parameters[1]);
                            employeesByName.Add(parameters[1], employee);
                            break;
                        }
                    case "PartTimeEmployee":
                        {
                            PartTimeEmployee employee = new PartTimeEmployee(parameters[1]);
                            employeesByName.Add(parameters[1], employee);
                            break;
                        }
                    case "Pass":
                    {
                        List<Job> jobsToUpdate = new List<Job>(jobs);
                        foreach (var job in jobsToUpdate)
                        {
                            job.Update();
                        }
                        break;
                    }
                    case "Status":
                    {
                        foreach (var job in jobs)
                        {
                            Console.WriteLine(job);
                        }
                        break;
                    }
                }
                line = Console.ReadLine();
            }
        }
    }
}
