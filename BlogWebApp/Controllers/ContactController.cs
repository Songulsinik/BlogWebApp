using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWebApp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager=new ContactManager(new EFContactDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(Contact contact)
        {
            ContactValidator contactValidator = new ContactValidator();
            ValidationResult results = contactValidator.Validate(contact);
            if (results.IsValid)
            {
               contact.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contactManager.TAdd(contact);
                return RedirectToAction("Index","Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
        public ActionResult SendBox() 
        {
            var messagelist = contactManager.GetList();
            return View(messagelist); 
        }

        public ActionResult MessageDetails(int id)
        {
            Contact contact=contactManager.GetById(id);
            return View(contact);
        }
    }
}