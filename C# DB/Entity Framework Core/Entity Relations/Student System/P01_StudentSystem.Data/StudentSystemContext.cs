using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }


        public HashSet<Course> Courses { get; set; }

        public HashSet<Homework> Homeworks { get; set; }

        public HashSet<Resource> Resources { get; set; }

        public HashSet<Student> Students { get; set; }

        public HashSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}