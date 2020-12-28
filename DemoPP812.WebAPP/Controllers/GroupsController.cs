using DomainRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoASP.WebAPP.Controllers
{
    public class GroupsController : Controller
    {
        private IGroupRepository _repository;

        public GroupsController(IGroupRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = "RequireAdministrator")]
        public IActionResult ShowAddStudentForm()
        {
            return View(_repository.AllItems.Include(g=>g.Faculty));
        }
    }
}
