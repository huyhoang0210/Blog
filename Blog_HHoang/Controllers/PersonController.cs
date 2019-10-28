using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_HHoang.Models;
namespace Blog_HHoang.Controllers
{
    public class PersonController : Controller
    {
        BlogDbContext db = new BlogDbContext();
        // GET: Person
        public ActionResult Person()
        {
            User nguoidung = (User)Session["DangNhap"];
            if (nguoidung != null)
                {
                var listpost = db.Entrys.Where(n=>n.id_User == nguoidung.id_User).ToList();
                return View(listpost);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }             
        }
        public ActionResult detail(int ma)
        {
            Entry post = db.Entrys.SingleOrDefault(n => n.id_Entry == ma);
            ViewBag.detail_now = post.id_Entry.ToString();
            Session["detail"] = post;
            return View(post);
        }
        public PartialViewResult Comment(int ma)
        {
            var cmt = db.Comments.Where(n => n.id_Entry == ma).ToList();
            return PartialView(cmt);
        }
        public PartialViewResult addComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult addComment(FormCollection f, int ma)
        {
            User nguoidung = (User)Session["DangNhap"];
            Entry post = (Entry)Session["detail"];
            Comment cmt = new Comment() ;
            cmt.id_User = nguoidung.id_User;
            cmt.id_Entry = post.id_Entry;
            cmt.content = Request.Form["content"];
            db.Comments.Add(cmt);
            db.SaveChanges();
            return PartialView();
        }
        public PartialViewResult patialAbout4()
        {
            var post = db.Entrys.OrderByDescending(n => n.dates).Take(1).ToList();
            return PartialView(post);
        }
    }
}