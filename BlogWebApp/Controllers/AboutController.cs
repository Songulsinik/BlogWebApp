using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWebApp.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About

        AboutManager aboutManager = new AboutManager(new EFAboutDal());
        public ActionResult Index()
        {
            var aboutcontent = aboutManager.GetList();
            return View(aboutcontent);
        }

        public PartialViewResult Footer() 
        {
            var aboutcontentlist=aboutManager.GetList();
            return PartialView(aboutcontentlist);
        }

        public PartialViewResult MeetTheTeam()
        {
            AuthorManager authorManager = new AuthorManager(new EFAuthorDal());
            var authorlist=authorManager.GetList();
            return PartialView(authorlist);
        }

        [HttpGet]
        public ActionResult UpdateAboutList() 
        { 
           var aboutlist=aboutManager.GetList();
           return View(aboutlist);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            aboutManager.TUpdate(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}