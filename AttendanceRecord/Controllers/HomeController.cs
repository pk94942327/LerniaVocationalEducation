using Microsoft.EntityFrameworkCore;
using AttendanceRecord.Data;
using AttendanceRecord.Models.SchoolViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceRecord.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;

        public HomeController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Enrollment()
        {
            IQueryable<EnrollmentDateGroup> data =
                from student in _context.Students
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }



        public IActionResult Contact()
        {
            ViewData["Message"] = "Välkommen att kontakta oss!";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
