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
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            aboutManager.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult DeleteAbout(int id)
        {
            var aboutValue = aboutManager.GetByID(id);
            if (aboutValue.AboutStatus == true)
            {
                aboutValue.AboutStatus = false;
            }
            else if (aboutValue.AboutStatus == false)
            {
                aboutValue.AboutStatus = true;
            }
            aboutManager.AboutDelete(aboutValue);
            return RedirectToAction("Index");
        }
    }
}