using System;
using System.Collections.Generic;
using System.Linq;
using College.Models;
using College.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace College.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository repository;
        private int PageSize = 5;
        public CourseController(ICourseRepository repo)
        {
            repository = repo;
        }

        //public ActionResult SaveDocument()
        //{
        //    var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    var exportFile = System.IO.Path.Combine(exportFolder, "test.pdf");
        //    using (var writer = new PdfWriter(exportFile))
        //    {
        //        using (var pdf = new PdfDocument(writer))
        //        {
        //            var doc = new Document(pdf);
        //            doc.Add(new Paragraph("Hello World"));
        //        }
        //    }
        //    string filePath = "~/images/bg-left.png";
        //    string contentType = "application/octet-stream";
            

        //    return File(filePath, contentType, "CourseList.pdf");
        //}
        public ViewResult DisplayPage(int page = 1) =>
            View(new CourseListViewModel
            {
                Courses = repository.Courses
                    .OrderBy(c => c.CourseId)
                    .Skip((page - 1) * PageSize) 
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Courses.Count()
                }
            });
        [Authorize(Roles = "Admin")]
        public ViewResult InsertPage()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ViewResult InsertPage(Course course)
        {
            if (ModelState.IsValid)
            {

                repository.SaveCourse(course);
                return View("Confirm", course);
            }
            else
            {
                return View();
            }
        }

        public ViewResult DataPage(int id)
        {
            var courses = repository.Courses.Include(s => s.Students);
            Course cc;
            if (id != 0)
            {
                cc = courses.FirstOrDefault(c => c.CourseId == id);
            }
            else
            {
                cc = courses.FirstOrDefault(c => c.CourseCode != null);
            }
            return View(cc);
        }

        [HttpPost]
        public ViewResult DataPage(Course course)
        {
            var courses = repository.Courses.Include(s => s.Students);
            Course cc = courses.FirstOrDefault(c => c.CourseId == course.CourseId);
            if (ModelState.IsValid)
            {
                return View(cc);
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ViewResult Updated(Course course)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCourse(course);
                return View(course);
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ViewResult Deleted(Course course)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteCourse(course);
                return View(course);
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ViewResult AddStudent(Student student)
        {
                if (ModelState.IsValid)
                {
                    repository.EnrollStudent(student);
                ViewBag.CourseName = repository.Courses.FirstOrDefault(c => c.CourseId == student.CourseId).CourseName;
                return View("AddStudent", student);
                }
                else
                {
                List<Course> a = new List<Course>();
                a = repository.Courses.ToList();
                ViewBag.ListOfItems = a;
                return View("UserPage");
                }
        }

        [Authorize(Roles = "User, Admin")]
        public ViewResult UserPage(int id)
        {
            List<Course> a = new List<Course>();
            a = repository.Courses.ToList();
            ViewBag.ListOfItems = a;
            ViewBag.CourseId = id;
            return View();

        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ViewResult UserPage(Student student)
        {
            if (ModelState.IsValid)
            {
                List<Course> a = new List<Course>();
                a = repository.Courses.ToList();
                ViewBag.ListOfItems = a;
                return View(student);
            }
            else
            {
                return View();
            }
        }
    }
}
