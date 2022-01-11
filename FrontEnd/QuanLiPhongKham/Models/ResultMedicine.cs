using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham.Models
{
    public class resultReq_
    {
        public string status { get; set; }
        public string msg { get; set; }
        public List<ResultMedicine> data { get; set; }
    }

    
    public class ResultMedicine
    {
        
        public string nameMedicine { get; set; }

        public string useMedicine { get; set; }

      
        public string unit { get; set; }

      
        public string quantily { get; set; }

        
        public string priceMedicine { get; set; }

       
        public string idMedicine { get; set; }
    }

    public class ResultMedicineKeDon
    {

        public string nameMedicine { get; set; }

        public string useMedicine { get; set; }

        public string quantilyMedicine { get; set; }

        public string unit { get; set; }


        public string quantily { get; set; }


        public string priceMedicine { get; set; }


        public string idMedicine { get; set; }
    }
}
