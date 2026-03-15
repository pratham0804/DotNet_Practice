using System;
using DotnetPractice.Models;
using DotnetPractice.Repositories;

namespace DotnetPractice.Services {

  public class StudentService : IStudentService
  {
      private readonly IStudentRepository _repo;

      public StudentService(IStudentRepository repo)
      {
          this._repo = repo;
      }

      public List<Student> GetAllStudents(){
         return  _repo.GetAllStudents();
      }

      public Student GetStudentById(int id){
        return _repo.GetStudentById(id);
      }


      public void CreateStudent(string name,string email , int age){

          _repo.CreateStudent(name,email,age);
          

      }

      public void DeleteStudent(int id){
         _repo.DeleteStudent(id);
      }

      public void UpdateStudent(int id,string name){
          _repo.UpdateStudent(id,name);
      }

  }

}