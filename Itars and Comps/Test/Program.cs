namespace Test
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<int> stones = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            
            Lake lake = new Lake(stones);
            
             IEnumerator<int> rator = new CustomEnumerator(stones);
            foreach (var item in lake)
            {
                Console.WriteLine(item);
            }


        }
    }

    class Lake : IEnumerable<int>
    {
        public List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new CustomEnumerator(this.stones);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
      
    }
    class CustomEnumerator : IEnumerator<int>
    {
        private List<int> stones;
        private int index = -1;
        public CustomEnumerator(List<int> stones)
        {
            this.stones = stones;
        }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
           
                return ++this.index < this.stones.Count;

        }

        public void Reset()
        {
           
        }

        public int Current
        {
            get { return this.stones[this.index]; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }
    }
}
