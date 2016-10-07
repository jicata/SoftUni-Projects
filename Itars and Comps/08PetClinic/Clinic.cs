namespace _08PetClinic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Clinic : IEnumerable<Pet>
    {
        private List<Pet> rooms;
        private int size;
        private int used;
        private int centre;

        public List<Pet> Rooms
        {
            get
            {
                return rooms;
            }
         
        }

        public Clinic(int rooms)
        {
            this.ValidateRooms(rooms);
        }

        private void ValidateRooms(int rooms)
        {
            if (rooms % 2 == 0)
            {
                throw new InvalidOperationException("Rooms must be an odd number!");
            }

            this.rooms = new List<Pet>(rooms);
            for (int i = 0; i < rooms; i++)
            {
                this.Rooms.Add(null);
            }
            this.used = 0;
            this.size = rooms;
            this.centre = rooms / 2;
        }
        public bool Add(Pet pet)
        {
            int currentRoom = centre;
            // the step represents how many positions to the sides of the centre we will look at
            // (ex. room 2 is 1 position to the left of the centre(3))
            int step = 0;
            int stepsTaken = 0;
            bool goLeft = true;
            // we're looking for an empty room, we have an extra check about staying in the collection by ensuring that the step
            // will never get bigger than half the size of the collection
            while (this.rooms[currentRoom] != null && step <= this.rooms.Capacity / 2)
            {
                if (goLeft)
                {
                    currentRoom = this.centre - step;
                }
                else
                {
                    currentRoom = this.centre + step;
                }

                goLeft = !goLeft;

                stepsTaken++;
                if (stepsTaken == 2)
                {
                    step++;
                    stepsTaken = 0;
                }
            }

            if (this.rooms[currentRoom]== null)
            {
                this.rooms[currentRoom] = pet;
                this.used++;
                return true;
            }

            return false;
        }

        public bool Release()
        {
            if (this.rooms[centre] != null)
            {
                this.rooms[this.centre] = null;
                this.used--;
                return true;
            }
            else if (this.size > 1)
            {
                int currentRoom = centre + 1;
                while (this.rooms[currentRoom] == null && currentRoom != centre)
                {
                    currentRoom = ++currentRoom % this.rooms.Count;
                }

                if (this.rooms[currentRoom] != null)
                {
                    this.rooms[currentRoom] = null;
                    this.used--;
                    return true;
                }
            }
            return false;
        }

        public String Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= this.size; i++)
            {
                sb.Append(Print(i));
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public String Print(int room)
        {
            // we use room - 1 because indexing in the list is 0 based unlike the clinic
            if (this.rooms[room - 1] == null)
            {
                return "Room empty";
            }
            else
            {
                return this.rooms[room - 1].ToString();
            }
        }

        public bool HasEmptyRooms()
        {
            return this.used != this.size;
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            return this.rooms.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
