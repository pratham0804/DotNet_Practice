using System;
using DotnetPractice.Models;
using DotnetPractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPractice.Controllers {


  [ApiController]
  [Route("api/[controller]")]
  public class CourseController : ControllerBase
  {
      private readonly ICourseService _courseservice;
      public CourseController(ICourseService courseservice)
      {
          this._courseservice = courseservice;
      }


      [HttpGet]
      public ActionResult<List<Course>> GetAllCourses(){
          var courses = _courseservice.GetAllCourses();
          if(courses == null){
             return NotFound("Courses not found");
          }

          return Ok(courses);
      }


      [HttpGet("{id}")]
      public ActionResult<Course> GetCourseById(int id){
          var course = _courseservice.GetCourseById(id);
          if(course == null){
            return NotFound($"Course with {id} not found");
          }

          return course;
      }


      [HttpDelete("{id}")]
      public IActionResult DeleteCourse(int id){
        _courseservice.DeleteCourse(id);
        return Ok("Course deleted");
      }


      [HttpPost]
      public IActionResult CreateCourse(string title,int credits){
          _courseservice.CreateCourse(title,credits);
          return Ok("Course created");
      }

      [HttpPut("{id}")]
      public IActionResult UpdateCourse(int id , string title){
         _courseservice.UpdateCourseTitle(id,title);
         return Ok("Course Updated");
      }
  }
}