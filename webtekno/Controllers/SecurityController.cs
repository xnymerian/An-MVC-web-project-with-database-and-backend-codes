using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using webtekno.Models.entity2;



namespace webtekno.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {

        hastadb2Entities3 db = new hastadb2Entities3();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(sifreler user)
        {
            
            var userIndb = db.sifreler.FirstOrDefault(x => x.kullaniciadi == user.kullaniciadi && x.sifre == user.sifre);
            
             
            if (userIndb == null )
            {
                ViewBag.Mesaj = "Gecersiz Kullanıcı.Kullanıcı adı veya şifre hatalı.";
                FormsAuthentication.SetAuthCookie(user.kullaniciadi, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Gecersiz Kullanıcı.Kullanıcı adı veya şifre hatalı.";
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult Register(sifreler user)
        {
            db.sifreler.Add(user);
            db.SaveChanges();
            return View();
        }
        
        public ActionResult Register()
        {
            return View();
        }

    }

}