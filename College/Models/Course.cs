using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public class Course
    {
        
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please enter course code")]
        [StringLength(10)]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Please enter course name")]
        [StringLength(30)]
        public string CourseName { get; set; }
        [StringLength(50)]
        public string CourseDesc { get; set; }
        public List<Student> Students { get; set; }
        
    }
}
