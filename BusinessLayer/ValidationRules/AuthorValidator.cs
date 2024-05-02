using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator:AbstractValidator<Autor>
    {
        public AuthorValidator() 
        {
            RuleFor(x => x.AutorName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
            RuleFor(x => x.AutorTitle).NotEmpty().WithMessage("Yazar başlık değeri boş geçilemez.");
            RuleFor(x => x.AutorImage).NotEmpty().WithMessage("Yazar görseli boş geçilemez.");
            RuleFor(x => x.AutorDescription).NotEmpty().WithMessage("Yazar hakkında kısmı boş geçilemez.");
            RuleFor(x => x.AutorAboutShort).NotEmpty().WithMessage("Yazar yetenekler kısmı boş geçilemez.");
            RuleFor(x => x.AutorMail).NotEmpty().WithMessage("Yazar mail kısmı boş geçilemez.");
            RuleFor(x => x.AutorPassword).NotEmpty().WithMessage("Yazar şifresi boş geçilemez.");
            RuleFor(x => x.AutorPhoneNumber).NotEmpty().WithMessage("Yazar telefon numarası boş geçilemez.");
           
        }
    }
}
