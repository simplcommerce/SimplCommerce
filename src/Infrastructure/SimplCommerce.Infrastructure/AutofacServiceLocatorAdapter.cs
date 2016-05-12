using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.Practices.ServiceLocation;

namespace SimplCommerce.Infrastructure
{
    public class AutofacServiceLocatorAdapter : ServiceLocatorImplBase
    {
        /// <summary>
        ///     The <see cref="Autofac.IComponentContext" /> from which services
        ///     should be located.
        /// </summary>
        private readonly IContainer container;

        public AutofacServiceLocatorAdapter(IContainer container)
        {
            this.container = container;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }

            var enumerableType = typeof (IEnumerable<>).MakeGenericType(serviceType);
            var instance = container.Resolve(enumerableType);
            return ((IEnumerable) instance).Cast<object>();
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }

            return key != null ? container.ResolveNamed(key, serviceType) : container.Resolve(serviceType);
        }
    }
}