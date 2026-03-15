using System;
using DotnetPractice.Data;
using DotnetPractice.Models;


namespace DotnetPractice.Repositories
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public Student GetStudentById(int id);

        public void CreateStudent(string name , string email , int age);

        public void DeleteStudent(int id);

        public void UpdateStudent(int id, string name);
        
    }
}