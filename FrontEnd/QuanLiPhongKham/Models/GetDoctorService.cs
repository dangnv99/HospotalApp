using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham.Models
{
    public class responDoctorService
    {
        public string status { get; set; }
        public string msg { get; set; }
        public string id { get; set; }
        public List<GetDoctorService> data { get; set; }
    }
    
    
    public class GetDoctorService
    {

        public string id { get; set; }
        public string nameDoctor { get; set; }
        public string price { get; set; }
    }
}
