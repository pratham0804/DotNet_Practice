using System;
using DotnetPractice.Models;
using DotnetPractice.Repositories;

namespace DotnetPractice.Services {

  public class CourseService : ICourseService
  {
        private readonly ICourseRepository _repo;
        public CourseService(ICourseRepository repo)
        {
            this._repo= repo;
        }
        public List<Course> GetAllCourses(){
            return _repo.GetAllCourses();
        }
        
        public Course GetCourseById(int id)
        {
           var course = _repo.GetCourseById(id);
           return course;
        }

        public void CreateCourse(string title,int credits){
            _repo.CreateCourse(title,credits);
        }

        public void DeleteCourse(int id){
           var course = _repo.GetCourseById(id);
           if(course != null){
            _repo.DeleteCourse(id);
           }
           else{
             Console.WriteLine("Course does not exist");
           }
        }

        public void UpdateCourseTitle(int id,string title){
            var course = _repo.GetCourseById(id);
            if(course != null){
               _repo.UpdateCourseTitle(id,title);
            }
            else{
              Console.WriteLine($"Course with {id} does not exist");
            }
        }
  }

}