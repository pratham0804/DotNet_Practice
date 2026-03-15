using System;
using DotnetPractice.Models;
using DotnetPractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPractice.Controllers {


  [ApiController]
  [Route("api/[controller]")]
  public class EnrollmentController : ControllerBase
  {
      private readonly IEnrollmentService _enrollmentservice;
      public EnrollmentController(IEnrollmentService enrollmentservice)
      {
          this._enrollmentservice = enrollmentservice;
      }

      [HttpGet]
      public ActionResult<List<Enrollment>> GetAllEnrollment(){
          var enrollments = _enrollmentservice.GetAllEnrollments();
          if(enrollments == null){
             return NotFound("Courses not found");
          }

          return Ok(enrollments);
      }

      [HttpPost]
      public IActionResult EnrollStudent(int studentId,int courseId,string grade){
          _enrollmentservice.EnrollStudent(studentId,courseId,grade);
          return Ok("Student enrolled");
      }

      [HttpDelete("{id}")]
      public IActionResult RemoveEnrollment(int id){
         _enrollmentservice.RemoveEnrollment(id);
         return Ok("Enrollment removed");
      }
     
      
  }
}