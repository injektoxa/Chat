using System;
using System.Collections.Generic;
using System.Diagnostics;
using Chat.Core.Interfaces;
using Microsoft.Practices.Unity;

namespace Chat.Core.Impl
{
    /// <summary>
    /// Encapsulates Unity IoC, this class is internal and is not visible
    /// to other assemblies, it can be accessed via the IConteinerService
    /// </summary>
    //[DebuggerStepThrough] //debugger don't go inside this methods
    internal class UnityContainerWrapper : IContainer
    {
        private readonly UnityContainer container;

        internal UnityContainerWrapper()
        {
            container = new UnityContainer();
            RegisterDefault();
        }

        #region IContainer Members

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public T Resolve<T>(string name)
        {
            return container.Resolve<T>(name);
        }

        public object Resolve(Type type)
        {
            return container.Resolve(type);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return container.ResolveAll<T>();
        }

        public void Register(Type type)
        {
            container.RegisterType(type);
        }

        public void Register(Type interfaceType, Type classType)
        {
            container.RegisterType(interfaceType, classType);
        }

        public void RegisterInstance<T>(T instance)
        {
            container.RegisterInstance(instance);
        }

        public void RegisterInstance<T>(T instance, string name)
        {
            container.RegisterInstance(name, instance);
        }

        public void Teardown(object instance)
        {
            container.Teardown(instance);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        public void RegisterSingleton<T>(T instance)
        {
            container.RegisterInstance(instance, new ContainerControlledLifetimeManager());
        }

        private void RegisterDefault()
        {
            //register logger with the interface
            container.RegisterInstance<IChatLogger>(new ChatLogger(), new ContainerControlledLifetimeManager());      
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (container != null)
                {
                    container.Dispose();
                }
            }
        }
    }
}
