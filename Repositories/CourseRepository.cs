using System;
using DotnetPractice.Models;
using DotnetPractice.Data;

namespace DotnetPractice.Repositories
{
    public class CourseRepository : ICourseRepository 
    {   

        private readonly EnrollDBcontext _enrolldbcontext;
        // private readonly Course _c;
        public CourseRepository(EnrollDBcontext enrollDBcontext){
            this._enrolldbcontext = enrollDBcontext;
        }

        public List<Course> GetAllCourses(){
            return  _enrolldbcontext.Courses.ToList();
        }
        
        public Course GetCourseById(int id){

           var course = _enrolldbcontext.Courses.FirstOrDefault(e => e.CourseId == id);
           if(course != null){
                return course;
           }
           else{
               Console.WriteLine($"Course with {id} does not exist");
               return null;
           }
        }

        public void CreateCourse(string title,int credits){
            
            Course c = new Course {
                Title = title,
                Credits = credits
            };
            
            _enrolldbcontext.Courses.Add(c);
            _enrolldbcontext.SaveChanges();
        }

        public void DeleteCourse(int id){
           Course course =  _enrolldbcontext.Courses.FirstOrDefault(e => e.CourseId == id);

           if(course != null){
                _enrolldbcontext.Courses.Remove(course);
                _enrolldbcontext.SaveChanges();
           }
           else{
                Console.WriteLine($"Course with {id} does not exist");
           }
         
        }

        public void UpdateCourseTitle(int id,string title){
            var course   = _enrolldbcontext.Courses.FirstOrDefault(e => e.CourseId == id);

            if(course != null){
                course.Title = title;
                _enrolldbcontext.SaveChanges();
            }
            else{
                Console.WriteLine($"Course with {id} does not exist");
                
            }

            
        }
    }
}