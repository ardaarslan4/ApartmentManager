using ApartmentManager.Access.Framework;
using ApartmentManager.Entities;
using ApartmentManager.ManagerLayer.ManagerOperations;
using ApartmentManager.ManagerLayer.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FluentValidation;


namespace ApartmentManager.Controllers
{
    public class AdminHouseController : Controller
    {
        HouseManager houseManager = new HouseManager(new HouseFWLayer());

        public IActionResult Index()
        {
            var values = houseManager.GetList();
            return View(values);
        }

        public IActionResult GetHouseDetail(int id)
        {
            var value = houseManager.GetByID(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult AddHouse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHouse(House house)
        {
            HouseValidator validator = new HouseValidator();
            ValidationResult result = validator.Validate(house);
            if (result.IsValid)
            {
                house.IsEmpty = false;
                houseManager.TAdd(h);
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

        [HttpGet]
        public IActionResult UpdateHouse(int id)
        {
            var house = houseManager.GetByID(id);
            return View(house);
        }

        [HttpPost]
        public IActionResult UpdateHouse(House house)
        {
            var x = houseManager.GetList().Where(x => x.HouseID == house.HouseID).SingleOrDefault();
            x.HouseNo = house.HouseNo;
            x.Floor = house.Floor;
            x.HouseType = house.HouseType;
            x.Block = house.Block;
            houseManager.TUpdate(x);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteHouse(int id)
        {
            var house = houseManager.GetByID(id);
            houseManager.TDelete(house);
            return RedirectToAction("Index");
        }
    }
}
