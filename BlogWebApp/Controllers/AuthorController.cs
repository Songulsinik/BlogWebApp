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
    public class AuthorController : Controller
    {
        // GET: Autor
        BlogManager blogManager=new BlogManager(new EFBlogDal());
        AuthorManager authorManager=new AuthorManager(new EFAuthorDal());

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var autordetail=blogManager.GetBlogById(id);
            return PartialView(autordetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id) 
        {
            var blogautorid=blogManager.GetList().Where(x=>x.BlogId==id).Select(y=>y.AutorId).FirstOrDefault();
            var autorblogs = blogManager.GetBlogByAutor(blogautorid);
            return PartialView(autorblogs); 
        }

        public ActionResult AuthorList()
        {
            var authorlists=authorManager.GetList();
            return View(authorlists);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Autor autor)
        {
            AuthorValidator authorValidator=new AuthorValidator();
            ValidationResult results = authorValidator.Validate(autor);
            if (results.IsValid)
            {
                authorManager.TAdd(autor);
                return RedirectToAction("AuthorList");
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

        [HttpGet]
        public ActionResult AuthorEdit(int id) 
        {
            Autor autor=authorManager.GetById(id);
            return View(autor);
        }

        [HttpPost]
        public ActionResult AuthorEdit(Autor autor)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult results = authorValidator.Validate(autor);
            if (results.IsValid)
            {
                authorManager.TUpdate(autor);
                return RedirectToAction("AuthorList");
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

    }
}