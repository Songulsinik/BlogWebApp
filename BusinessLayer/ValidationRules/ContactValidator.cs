using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanını boş geçemezsiniz");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyadı alanını boş geçemezsiniz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanını boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanını boş geçemezsiniz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanını boş geçemezsiniz");

        }
    }
}
