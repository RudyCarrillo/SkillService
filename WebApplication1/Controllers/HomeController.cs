using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }

    public class RoutesDemoController : Controller
    {
        public ActionResult One()
        {
            return View();
        }

        public ActionResult Two(int donuts = 1)
        {
            ViewBag.Donuts = donuts;
            return View();
        }

        [Authorize]
        public ActionResult Three()
        {
            return View();
        }

        public ActionResult Four()
        {
            return View();
        }

        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjectResult(Project project)
        {
            SkillsService proxy = new SkillsService();
            proxy.createProject(project.name);
            return View();
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeResult(Employee employee)
        {
            SkillsService proxy = new SkillsService();
            proxy.createEmployee(employee.name);
            return View();
        }

        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SkillResult(Skill skill)
        {
            SkillsService proxy = new SkillsService();
            proxy.createSkill(skill.name);
            return View();
        }

        public ActionResult Read()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ReadResult(string name)
        {
            SkillsService proxy = new SkillsService();
            var parents = proxy.read(name);
            return Json(parents, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPut]
        public ActionResult UpdateResult(string name, string parent)
        {
            SkillsService proxy = new SkillsService();
            proxy.update(name, parent);
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult DeleteResult(string name)
        {
            SkillsService proxy = new SkillsService();
            proxy.delete(name);
            return View();
        }
    }

    public class Project
    {
        public string name { get; set; }
    }

    public class Employee
    {
        public string name { get; set; }
    }

    public class Skill
    {
        public string name { get; set; }
    }


    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public AccountController() { }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public ApplicationSignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { _signInManager = value; }
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
    }

}