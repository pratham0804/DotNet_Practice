using System;

namespace DotnetPractice.Models
{
    public class Student
    {
        public int StudentId {get; set;}
        public string? StudentName {get; set;}
        public string? Email {get; set;}
        public int Age {get; set;}

        public ICollection<Enrollment> Enrollments {get; set;} = new List<Enrollment>();

    }
}