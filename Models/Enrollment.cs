using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetPractice.Models
{
    public class Enrollment
    {
        public int Eid {get; set;}
        public int StudentId {get; set;}
        public int CourseId {get; set;}
        public string? Grade{get; set;}

        public Student? Student {get; set;}
        public Course? Course {get; set;}

    }
}