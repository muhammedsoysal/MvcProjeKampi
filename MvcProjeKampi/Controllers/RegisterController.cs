using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.Dtos;
using BusinessLayer.VlidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterRegisterDtoValidator writerValidator = new WriterRegisterDtoValidator();

        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View(new WriterRegisterDto());
        }
        [HttpPost]
        public ActionResult WriterRegister(WriterRegisterDto dto)
        {
            ValidationResult results = writerValidator.Validate(dto);

          
            Writer writer = new Writer();

            if (results.IsValid)
            {
                writer.WriterName = dto.WriterName;
                writer.WriterSurName = dto.WriterSurName;
                writer.WriterMail = dto.WriterMail;
                writer.WriterPassword = dto.WriterPassword;
                writer.WriterStatus = true;
                writer.WriterImage = "/AdminLTE-3.0.4/dist/img/2.png";
                writer.WriterTitle = "Üye";
                writerManager.WriterAdd(writer);
                return RedirectToAction("WriterLogin", "Login");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}