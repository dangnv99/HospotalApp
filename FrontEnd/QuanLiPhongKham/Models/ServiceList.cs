using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham
{
    public class responServicve
    {
        public string status { get; set; }
        public string msg { get; set; }
        public List<transInfo> data { get; set; }
    }

    public class transInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
    }
}
