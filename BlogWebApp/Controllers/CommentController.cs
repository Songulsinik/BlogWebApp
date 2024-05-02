﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWebApp.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment

        CommentManager commentManager=new CommentManager(new EFCommentDal());

        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentlist = commentManager.CommentByBlog(id);
            return PartialView(commentlist);
        }

        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id=id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment comment)
        {
            comment.CommentStatus = true;
            commentManager.TAdd(comment);
            return PartialView();
        }
        public ActionResult AdminCommentListTrue()
        {
            var commentlist=commentManager.CommentByStatusTrue();
            return View(commentlist);
        }
        public ActionResult AdminCommentListFalse()
        {
            var commentlist = commentManager.CommentByStatusFalse();
            return View(commentlist);
        }
        public ActionResult StatusChangeToFalse(int id)
        { 
            commentManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue"); 
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            commentManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }

    }
}