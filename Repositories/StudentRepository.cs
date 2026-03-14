using System;
using DotnetPractice.Models;
using DotnetPractice.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPractice.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        // we can hardcode the dbcontext object here , which will be tight coupling , so we make use of dependency injection 
        private readonly EnrollDBcontext _enrollDBcontext;
        public StudentRepository(EnrollDBcontext enrollDBcontext)
        {   
            this._enrollDBcontext = enrollDBcontext;
        }

        public List<Student> GetAllStudents()
        {
           return  _enrollDBcontext.Students.ToList();
        }

        public void CreateStudent(string name ,string email, int age)
        {
            Student s = new Student
            {
                StudentName = name,
                Email = email,
                Age = age
            }; 
            
            

            _enrollDBcontext.Students.Add(s);
            _enrollDBcontext.SaveChanges();
        }


        public void DeleteStudent(int id)
        {
           var student =  _enrollDBcontext.Students.Where(e => e.StudentId == id); // whenever you go for 

           if(student != null)
            {
                _enrollDBcontext.Students.Remove((Student)student);
                _enrollDBcontext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"No Student found with id {id}");  
            }
        }


        public void UpdateStudent(int id , string name)
        {
            //    var b =  _enrollDBcontext.Students.Where(e => e.StudentId == id); // here var is not Student ,it is IQueryable<>.... where returns IQueryable , but if i want single studet  i go for singleordefault or firstordefault...
            var b = _enrollDBcontext.Students.Find(id);

            if(b != null)
            {
                 b.StudentName = name;
                _enrollDBcontext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Student with {id} does not exist");
            }
        
        }

    }
}