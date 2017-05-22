using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    public class ServiceImplementation : IService
    {
        public bool? CheckLicense(User args)
        {
            return ServiceController.Instance.ExistFunc?.Invoke(args);
        }
    }
}
