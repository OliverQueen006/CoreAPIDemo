using System;
using System.Threading;

namespace WebAPIDemo.Utility
{
    public class DbClientFactory<T>
    {
        private static Lazy<T> _lazyLoading = new Lazy<T>(
            () => (T)Activator.CreateInstance(typeof(T)), LazyThreadSafetyMode.ExecutionAndPublication
        );

        public static T Instance
        {
            get
            {
                return _lazyLoading.Value;
            }
        }
    }
}