using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using DomainContext;
using DemoASP.Models;
using DemoPP812.WebAPP.Models;

namespace DemoASP.WebAPP.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly MyDbContext _context;

        public StudentController(ILogger<StudentController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult List()
        {
            return View(_context
                .Students
                .Include(s => s.Group)
                .ThenInclude(g => g.Faculty)
                .Select(s => new StudentVM(s)));
        }
        public IActionResult Show(int? id)
        {
            if (id.HasValue)
            {
                var stud = _context
                .Students                
                .Include(s => s.Group)
                .ThenInclude(g => g.Faculty)                
                .FirstOrDefault(s => s.Id == id.Value);
                
                if (stud != null)
                {
                    return View(new StudentVM(stud));
                }
            }
            return RedirectToAction("Error");

        }

        [Authorize(Policy = "RequireModerator")]
        public async Task<IActionResult> Add(StudentVM stud)
        {
            await _context.Students.AddAsync(stud);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }
      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
