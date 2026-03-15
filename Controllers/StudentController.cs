using System;
using DotnetPractice.Services;
using DotnetPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   // base url , // url mapping to controller.....
    public class StudentController : ControllerBase
    {
       
        private readonly IStudentService _studentservice;
        public StudentController(IStudentService studentService)
        {
            this._studentservice = studentService;
        }

        
        [HttpGet]
        [Route("/getallstudents")]
        public ActionResult<List<Student>> GetStudents(){
           
           var students = _studentservice.GetAllStudents();
           if(students != null){
              return Ok(students);
           } 

           return NotFound("Students Not Found");
        }


        [HttpGet("{id}")]
        // [Route("getstudentsbyid")] // dont use this together , it will overide id parameter
        public ActionResult<Student> GetStudentById(int id){
            var student = _studentservice.GetStudentById(id);
            if(student == null){
              return NotFound("Student not found");
            }
            
              return Ok(student);
            
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id){
            _studentservice.DeleteStudent(id);
            return Ok("Student Deleted");
           
        }



        [HttpPost]
        public IActionResult CreateStudent(string name,string email,int age){
            _studentservice.CreateStudent(name,email,age);
            return Ok("Student Created");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id,string name){
            _studentservice.UpdateStudent(id,name);
            return Ok("Student Updated");
        }


    }
}