using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham.Models
{
    [DataContract]
    public class UserCreat
    {

        [DataMember]
        public string id { get; set; } 

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string sex { get; set; }

        [DataMember]
        public string yearOfBirth { get; set; }

        [DataMember]
        public string phone { get; set; }

        [DataMember]
        public string address { get; set; }

        [DataMember]
        public string identityCard { get; set; }

        [DataMember]
        public string job { get; set; }

        [DataMember]
        public string avatar { get; set; }

        [DataMember]
        public string note1 { get; set; }

        [DataMember]
        public string note2 { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }
    }
}
