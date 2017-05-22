using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract(Namespace = "CheckArgs")]
    public class User
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Indentificator { get; set; }
    }
}
