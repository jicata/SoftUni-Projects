using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
       // int n = int.Parse(Console.ReadLine());
        var kur = new Stopwatch();
        
        string items = File.ReadAllText(@"C:\Users\Maika\Desktop\SoftUniStrikeTeam\PoisonousPlantsTests\test010in.txt");
        //string[] plants = Console.ReadLine().Split();
        string[] plants = items.Split(new char[] {' ', '\t', '\n'},StringSplitOptions.RemoveEmptyEntries);
        kur.Start();
        Stack<int> initialStack = new Stack<int>(plants.Length);
        Stack<int> secondaryStack = new Stack<int>(plants.Length);
        for (int i = 0; i < plants.Length; i++)
        {
            initialStack.Push(int.Parse(plants[i]));
        }
        Console.WriteLine(kur.Elapsed);
       
        int counter = 0;
        int currentPlant = 0;
        int nextPlant = 0;
        int lastPlant = 0;
        while (true)
        {
            int initialStackSize = initialStack.Count;
            int secondaryStackSize = secondaryStack.Count;
            if (counter%2 == 0)
            {
                while (initialStack.Count > 0)
                {
                    currentPlant = initialStack.Pop();
                    if (initialStack.Count > 0)
                    {
                        nextPlant = initialStack.Peek();
                        if (currentPlant <= nextPlant)
                        {
                            secondaryStack.Push(currentPlant);
                        }
                    }
                    else
                    {
                        secondaryStack.Push(currentPlant);
                    }
                    
                }
                if (secondaryStack.Count == initialStackSize)
                {
                    Console.WriteLine(counter);
                    break;
                }
            }
            else
            {
                initialStack.Push(secondaryStack.Pop());
                lastPlant = initialStack.Peek();
                while (secondaryStack.Count > 0)
                {
                    currentPlant = secondaryStack.Pop();
                    if (currentPlant <= lastPlant)
                    {
                        initialStack.Push(currentPlant);
                    }
                    lastPlant = currentPlant;

                }
                if (secondaryStackSize == initialStack.Count)
                {
                    Console.WriteLine(counter);
                    break;
                }
            }

            counter++;
        }
        kur.Stop();
        Console.WriteLine(kur.Elapsed);
    }
}