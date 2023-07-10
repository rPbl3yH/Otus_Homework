using System;
using System.Collections.Generic;

namespace SaveLoad.GameManagement
{
    public static class GameContext
    {
        private static List<object> _services = new List<object>();

        public static void Clear()
        {
            _services.Clear();
        }
        
        public static T GetService<T>() {
            foreach (var service in _services) {
                if (service is T result) {
                    return result;
                }
            }

            throw new Exception($"Service {typeof(T).Name} doesn't exist"); 
        }


        public static void AddService(object service)
        {
            _services.Add(service);    
        }

        public static void RemoveService(object service)
        {
            if (_services.Contains(service))
            {
                _services.Remove(service);
            }
        }
    }
}