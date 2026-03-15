using System;
using DotnetPractice.Models;


namespace DotnetPractice.Services {

   public interface IEnrollmentService
   {

      public List<Enrollment> GetAllEnrollments();
      public void EnrollStudent(int studentId,int courseId,string grade);

      public void RemoveEnrollment(int id);

   }

}