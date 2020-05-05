using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace College.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(15)]
        public string FName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(15)]
        public string LName { get; set; }
        [StringLength(40)]
        public string Address { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please choose a course")]
        public int CourseId { get; set; }

    }
}
