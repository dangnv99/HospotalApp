using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham.Models
{
    [DataContract]
    public class CancleShuedule
    {
        [DataMember]
        public string scheduleID { get; set; }
    }
}
