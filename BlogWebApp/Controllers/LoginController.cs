using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogWebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorLogin(Autor p)
        {
            Context context = new Context();
            var userinfo=context.Autors.FirstOrDefault(x=>x.AutorMail==p.AutorMail && x.AutorPassword==p.AutorPassword);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.AutorMail, false);
                Session["AutorMail"]=userinfo.AutorMail.ToString();
                return RedirectToAction("Index","User");
            }
            else
            {
                return RedirectToAction("AuthorLogin","Login");
            }
                
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            Context context = new Context();
            var admininfo = context.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
                Session["UserName"] = admininfo.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }

        }
    }
}