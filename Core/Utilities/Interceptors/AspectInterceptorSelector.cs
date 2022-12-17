using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IInterceptor = Microsoft.EntityFrameworkCore.Diagnostics.IInterceptor;

namespace Core.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        private IInterceptorSelector _interceptorSelectorImplementation;

        public MethodInterceptionBaseAttribute[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);


            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }

        public Castle.DynamicProxy.IInterceptor[] SelectInterceptors(Type type, MethodInfo method,
            Castle.DynamicProxy.IInterceptor[] interceptors)
        {
            return _interceptorSelectorImplementation.SelectInterceptors(type, method, interceptors);
        }
    }
}