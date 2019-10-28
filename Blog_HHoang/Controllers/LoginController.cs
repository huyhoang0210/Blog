using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_HHoang.Models;

namespace Blog_HHoang.Controllers
{
    public class LoginController : Controller
    {
        BlogDbContext db = new BlogDbContext(); 
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string tk = Request.Form["SDT"];
            string mk = Request.Form["MatKhau"];
            User taikhoan = db.Users.SingleOrDefault(t => t.phonenumber.ToString() == tk && t.pass.Trim() == mk);
            if (taikhoan != null)
            {
                Session["DangNhap"] = taikhoan;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection f)
        {
            User taikhoan = new User();
            taikhoan.name = Request.Form["Name"];
            taikhoan.pass = Request.Form["Pass"];
            taikhoan.phonenumber = int.Parse(Request.Form["SDT"]);
            //taikhoan.NgaySinh =Request.Form["NgaySinh"];
            db.Users.Add(taikhoan);
            db.SaveChanges();
            return RedirectToAction("Login", "Login");

        }
        public ActionResult Logout()
        {
            Session["DangNhap"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}