using System;
using DotnetPractice.Models;
using DotnetPractice.Repositories;

namespace DotnetPractice.Services {

  public class EnrollmentService : IEnrollmentService
  {
    
    private readonly IEnrollmentRepository _enrollrepo;
    private readonly IStudentRepository _studentrepo;
    private readonly ICourseRepository _courserepo;
    public EnrollmentService(IEnrollmentRepository enrollrepo,IStudentRepository studentrepo , ICourseRepository courserepo)
    {
        this._enrollrepo = enrollrepo;
        this._courserepo = courserepo;
        this._studentrepo = studentrepo;
    }

    public List<Enrollment> GetAllEnrollments(){
      return _enrollrepo.GetAllEnrollments();
    }
    public void EnrollStudent(int studentId,int courseId,string grade){
         
         var course  = _courserepo.GetCourseById(courseId);
         var student = _studentrepo.GetStudentById(studentId);



         if(course != null && student != null){
            _enrollrepo.EnrollStudent(studentId,courseId,grade);
         }
         else{
           Console.WriteLine($"Enrollment cannot be created");
         }
    }

    public void RemoveEnrollment(int id){
       _enrollrepo.RemoveEnrollment(id);
    }


        

  }

}