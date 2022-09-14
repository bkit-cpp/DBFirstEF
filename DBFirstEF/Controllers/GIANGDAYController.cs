using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirstEF.Controllers
{
    public class GIANGDAYController : Controller
    {
        // GET: GIANGDAY
      
        public ActionResult Index()
        {
            using (QUANLYGVEntities qlgv = new QUANLYGVEntities())
            {
                return View(qlgv.GIANGDAYs.ToList());
            }

        }
        [HttpPost]
        public ActionResult Details()
        {
            return View();
        }
        
        public ActionResult Details(string id)
        {
            
                        using (QUANLYGVEntities qlgv1 = new QUANLYGVEntities())
                        {
                            return View(qlgv1.GIANGDAYs.Where(x => x.MALOP == id).FirstOrDefault());
                        }
            
            
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GIANGDAY gd)
        {
            try
            {
                using (QUANLYGVEntities QLGV = new QUANLYGVEntities())
                {
                    if (ModelState.IsValid)// Kiem tra du lieu dau vao co hop le khong?
                    {
                        QLGV.GIANGDAYs.Add(gd);
                        QLGV.SaveChanges();

                    }
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete( string id)
        {
            try
            {
                using (QUANLYGVEntities qlgv2 = new QUANLYGVEntities())
                {
                    var data = qlgv2.GIANGDAYs.Where(x => x.MALOP == id).FirstOrDefault();
                    if (data!=null)
                    {
                        qlgv2.GIANGDAYs.Remove(data);
                        qlgv2.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(string id)
        {
            using (QUANLYGVEntities qlgv3 = new QUANLYGVEntities())
            {
                return View(qlgv3.GIANGDAYs.Where(x=>x.MALOP==id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Edit(string id,GIANGDAY gd)
        {
            try
            {
                using (QUANLYGVEntities qlgv3 = new QUANLYGVEntities())
                {
                    var data = qlgv3.GIANGDAYs.Where(x => x.MALOP == id).FirstOrDefault();
                    if (data != null)
                    {
                        data.MAMH = gd.MAMH;
                        data.HOCKY = gd.HOCKY;
                        data.NAM = gd.NAM;
                        data.TUNGAY = gd.TUNGAY;
                        data.DENNGAY = gd.DENNGAY;
                        qlgv3.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}