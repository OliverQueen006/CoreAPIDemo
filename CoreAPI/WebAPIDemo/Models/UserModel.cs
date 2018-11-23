using System;
using System.Runtime.Serialization;

namespace WebAPIDemo.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "Id")]
        public int ID { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "EmailId")]
        public string EmailID { get; set; }

        [DataMember(Name = "Mobile")]
        public string Mobile { get; set; }

        [DataMember(Name = "Address")]
        public string Address { get; set; }

        [DataMember(Name = "IsActives")]
        public bool IsActive { get; set; }
    }
}