namespace _11.GroupByJoin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<StudentSpecialty> specialties = new List<StudentSpecialty>();
            List<Student> students = new List<Student>();
            while (input != "Students:")
            {
                string[] specialtyArgs = input.Split();
                string specialtyName = specialtyArgs[0] + " " + specialtyArgs[1];
                int facNumber = int.Parse(specialtyArgs[2]);
                var specialty = new StudentSpecialty(specialtyName, facNumber);
                specialties.Add(specialty);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "END")
            {
                string[] studentArgs = input.Split();
                string studentName = studentArgs[1] + " " + studentArgs[2];
                int facNumber = int.Parse(studentArgs[0]);
                var student = new Student(studentName, facNumber);
                students.Add(student);
                input = Console.ReadLine();
            }
            var result = from sp in specialties
                join st in students on sp.facNumber equals st.facNumber
                orderby st.name
                select new {studentName = st.name, facultyNumber = st.facNumber, specialtyName = sp.name};
           
            foreach (var item in result)
            {
                Console.WriteLine("{0} {1} {2}",item.studentName, item.facultyNumber, item.specialtyName);
            }


        }
    }
    public class Student
    {
        public string name;
        public int facNumber;

        public Student(string name, int group)
        {
            this.name = name;
            this.facNumber = group;
        }
    }
    public class StudentSpecialty
    {
        public string name;
        public int facNumber;

        public StudentSpecialty(string name, int group)
        {
            this.name = name;
            this.facNumber = group;
        }
    }
}
