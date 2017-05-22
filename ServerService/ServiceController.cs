using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Xml;

namespace ServerService
{
    public delegate void LogHandler(string message);
    public class ServiceController:Singleton<ServiceController>
    {
        public ServiceHost Service => host;
        public List<User> DataBase => database;
        public LogHandler OnLog;
        public Func<User, bool> ExistFunc;
        private void Log(string message)
        {
            OnLog?.Invoke(message);
        }
        private ServiceHost host;
        private List<User> database;
        public void Initialize<T>(string hoster)
            where T:IService
        {
            try
            {
                if (ExistFunc == null)
                {
                    Log("Ошибка при запуске. Ошибка: не была прозведена инициализация предиката ExistFunc.");
                    return;
                }
                host = new ServiceHost(typeof(T));
                var binding = new BasicHttpBinding()
                {
                    MaxBufferPoolSize = 2147483647,
                    MaxBufferSize = 2147483647,
                    MaxReceivedMessageSize = 2147483647,
                    ReaderQuotas = new XmlDictionaryReaderQuotas()
                    {
                        MaxDepth = 2000000,
                        MaxStringContentLength = 2147483647,
                        MaxArrayLength = 2147483647,
                        MaxBytesPerRead = 2147483647,
                        MaxNameTableCharCount = 2147483647
                    }
                };
                host.AddServiceEndpoint(typeof(IService), binding, $"http://{hoster}/IService");
                host?.Open();
                if (host != null)
                    Log("Сервер стартовал");
                else
                    Log("Ошибка при запуске. Ошибка: не инициализирован хост.");
            }
            catch(Exception ex)
            {
                Log($"Ошибка при запуске. Ошибка: {ex.Message}");
            }
        }
    }
}
