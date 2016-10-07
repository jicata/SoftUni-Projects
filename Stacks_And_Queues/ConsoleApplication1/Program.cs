namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> myStack = new Stack<int>();
            Stack<int> maxNumbersStack = new Stack<int>();
            
            int maxElement = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string commandType = commandArgs[0];
                switch (commandType)
                {
                    case "1":
                        int numberToPush = int.Parse(commandArgs[1]);
                        myStack.Push(numberToPush);
                        // check if the element we are pushing to the main stack
                        // is bigger than maxElement
                        if (numberToPush >= maxElement)
                        {
                            maxElement = numberToPush;
                            // push it onto maxNumbersStack if it is
                            maxNumbersStack.Push(maxElement);
                        }
                        break;
                    case "2":
                        int currentMaxNumber = maxNumbersStack.Peek();
                        int itemAtTop = myStack.Pop();
                        // check if we are about to pop the maximum element from
                        // the main stack
                        if (currentMaxNumber == itemAtTop)
                        {
                            // if we are, then pop it from the 
                            // maxNumbersStack too
                            maxNumbersStack.Pop();

                            if (maxNumbersStack.Count > 0)
                            {
                                // if the maxNumber stack is not empty
                                // set the next element of the maxNumbersStack
                                // as the maxElement
                                maxElement = maxNumbersStack.Peek();
                            }
                            else
                            {
                                maxElement = int.MinValue;
                            }                          
                        }
                        break;
                    case "3":
                        Console.WriteLine(maxNumbersStack.Peek());
                        break;
                }

            }
        }
    }
}
