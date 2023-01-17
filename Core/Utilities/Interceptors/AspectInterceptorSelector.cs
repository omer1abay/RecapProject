using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList(); //sınıfın attribute'larını oku
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true); //metodun attribute'larını oku
            classAttributes.AddRange(methodAttributes); //listeye ekle 
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); //otomatik olarak sistemdeki tüm metotları logla..

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //önceliğe göre listeye ekle..
        }
    }
}
