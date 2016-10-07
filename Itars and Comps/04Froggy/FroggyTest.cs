using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Froggy
{
    using System.Linq.Expressions;

    class FroggyTest
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Lake lake = new Lake(stones);
            Console.WriteLine(string.Join(", ", lake));

            //ConstantExpression constExp = Expression.Constant(5, typeof(int));
            //ParameterExpression paramExp = Expression.Parameter(typeof(int), "i");
            //BinaryExpression exp = Expression.GreaterThan(paramExp, constExp);
            //Console.WriteLine(exp.Left);
            //Console.WriteLine(exp.Right);
            //Console.WriteLine(exp.Type);
            //Console.WriteLine(exp.NodeType);
        }
    }

    class Lake : IEnumerable<int>
    {
        private IList<int> stones;
        public Lake(IEnumerable<int> stones)
        {
            this.stones = new List<int>(stones);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i+=2)
            {
                yield return stones[i];
            }

            int lastOddPosition = this.stones.Count % 2 == 0 ? this.stones.Count - 1 : this.stones.Count - 2;
            for (int i = lastOddPosition; i >= 0; i-=2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
