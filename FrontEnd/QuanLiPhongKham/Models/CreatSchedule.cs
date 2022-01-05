using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham.Models
{
    public class CreatSchedule
    {
        public string doctorId { get; set; }
        public string patientId { get; set; }
        public string dateTimeStamp { get; set; }
        public string status { get; set; }
        public string id { get; set; }
        public string serviceId { get; set; }
    }

    public class ResultFetListSchedule
    {
        public string status { get; set; }
        public string msg { get; set; }
       
        public List<CreatSchedule> data { get; set; }
    }

    public class CreatScheduleDangKy
    {
        public string doctorId { get; set; }
        public string patientId { get; set; }
        public string dateTimeStamp { get; set; }
    
        public string serviceId { get; set; }
    }
}
