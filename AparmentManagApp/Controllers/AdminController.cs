using ApartmentManager.Access.Framework;
using ApartmentManager.ManagerLayer.ManagerOperations;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManager.Controllers
{
    public class AdminController: Controller
    {
        AdminManager adminManager = new AdminManager(new AdminFWLayer());
        public IActionResult Index()
        {
            var values = adminManager.GetList();
            return View(values);
        }
    }
}
