using System.Runtime.Serialization;

namespace Unity.Wcf.Example
{
    [DataContract]
    public class GetCustomerResponse
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }
}