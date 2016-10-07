using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinqExercise
{
    //can't link it to main .cs file for some reason
    public static class extension
    {
        public static bool PreciseContainsInts(this List<int> list, int number, int count)
        {
            bool match = false;
            int counter = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == number)
                {
                    counter++;
                   
                }
            }
            if (counter == count)
            {
                match = true;
                return match;
            }
            else
            {
                return match;
            }
            
        }
    }
}
