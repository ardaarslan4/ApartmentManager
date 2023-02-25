using ApartmentManager.Access.Framework;
using ApartmentManager.Entities;
using ApartmentManager.ManagerLayer.ManagerOperations;
using ApartmentManager.ManagerLayer.Validations;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;


namespace ApartmentManager.Controllers
{
    public class AdminMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new MessageFWLayer());
        MessageValidator messageValidator = new MessageValidator();

        [HttpGet]
        public IActionResult Inbox()
        {
            var adminMail = User.Identity.Name;
            var messagelist = messageManager.GetListMessageInInbox(adminMail);
            

            return View(messagelist);
        }

        [HttpGet]
        public IActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);
            values.MessageStatus = true;
            messageManager.TUpdate(values);
            return View(values);
        }

        [HttpGet]
        public IActionResult Sendbox()
        {
            var adminMail = User.Identity.Name;
            var messagelist = messageManager.GetListMessageInSendbox(adminMail);
            return View(messagelist);
        }

        [HttpGet]
        public IActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message message)
        {
            var adminMail = User.Identity.Name;
            message.SenderMail = adminMail;
            ValidationResult result = messageValidator.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.TAdd(message);
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
