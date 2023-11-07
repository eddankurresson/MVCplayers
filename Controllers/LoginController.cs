using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcPlayers.Models;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcPlayers.Controllers
{
    public class LoginController : Controller
    {

        static List<User> Users = new List<User>(); 

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if ((user.Username == "Edvin" && user.Password == "1234") || (user.Username == "Edvin1" && user.Password == "12345"))
            {
                HttpContext.Session.SetString("Username", user.Username);
                return Redirect(Url.Action("Index", "Home"));
            }
            return View("Index", user);
        }

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
    }
}

