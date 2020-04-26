using AllergyCore.Core.Interceptors;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllergyCore.Core.Aspects.Validation
{
    public class ValidationAspect : MethodInteception
    {
        private Type _type;
        public ValidationAspect(Type validatorType)
        {
            _type = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Constractor ile gelen validation tipinden yeni instance oluşturur.
            var validatior = (IValidator)Activator.CreateInstance(_type);

            //Fulent validationda validatorlar generic classlardır. Tip olarak hangi modeli validate edecekse onu alır.Constractor ile belirtilen Validator hangi, tipi alıyorsa
            //onun tipi bulunur.
            var modelType = _type.BaseType.GetGenericArguments()[0];

            //Methodun model tipinde olan argumanı;
            var models = invocation.Arguments.Where(t => t.GetType() == modelType);

            //Birden çok o modelden nesne kullanılabilir.
            foreach (var item in models)
            {
                var validateResult = ValidationTool.Validate(validatior, item);
                if (!validateResult.IsValid)
                    throw new ValidationException(validateResult.Errors);
            }

        }
    }
}
