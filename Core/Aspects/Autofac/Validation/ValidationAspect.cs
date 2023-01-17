using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //attribute'lara tipler Type ile atılır.
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //verilen tip IValidator değilse..
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        //Metot interception içerisindeki onbefore böyle çalışacak..
        protected override void OnBefore(IInvocation invocation)
        {
            //invocation = metot
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection : runtime'da bir şeyleri çalıştırabilmemizi sağlar new'lemek gibi
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //ProductValidator'ın çalışma tipini bul generic çalıştığı tipin ilkini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //parametrelerini bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
