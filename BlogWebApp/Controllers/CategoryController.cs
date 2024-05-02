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
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var values = categoryManager.GetList();
            return PartialView(values);
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist=categoryManager.GetList();
            return View(categorylist);
        }

        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            CategoryValidator categoryValidator=new CategoryValidator();
            ValidationResult results=categoryValidator.Validate(p);
            if(results.IsValid)
            {
                categoryManager.TAdd(p);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
           return View();
        }


        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {

            Category category = categoryManager.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.TUpdate(category);
                return RedirectToAction("AdminCategoryList");
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

        public ActionResult CategoryDelete(int id) 
        {
            categoryManager.CategoryStatusFalseBL(id);
            return RedirectToAction("AdminCategoryList");
        }

        public ActionResult CategoryStatusTrue(int id)
        {
            categoryManager.CategoryStatusTrueBL(id);
            return RedirectToAction("AdminCategoryList");
        }
    }

}