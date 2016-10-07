namespace EventsSandbox
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Models;

    class Program
    {

        static void Main()
        {
            ModifiedList jobs = new ModifiedList();
            Dictionary<string, Employee> employeesByName = new Dictionary<string, Employee>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split();
                switch (inputArgs[0])
                {
                    case "StandartEmployee": 
                        var standartEmployee = new StandartEmployee(inputArgs[1]);
                        employeesByName[inputArgs[1]] = standartEmployee;
                        break;
                    case "PartTimeEmployee":
                        var partTimeEmployee = new PartTimeEmployee(inputArgs[1]);
                        employeesByName[inputArgs[1]] = partTimeEmployee;
                        break;
                    case "Job":
                        var employee = employeesByName[inputArgs[3]];
                        var job = new Job(inputArgs[1], int.Parse(inputArgs[2]), employee);
                        jobs.Add(job);
                        job.JobUpdate += jobs.HandleJobCompletion;
                        break;
                    case "Pass":
                        List<Job> jobsToUpdate = new List<Job>(jobs);
                        foreach (var jobNumberOne in jobsToUpdate)
                        {
                            jobNumberOne.Update();
                        }
                        break;
                    case "Status":
                        foreach (var jobNumberOne in jobs)
                        {
                            Console.WriteLine(jobNumberOne);
                        }
                        break;
                }
                input = Console.ReadLine();
            }

        }
    }
}
