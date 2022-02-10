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
    public class SkillController : Controller
    {
        // GET: Skill
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var skillValues = skillManager.GetList();
            return View(skillValues);
        }
        public ActionResult List()
        {
            var skillValues = skillManager.GetList();
            return View(skillValues);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            skillManager.SkillAdd(skill);
            return RedirectToAction("List");
        }
        public ActionResult DeleteSkill(int id)
        {
            var skillValue = skillManager.GetByID(id);
            skillManager.SkillDelete(skillValue);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skillValue = skillManager.GetByID(id);
            return View(skillValue);
        }
        [HttpPost]
        public ActionResult EditSkill(Skill skill)
        {
            skillManager.SkillUpdate(skill);
            return RedirectToAction("List");
        }
    }
}