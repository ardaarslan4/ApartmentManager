using ApartmentManager.Access.Framework;
using ApartmentManager.Entities;
using ApartmentManager.ManagerLayer.ManagerOperations;
using ApartmentManager.ManagerLayer.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace ApartmentManager.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new UserFWLayer());

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            var uservalue = userManager.getListLoggedUser(usermail);
            return View(uservalue);
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = userManager.GetByID(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(User u)
        {
            UserValidator userValidator = new UserValidator();
            var user = userManager.GetList().Where(x => x.UserID == u.UserID).SingleOrDefault();
          
            userManager.TUpdate(u);        
            return View();
        }
    }
}
