using System;
using DotnetPractice.Repositories;
using DotnetPractice.Models;

namespace DotnetPractice.Services {

  public interface ICourseService {
     
      public List<Course> GetAllCourses();
        
        public Course GetCourseById(int id);

        public void CreateCourse(string title,int credits);

        public void DeleteCourse(int id);

        public void UpdateCourseTitle(int id,string title);
  }
  

}