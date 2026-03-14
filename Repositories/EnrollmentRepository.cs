using System;
using DotnetPractice.Models;
using DotnetPractice.Data;

namespace DotnetPractice.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {

        private readonly EnrollDBcontext _enrolldbcontext;
        
        public EnrollmentRepository(EnrollDBcontext enrollDBcontext)
        {   
            this._enrolldbcontext = enrollDBcontext;
        }

        public List<Enrollment> GetAllEnrollments(){
            return _enrolldbcontext.Enrollments.ToList();
        }
        public void EnrollStudent(int studentId,int courseId,string grade){
            Enrollment e = new Enrollment{
                StudentId = studentId,
                CourseId = courseId,
                Grade = grade
            };

            _enrolldbcontext.Enrollments.Add(e);
            _enrolldbcontext.SaveChanges();
        }

        public void RemoveEnrollment(int id){
            var enrollment = _enrolldbcontext.Enrollments.FirstOrDefault(e => e.Eid = id);

            if(enrollment != null){
                _enrolldbcontext.Enrollments.Remove(enrollment);
                _enrolldbcontext.SaveChanges();
            }
            else{
                Console.WriteLine($"Enrollment with Eid : {id} does not exist");
            }
        }

       

       
    }
}