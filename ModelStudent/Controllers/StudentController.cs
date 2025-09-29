using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelStudent.Models;
using System.Collections.Generic;
using System.Linq;
using ModelStudent.Models;

namespace ModelStudent.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>()
        {
            new Student { Id = 1, Name = "Nguyen Van A", Email = "a@gmail.com", Password = "Aa@123456",
                          Branch = Branch.IT, Gender = Gender.Male, IsRegular = true,
                          Address = "Hà Nội", DateOfBorth = new DateTime(1998,5,10), Score = 8.5 }
        };

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "0" },
                new SelectListItem { Text = "BE", Value = "1" },
                new SelectListItem { Text = "CE", Value = "2" },
                new SelectListItem { Text = "EE", Value = "3" }
            };

            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last().Id + 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }

            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "0" },
                new SelectListItem { Text = "BE", Value = "1" },
                new SelectListItem { Text = "CE", Value = "2" },
                new SelectListItem { Text = "EE", Value = "3" }
            };

            return View();
        }
    }
}
