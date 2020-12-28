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
    public class GroupController : Controller
    {
        private readonly MyDbContext _context;
        private readonly ILogger<GroupController> _logger;

        public GroupController(ILogger<GroupController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult List()
        {
            return View(_context.Groups);
        }

        [Authorize(Policy = "RequireModerator")]
        public IActionResult ShowAddStudentForm()
        {
            return View(_context.Groups.Include(g=>g.Faculty));
        }
    }
}
