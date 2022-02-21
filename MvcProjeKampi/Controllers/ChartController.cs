using DataAccessLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult WriterColumnChart()
        {
            return View();
        }
        public ActionResult CategoryPieChart()
        {
            return View();
        }
        public ActionResult HeadingPieChart()
        {
            return View();
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            }); categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            }); categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return categoryClasses;
        }
        public List<CategoryClass> CategoryList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            using (var context = new Context())
            {
                categoryClasses = context.Categories.Select(c => new CategoryClass()
                {
                    CategoryName = c.CategoryName,
                    CategoryCount = c.headings.Count
                }).ToList();
            }
            return categoryClasses;
        }
        public ActionResult CategoryCharts()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }
        public List<WriterChart> WriterList()
        {
            List<WriterChart> writerCharts = new List<WriterChart>();
            using (var context = new Context())
            {
                writerCharts = context.Writers.Select(c => new WriterChart
                {
                    WriterName = c.WriterName,
                    WriterCount = c.Headings.Count()
                }).ToList();
            }

            return writerCharts;
        }

        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }
        public List<HeadingChart> HeadingList()
        {
            List<HeadingChart> headingCharts = new List<HeadingChart>();
            using (var context = new Context())
            {
                headingCharts = context.Headings.Select(h => new HeadingChart
                {
                    HeadingName = h.HeadingName,
                    HeadingCount = h.Contents.Count
                }).ToList();
            }
            return headingCharts;
        }
        public ActionResult HeadingChart()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }
    }
}