using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetPractice.Models;
using Microsoft.EntityFrameworkCore;


namespace DotnetPractice.Data
{
    public class EnrollDBcontext : DbContext
    {
        public EnrollDBcontext()
        {
            
        }


        // lets override the onconfiguring method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Enrolldb.db");

        }
        public DbSet<Student> Students {get; set;}
        public DbSet<Course> Courses {get; set;}
        public DbSet<Enrollment> Enrollments {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Enrollment>(
                entity => 
                
                
                {
                    entity.HasKey(e => e.Eid); // primary key banata hai 

                    entity.HasOne(e => e.Student).WithMany(e => e.Enrollments).HasForeignKey(e => e.StudentId); // one to many ,
                    
                    entity.HasOne(e => e.Course).WithMany(e => e.Enrollments).HasForeignKey(e => e.CourseId); // one to many 
                }
                


            );
        }
    }
}