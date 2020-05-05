using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public interface ICourseRepository
    {

        IQueryable<Course> Courses { get; }

        void SaveCourse(Course course);
        void DeleteCourse(Course course);
        void EnrollStudent(Student student);
        
    }
}
