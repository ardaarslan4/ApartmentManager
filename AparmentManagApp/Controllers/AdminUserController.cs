using ApartmentManager.Access.Framework;
using ApartmentManager.Entities;
using ApartmentManager.ManagerLayer.ManagerOperations;
using ApartmentManager.ManagerLayer.Validations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
namespace ApartmentManager.Controllers
{
    public class AdminUserController : Controller
    {
        UserManager userManager = new UserManager(new UserFWLayer());
        public IActionResult Index()
        {
            var users = userManager.GetList();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult result = userValidator.Validate(u);
            if (result.IsValid)
            {
                user.IsActive = true;
                userManager.TAdd(user);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var user = userManager.GetByID(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult UpdateUser(User u)
        {
            UserValidator validator = new UserValidator();
            var user = userManager.GetList().Where(x => x.UserID == u.UserID).SingleOrDefault();
            u.Password = user.Password;
            u.TCNo = user.TCNo;
            u.PhoneNumber = user.PhoneNumber;
            ValidationResult result = validator.Validate(u);
            if (result.IsValid)
            {
                userManager.TUpdate(u);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public IActionResult DeleteUser(int id)
        {
            var user = userManager.GetByID(id);
            userManager.TDelete(user);
            return RedirectToAction("Index");
        }
    }
}
