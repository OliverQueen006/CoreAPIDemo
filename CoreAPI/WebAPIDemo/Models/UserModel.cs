using System;
using System.Runtime.Serialization;

namespace WebAPIDemo.Models
{
    [DataContract]
    public class UserModel
    {
<<<<<<< HEAD

        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Name")]
        public string UserName { get; set; }

        [DataMember(Name = "EmailId")]
        public string EmailId { get; set; }

        [DataMember(Name = "Mobile")]        
        public string Mobile { get; set; }

        [DataMember(Name = "Address")]        
        public string Address { get; set; }
        
        [DataMember(Name = "IsActive")]
=======
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
>>>>>>> a34019a681f9bf25975504cf86c1a20d00b56f2b
        public bool IsActive { get; set; }
    }
}