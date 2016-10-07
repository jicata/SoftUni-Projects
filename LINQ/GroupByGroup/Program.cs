namespace GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<StudentSpecialty> specialties = new List<StudentSpecialty>();
            List<Student> students = new List<Student>();
            string specialtyInput = Console.ReadLine();
            while (specialtyInput != "Students:")
            {
                string[] specialtyDetails = specialtyInput.Split();
                var specialty = new StudentSpecialty(specialtyDetails[0] + " " + specialtyDetails[1],
                    int.Parse(specialtyDetails[2]));
                specialties.Add(specialty);
                specialtyInput = Console.ReadLine();
            }
            string studentInput = Console.ReadLine();
            while (studentInput != "END")
            {
                string[] studentInfo = studentInput.Split();
                var student = new Student(studentInfo[1] + " " + studentInfo[2], 
                    int.Parse(studentInfo[0]));
                students.Add(student);
                studentInput = Console.ReadLine();
            }
            var joined = students.Join(specialties, st => st.facultyNumber
                , sp => sp.facultyNumber, (st, sp) => new
                {
                    name = st.name,
                    facNumber = st.facultyNumber,
                    specialtyName = sp.name
                }).OrderBy(x=>x.name);
                

            foreach (var joinedStudent in joined)
            {
                Console.WriteLine("{0} {1} {2}", joinedStudent.name, joinedStudent.facNumber, joinedStudent.specialtyName);
            }
        }
    }

    public class Student
    {
        public string name;
        public int facultyNumber;

        public Student(string name, int facultyNumber)
        {
            this.name = name;
            this.facultyNumber = facultyNumber;
        }

        public override string ToString()
        {
            return this.name;
        }
    }

    public class StudentSpecialty
    {
        public string name;
        public int facultyNumber;

        public StudentSpecialty(string name, int facultyNumber)
        {
            this.name = name;
            this.facultyNumber = facultyNumber;
        }
    }
}
