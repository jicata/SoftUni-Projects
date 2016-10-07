using System.Collections.Generic;
namespace LinqExercise

{
    public class Student
    {
        public Student(
            
            string firstName,
            string lastName,
            int age,
            int facultyNumber,
            string phoneNumber,
            string email,
            int group,
            List<int> marks
            )
        {
           
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Group = group;
            this.Marks = marks;
        }

        

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int FacultyNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Group { get; set; }

        public List<int> Marks { get; set; }

       

        
    }
}
