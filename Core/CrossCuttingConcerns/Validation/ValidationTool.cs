using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {                                    //entity'i object tipinde tutuyorum çünkü entity'e her şey gelebilir. Dto'lar mesela
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);  //Product için doğrulama contexti oluşturuldu.
            var result = validator.Validate(context);   //productValidator'daki kurallara göre nesneyi kontrol et, doğrula.
            if (!result.IsValid) //Eğer sonuç geçerli değilse hata fırlat. 
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
