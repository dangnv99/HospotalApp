using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham.Models
{
    [DataContract]
    class RequestUserRole
    {
         [DataMember]
        public string userId  { get; set; }
         [DataMember]
        public string roleId { get; set; }
    }
}
