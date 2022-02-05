using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
<<<<<<< HEAD

            List<SelectListItem> valueWriter = (from x in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }
                                              ).ToList();
            ViewBag.vlc = valueCategory;
=======
               
            List<SelectListItem> valueWriter = (from x in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName +" "+x.WriterSurName ,
                                                    Value = x.WriterID.ToString()
                                                }
                                              ).ToList();
           ViewBag.vlc = valueCategory;
>>>>>>> 6e07a30be204fb93d238df3638ceac869c44ee1d
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(p);
            return RedirectToAction("Index");
        }
<<<<<<< HEAD
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            var headingValue = headingManager.GetByID(id);
            ViewBag.vlc = valueCategory;
            return View(headingValue);
        }
=======
>>>>>>> 6e07a30be204fb93d238df3638ceac869c44ee1d
    }
}