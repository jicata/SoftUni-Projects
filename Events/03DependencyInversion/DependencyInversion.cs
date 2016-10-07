    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03DependencyInversion.Models;
using _03DependencyInversion.Models.Strategies;

namespace _03DependencyInversion
{
    class DependencyInversion
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] parameters = line.Split();
                if (parameters[0] == "mode")
                {
                    switch (parameters[1])
                    {
                        case "+":
                            calculator.ChangeStrategy(new AdditionStrategy());
                            break;
                        case "-":
                            calculator.ChangeStrategy(new SubtractionStrategy());
                            break;
                        case "*":
                            calculator.ChangeStrategy(new MultiplicationStrategy());
                            break;
                        case "/":
                            calculator.ChangeStrategy(new DivisionStrategy());
                            break;
                    }
                }
                else
                {
                    int firstOperand = int.Parse(parameters[0]);
                    int secondOperand = int.Parse(parameters[1]);
                    Console.WriteLine(calculator.PerformCalculation(firstOperand, secondOperand));   
                }
                line = Console.ReadLine();
            }
        }
    }
}
