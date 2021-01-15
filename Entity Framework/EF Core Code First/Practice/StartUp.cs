﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Data.Models;

namespace Practice
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var db = new StudentDbContext();

            db.Database.Migrate();
            //db.Students.Add(new Student
            //{
            //    FirstName = "Aleksandra",
            //    LastName = "Toncheva",
            //    RegistrationDate = DateTime.UtcNow,
            //    Type = StudentType.Enrolled
            //});

            var town = new Town
            {
                Name = "Pleven"
            };
            //db.Towns.Add(town);
            //town.Students.Add(db.Students.First());


            var course = new Course
            {
                Name = "ASP.NET",
                Description = "ASP.NET MVC"
            };

            //db.Courses.Add(course);

            var studentId = db.Students.Select(st => st.Id).First();
            var courseId = db.Courses.Select(c => c.Id).First();
            //db.StudentsCourses.Add(new StudentInCourse
            //{
            //    StudentId = studentId,
            //    CourseId = courseId
            //});



            //db.StudentsCourses.Add(new StudentInCourse
            //{
            //    Student = new Student
            //    {
            //        FirstName = "Georgi",
            //        LastName = "Delchev",
            //        RegistrationDate = DateTime.UtcNow,
            //        Town = new Town
            //        {
            //            Name = "Stara Zagora"
            //        }
            //    },
            //    Course = new Course
            //    {
            //        Name = "C# OOP",
            //        Description = "Interfaces, Delegates"
            //    }
            //});
            //db.SaveChanges();


            db.Students.ToList().ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} {e.RegistrationDate} {e.Type} {e.TownId}"));


        }
    }
}
