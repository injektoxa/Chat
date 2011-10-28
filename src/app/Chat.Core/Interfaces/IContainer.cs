using System;
using System.Collections.Generic;

namespace Chat.Core.Interfaces
{
    /// <summary>
    /// Represents Inversion of Control container abstraction
    /// So any IoC container can be used: Unity, Castle etc.
    /// </summary>
    public interface IContainer : IDisposable
    {         
        void Register(Type type);
        void RegisterInstance<T>(T instance);
        void Register(Type interfaceType, Type classType);
        object Resolve(Type type); 
        T Resolve<T>(string name);
        T Resolve<T>();
        void Teardown(object instance);    
        void RegisterInstance<T>(T instance, string name);
        IEnumerable<T> ResolveAll<T>();  
    }
}
