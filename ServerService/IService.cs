using System.ServiceModel;

namespace ServerService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
         bool? CheckLicense(User args);
    }
}
