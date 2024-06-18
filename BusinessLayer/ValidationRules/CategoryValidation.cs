using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karakter Olmalıdır");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori Adı En Fazla 20 Karakter Olmalıdır");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).MinimumLength(3).WithMessage("Açıklama En Az 3 Karakter Olmalıdır");
        }
    }
}
