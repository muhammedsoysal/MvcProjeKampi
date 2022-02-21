using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.Dtos
{
    public class WriterRegisterDtoValidator : AbstractValidator<WriterRegisterDto>
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public WriterRegisterDtoValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriş yapın");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın");
            // RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");


            RuleFor(x => x.WriterMail).Must(IstHere).WithMessage("Bu Mail Adresi Sisteme Kayıtlı")
                .NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz")
                .Must(IsPassive).WithMessage("Hesabınız Pasif Görünüyor Lütfen Admin İle İletişime Giriş Yapınız");
            RuleFor(w => w.WriterPassword).NotEmpty().WithMessage("Parola boş bırakılamaz");
        }
        private bool IstHere(string mail)
        {
            var writerMail = writerManager.GetUserByMail(mail);
            if (writerMail != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsPassive(string mail)
        {
            var writerMail = writerManager.GetUserByMail(mail);
            if (writerMail != null)
            {
                if (writerMail.WriterStatus)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }


}
