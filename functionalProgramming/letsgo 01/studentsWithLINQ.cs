namespace LinqExercise
{
    using System.Collections.Generic;
    using System.IO;
    using System;
    using System.Linq;
    


    public static class LinqExercise
    {
        public static void Main()
        {
            const string FilePath = @"../../../Students.txt";

            List<Student> students = new List<Student>();
            StreamReader theFile = new StreamReader(FilePath);
            Random rng = new Random();
            int[] marksToRead = new int[3];
            using (theFile)
            {
                theFile.ReadLine();
                string line = theFile.ReadLine();
                while (line != null)
                {

                    string[] tokens = line.Split();
                    
                    marksToRead[0] = rng.Next(2,7);
                    marksToRead[1] = rng.Next(2,7);
                    marksToRead[2] = rng.Next(2,7);

                    string firstName = tokens[0];
                    string lastName = tokens[1];
                    int age = int.Parse(tokens[2]);
                    int facultyNumber = int.Parse(tokens[3]);
                    string phoneNumber = tokens[4];
                    string email = tokens[5];
                    int group = int.Parse(tokens[6]);
                    List<int> marks = new List<int>();
                    for (int i = 0; i < marksToRead.Length; i++)
                    {
                        marks.Add(marksToRead[i]);

                    }
                    


                    students.Add(new Student(
                        
                        firstName,
                        lastName,
                        age,
                        facultyNumber,
                        phoneNumber,
                        email,
                        group,
                        marks
                        ));
                    line = theFile.ReadLine();

                }
               

            }
            Console.WriteLine("Sort by: 02. Group and order By name");
            Console.WriteLine();
            
            var grop2 = from person in students
                        where person.Group == 2
                        orderby person.FirstName
                        select person;

            foreach (var student in grop2)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7},{8},{9}", student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                     student.PhoneNumber, student.Email, student.Group, student.Marks[0], student.Marks[1], student.Marks[2]);
            }
            

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Sort by: 03. Last before first name alphabetically");
            Console.WriteLine();
            var firstBeforeLast = from person in students
                                  where (person.FirstName.CompareTo(person.LastName) >= 0)
                                  orderby person.LastName
                                  select person;
            foreach (var student in firstBeforeLast)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7},{8},{9}", student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                     student.PhoneNumber, student.Email, student.Group, student.Marks[0], student.Marks[1], student.Marks[2]);
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Sort by: 04. Age");
            Console.WriteLine();
            List<Student> firstLastAge = new List<Student>();
            var agedCheddar = from person in students
                              where (person.Age <= 24)
                              select new { person.LastName, person.FirstName, person.Age };
            foreach (var item in agedCheddar)
            {
                Console.WriteLine("{0} {1} {2}",item.FirstName,item.LastName, item.Age);
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Sort by: 05. First name and Last Name in descending order");
            Console.WriteLine();

            //extension method
            var extension = students.OrderByDescending(a => a.FirstName).ThenByDescending(a => a.LastName);
            foreach (var student in extension)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7},{8},{9}", student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                     student.PhoneNumber, student.Email, student.Group, student.Marks[0], student.Marks[1], student.Marks[2]);
            }
            Console.WriteLine();

            //query syntax
            var synTAXED = from person in students
                           orderby person.FirstName descending, person.LastName descending
                           select person;
            foreach (var student in synTAXED)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7},{8},{9}", student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                     student.PhoneNumber, student.Email, student.Group, student.Marks[0], student.Marks[1], student.Marks[2]);
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Filter by: 06. Email domain");
            Console.WriteLine();

            var filtered = from person in students
                           where (person.Email.Contains("abv.bg"))
                           select person;

            foreach (var student in filtered)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7},{8},{9}", student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                     student.PhoneNumber, student.Email, student.Group, student.Marks[0], student.Marks[1], student.Marks[2]);
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Filter by: 07. Phone number");
            Console.WriteLine();


            var NSAphone = from person in students
                           where person.PhoneNumber.StartsWith("02")
                           || person.PhoneNumber.StartsWith("+3592")
                           select person;

            foreach (var student in NSAphone)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7},{8},{9}", student.FirstName, student.LastName, student.Age, student.FacultyNumber,
                     student.PhoneNumber, student.Email, student.Group, student.Marks[0], student.Marks[1], student.Marks[2]);
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Filter by: 08. Excellent students");
            Console.WriteLine();

            var ecelenteEstudiantes = from person in students
                                      where person.Marks.Contains(6)
                                      select new { person.FirstName, person.LastName, person.Marks };

            foreach (var student in ecelenteEstudiantes)
            {
                Console.WriteLine("{0} {1} {2}, {3}, {4}", student.FirstName, student.LastName, student.Marks[0], student.Marks[1], student.Marks[2]);
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Filter by: 09. Weak students");
            Console.WriteLine();

            var estudianteDiCazzo = from person in students
                                    where ((PreciseContainsInts(person.Marks,2, 2)))
                                    select person;

            foreach (var student in estudianteDiCazzo)
            {
                Console.WriteLine("{0} {1} {2}, {3}, {4}", student.FirstName, student.LastName, student.Marks[0], student.Marks[1], student.Marks[2]);
            }

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Filter by: 10. Enrolled in 2014");
            Console.WriteLine();

            var twothousandAndLateStudents = from person in students
                                             where person.FacultyNumber.ToString().EndsWith("14")
                                             select person.Marks;
            foreach (var student in twothousandAndLateStudents)
            {
                Console.WriteLine("{0} {1} {2}", student[0], student[1], student[2]);
            }

            
        }
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
