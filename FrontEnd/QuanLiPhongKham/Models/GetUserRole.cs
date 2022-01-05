using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham.Models
{

    public class responUserRole
    {

        public string status { get; set; }

        public string msg { get; set; }

        public string code { get; set; }

        public string keyword { get; set; }

        public List<getUserlist> data { get; set; }
    }

    public class getUserlist
    {

        public string id { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string sex { get; set; }

        public string phone { get; set; }

        public string yearOfBirth { get; set; }

        public string identityCard { get; set; }

        public string job { get; set; }

        public string avatar { get; set; }

        public string note1 { get; set; }

        public string note2 { get; set; }

    }
}
