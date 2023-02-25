using ApartmentManager.Access.Framework;
using ApartmentManager.Entities;
using ApartmentManager.ManagerLayer.ManagerOperations;
using ApartmentManager.ManagerLayer.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
namespace ApartmentManager.Controllers
{
    public class UserMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new MessageFWLayer());
        MessageValidator messagevalidator = new MessageValidator();

        [HttpGet]
        public IActionResult Inbox()
        {
            var adminMail = User.Identity.Name;
            var messagelist = messageManager.GetListMessageInInbox(adminMail);
            
            return View(messagelist);
        }

        [HttpGet]
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);
            values.MessageStatus = true;
            messageManager.TUpdate(values);
            return View(values);
        }

        [HttpGet]
        public ActionResult Sendbox()
        {
            var adminMail = User.Identity.Name;
            var messagelist = messageManager.GetListMessageInSendbox(adminMail);
            return View(messagelist);
        }

        [HttpGet]
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message m)
        {
            var userMail = User.Identity.Name;
            m.SenderMail = userMail;
            ValidationResult result = messagevalidator.Validate(m);
            if (result.IsValid)
            {
                m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.TAdd(m);
                return RedirectToAction("Sendbox");
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
    }
}
