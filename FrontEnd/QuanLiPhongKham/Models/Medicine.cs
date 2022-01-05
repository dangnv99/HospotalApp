using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham.Models
{
    [DataContract]
    public class Medicine
    {
        [DataMember]
        public string nameMedicine { get; set; }

        [DataMember]
        public string useMedicine { get; set; }

        [DataMember]
        public string unit { get; set; }

        [DataMember]
        public string quantily { get; set; }

        [DataMember]
        public string priceMedicine { get; set; }

        [DataMember]
        public string idMedicine { get; set; }
    }
}
