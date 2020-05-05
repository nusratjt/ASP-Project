using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public class EFCourseRepository : ICourseRepository
    {
        private ApplicationDbContext context;

        public EFCourseRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Course> Courses => context.Courses;

        public void SaveCourse(Course course)
        {
            if (course.CourseId == 0)
            {
                context.Courses.Add(course);
            }
            else
            {
                Course dbEntry = context.Courses
                    .FirstOrDefault(c => c.CourseId == course.CourseId);
                if (dbEntry != null)
                {
                    dbEntry.CourseName = course.CourseName;
                    dbEntry.CourseCode = course.CourseCode;
                    dbEntry.CourseDesc = course.CourseDesc;
                    dbEntry.Students = course.Students;
                }
            }
            context.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            Course dbEntry = context.Courses
                .FirstOrDefault(c => c.CourseId == course.CourseId);
            if (dbEntry != null)
            {
                context.Courses.Remove(dbEntry);
                context.SaveChanges();
            }
        }
        public void EnrollStudent(Student student)
        {
            Course dbEntry = context.Courses
                .FirstOrDefault(c => c.CourseId == student.CourseId);
            if (dbEntry != null)
            {
                if (dbEntry.Students == null)
                {
                    dbEntry.Students = new List<Student>() { student };
                }
                else
                {
                    dbEntry.Students.Add(student);
                }
                
                context.SaveChanges();
            }
        }

    }
}
