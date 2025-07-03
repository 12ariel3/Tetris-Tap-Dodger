using System.Collections.Generic;
using System;
using UnityEngine.Assertions;

namespace Assets.Code.Core
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance => _instance ?? (_instance = new ServiceLocator());
        public static ServiceLocator _instance;

        private readonly Dictionary<Type, object> _services;

        private ServiceLocator()
        {
            _services = new Dictionary<Type, object>();
        }

        public void RegisterService<T>(T service)
        {
            var type = typeof(T);
            Assert.IsFalse(_services.ContainsKey(type), $"Service{type} already registered");
            _services.Add(type, service);
        }

        public void UnregisterService<T>()
        {
            var type = typeof(T);
            Assert.IsTrue(_services.ContainsKey(type), $"Service{type} is not registered");
            _services.Remove(type);
        }

        public T GetService<T>()
        {
            var type = typeof(T);
            if (!_services.TryGetValue(type, out var service))
            {
                throw new Exception($"Service {type} not found el otro es el {service}");
            }
            return (T)service;
        }

        public bool Contains<T>()
        {
            var type = typeof(T);
            return _services.ContainsKey(type);
        }
    }
}