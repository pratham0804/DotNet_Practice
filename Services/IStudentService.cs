using System;
using DotnetPractice.Models;
using DotnetPractice.Repositories;

namespace DotnetPractice.Services {

  public interface IStudentService{
      public List<Student> GetAllStudents();
      public Student GetStudentById(int id);

      public void CreateStudent(string name,string email , int age);

      public void DeleteStudent(int id);

      public void UpdateStudent(int id,string name);

  }

}