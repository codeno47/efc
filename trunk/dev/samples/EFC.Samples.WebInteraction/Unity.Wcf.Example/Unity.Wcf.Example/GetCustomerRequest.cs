using System.Runtime.Serialization;

namespace Unity.Wcf.Example
{
    [DataContract]
    public class GetCustomerRequest
    {
        [DataMember]
        public int CustomerId { get; set; }
    }
}