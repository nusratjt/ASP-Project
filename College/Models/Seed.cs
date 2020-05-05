using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public static class Seed
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course
                    {
                        CourseCode = "Comp123",
                        CourseName = "Computer Program",
                        CourseDesc = "Just another course for programming"
                    },
                    new Course
                    {
                        CourseCode = "Comp225",
                        CourseName = "Advance Database",
                        CourseDesc = "Non-Sql and Sql databases"
                    },
                    new Course
                    {
                        CourseCode = "Eng210",
                        CourseName = "Communication01",
                        CourseDesc = "The first english course in college"
                    },
                    new Course
                    {
                        CourseCode = "Gned500",
                        CourseName = "Citizenship",
                        CourseDesc = "Course about global citizenship"
                    },
                    new Course
                    {
                        CourseCode = "Comp228",
                        CourseName = "Java Programming",
                        CourseDesc = "Post Secondary-Introduction to Java and Eclipse"
                    }, new Course
                    {
                        CourseCode = "Comp125",
                        CourseName = "Client-Side Web Development",
                        CourseDesc = "Learning JavaScript to implement on websites"
                    }, new Course
                    {
                        CourseCode = "Comp301",
                        CourseName = "Unix/Linux Operating Systems",
                        CourseDesc = "Fundamentals of Bash scripting"
                    }, new Course
                    {
                        CourseCode = "Comp200",
                        CourseName = "Scripting with Python",
                        CourseDesc = "An introduction to coding in python"
                    }

                );
            }
            //if (!context.Students.Any())
            //{
            //    context.Students.AddRange(
            //        new Student
            //        {
            //            FName = "John",
            //            LName = "Doe",
            //            Address = "123 Yong St",
            //            City = "Toronto"
            //        },
            //        new Student
            //        {
            //            FName = "Malik",
            //            LName = "Muddasir",
            //            Address = "22 King St",
            //            City = "Toronto"
            //        },
            //        new Student
            //        {
            //            FName = "George",
            //            LName = "Washington",
            //            Address = "100 Queen St",
            //            City = "Etobicoke"
            //        }, new Student
            //        {
            //            FName = "Sara",
            //            LName = "Williams",
            //            Address = "33 BackStreet St",
            //            City = "Oshawa"
            //        }, new Student
            //        {
            //            FName = "Frank",
            //            LName = "Einchman",
            //            Address = "65 Main St",
            //            City = "Toronto"
            //        }


            //    );
            //}
            context.SaveChanges();
        }
    }
}  

