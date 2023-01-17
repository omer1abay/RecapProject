using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    //class ve metotlara ekleyebilirsin, birden fazla kullanabilirsin, inherit edilen yerlerde de çalışsın
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //öncelik sırası.

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
