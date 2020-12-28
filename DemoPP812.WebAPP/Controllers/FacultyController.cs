using DomainContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoASP.WebAPP.Controllers
{
    public class FacultyController : Controller
    {
        private readonly MyDbContext _context;
        private readonly ILogger<FacultyController> _logger;

        public FacultyController(ILogger<FacultyController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult List()
        {
            return View(_context.Faculties);
        }
       
    }
}
