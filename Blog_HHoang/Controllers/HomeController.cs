using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_HHoang.Models;
using System.IO;
namespace Blog_HHoang.Controllers
{
    public class HomeController : Controller
    {
        BlogDbContext db = new BlogDbContext();
        public ActionResult Index(string Search)
        {
            User nguoidung = (User)Session["DangNhap"];
            if (nguoidung != null)
            {
                List<Entry> list = new List<Entry>();
                if (Search != null)
                {
                    list = db.Entrys.Where(s => s.Title.Contains(Search)).ToList();
                }
                else
                {
                    list = db.Entrys.Take(6).OrderByDescending(n => n.dates).ToList();
                }
                return View(list);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult CreatePost()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult CreatePost(FormCollection f)
        {
            User nguoidung = (User)Session["DangNhap"];
            Entry post = new Entry();
                post.dates = DateTime.Now;
                post.content = Request.Form["content"];
                post.content1 = Request.Form["content"].Substring(0, 150)+"...";
                post.id_User = nguoidung.id_User;
                post.UrlImg = Request.Form["file"];
                post.Title = Request.Form["title"];
               db.Entrys.Add(post);
               db.SaveChanges();
            return PartialView();
        }
    }
}