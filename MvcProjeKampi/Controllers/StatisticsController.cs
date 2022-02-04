using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context _context = new Context();
        public ActionResult Index()
        {
           // Toplam kategori sayısı
            var toplamKategori = _context.Categories.Count();
            ViewBag.ToplamKategoriSayisi = toplamKategori;

            //  Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var yazilimKategorisi = _context.Categories.Count(x => x.CategoryID == 15);
            ViewBag.ToplamYazilimKategorisi = yazilimKategorisi;

            // Yazar adında 'a' harfi geçen yazar sayısı
            var SartliYazarAdi = _context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.SartiYazarAdları = SartliYazarAdi;

            //En fazla başlığa sahip kategori adı
            var enFazlaBaslikSayisi = _context.Headings.Where(u => u.CategoryID == _context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.Category.CategoryName).FirstOrDefault();
            ViewBag.EnFazlaBaslik = enFazlaBaslikSayisi;

            // Kategoriler tablosundaki aktif kategori sayisi
            var aktifKategori = _context.Categories.Count(x => x.CategoryStatus == true);
            ViewBag.AktifKategoriler = aktifKategori;
            return View();
        }
    }
}