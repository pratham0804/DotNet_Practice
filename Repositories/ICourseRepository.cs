using System;
using DotnetPractice.Models;

namespace DotnetPractice.Repositories
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourses();
        
        public Course GetCourseById(int id);

        public void CreateCourse(string Title,int Credits);

        public void DeleteCourse(int id);

        public void UpdateCourseTitle(int id,string Title);

        
    }
}