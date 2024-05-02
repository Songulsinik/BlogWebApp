using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebGrease;

namespace BlogWebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: AuthorLogin
        UserProfileManager userProfileManager=new UserProfileManager();
        Context context=new Context();
        BlogManager blogManager = new BlogManager(new EFBlogDal());
        public ActionResult Index()
        {   
            return View();
        }

        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["AutorMail"];
            var profilevalues = userProfileManager.GetAuthorByMail(p);
            return PartialView(profilevalues);
        }
        public ActionResult UpdateUserProfile(Autor p)
        {
            userProfileManager.EditAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string p) 
        {
            p = (string)Session["AutorMail"];
            int id=context.Autors.Where(x=>x.AutorMail==p).Select(y=>y.AutorId).FirstOrDefault();
            var blogs=userProfileManager.GetBlogByAuthor(id);
            return View(blogs); 
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = blogManager.GetById(id);
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;


            List<SelectListItem> values2 = (from x in context.Autors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AutorName,
                                                Value = x.AutorId.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            blogManager.TUpdate(p);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.values = values;


            List<SelectListItem> values2 = (from x in context.Autors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AutorName,
                                                Value = x.AutorId.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            blogManager.TAdd(blog);
            return RedirectToAction("BlogList");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }

    }
}