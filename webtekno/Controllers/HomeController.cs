using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using webtekno.Models.Entity;
using webtekno.Models.entity3;


namespace webtekno.Controllers
{
    public class HomeController : Controller
    {
        hastadb2Entities db = new hastadb2Entities();
        hastadb2Entities4 db1= new hastadb2Entities4();
        
        public ActionResult Index()
        {
            var degerler= db.hastabilgi1.ToList();
            return View(degerler);
            
        }
        [HttpGet]
        public ActionResult About()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult About( hastabilgi1 TBL )
        {
           db.hastabilgi1.Add( TBL );
            db.SaveChanges();

            return View();
        }

        
        public ActionResult Contact(string p)
        {
            var degerler = from d in db.hastabilgi1 select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.hastaad.Contains(p));
            }

            return View(degerler.ToList());

            
        }
        
        public ActionResult SIL(int id)
        {
            var kategori = db.hastabilgi1.Find(id);
            db.hastabilgi1.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Doctors()
        {
            var degerler = db1.doktorlar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Doctors1()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Doctors1(doktorlar DR)
        {
            db1.doktorlar.Add(DR);
            db1.SaveChanges();
            return View();
        }
        public ActionResult Doctors2(string p)
        {
            var degerler = from d in db1.doktorlar select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.doktorad.Contains(p));
            }

            return View(degerler.ToList());
            
        }
        public ActionResult HomePage()
        {
            return View();
        }


    }
}