namespace SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<char> text = new List<char>();
            Stack<string> commands = new Stack<string>();
            Stack<string> removedElements = new Stack<string>();

        
            for (int i = 0; i < n; i++)
            {
                string rawCommand = Console.ReadLine();             
                string[] commandArgs = ProcessCommand(rawCommand);
                string commandType = commandArgs[0];
                switch (commandType)
                {
                    case "1":
                        commands.Push(rawCommand);
                        ExecuteAddCommand(commandArgs[1], text);
                        break;
                    case "2":
                        commands.Push(rawCommand);
                        int countToDelete = int.Parse(commandArgs[1]);
                        SaveElementsToDelete(text, countToDelete, removedElements);
                        ExecuteEraseCommand(countToDelete, text);
                        break;
                    case "3":
                        int indexOfElement = int.Parse(commandArgs[1]);
                        Console.WriteLine(text[indexOfElement -1]);
                        break;
                    case "4":
                        string lastCommand = commands.Pop();
                        string[] lastCommandArgs = ProcessCommand(lastCommand);
                        string lastCommandType = lastCommandArgs[0];
                        if (lastCommandType == "1")
                        {
                            int numberOfElementsToDelete = lastCommandArgs[1].Length;
                            ExecuteEraseCommand(numberOfElementsToDelete, text);
                        }
                        else
                        {
                            string elementsToReAdd = removedElements.Pop();
                            ExecuteAddCommand(elementsToReAdd, text);
                        }
                        break;
                }
               
            }
            
        }

        private static void SaveElementsToDelete(List<char> text, int countToDelete, Stack<string> removedElements)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = text.Count - countToDelete; i < text.Count; i++)
            {
                sb.Append(text[i]);
            }
            removedElements.Push(sb.ToString());
        }

        private static void ExecuteAddCommand(string elementsToAdd, List<char> text)
        {
            for (int i = 0; i < elementsToAdd.Length; i++)
            {
                text.Add(elementsToAdd[i]);
            }
        }

        private static void ExecuteEraseCommand(int countToDelete, List<char> text)
        {
            int textLength = text.Count;
            for (int j = 1; j <= countToDelete; j++)
            {
                text.RemoveAt(textLength - j);
            }
        }

        public static string[] ProcessCommand(string rawCommand)
        {
            return rawCommand.Split();
        }
    }
}
