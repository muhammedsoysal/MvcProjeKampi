using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
<<<<<<< HEAD
        MessageManager messageManager = new MessageManager(new EfMessageDal());
=======
>>>>>>> 811ff1a61f53bbfe5b667fbe6f937ef6d8f8473b
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = contactManager.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues=contactManager.GetByID(id);
            return View();
        }
<<<<<<< HEAD
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
=======
>>>>>>> 811ff1a61f53bbfe5b667fbe6f937ef6d8f8473b
    }
}