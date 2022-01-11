using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham.Models
{
   public class AllInfor
    {

        //        {
        //  "status": 0,
        //  "msg": "string",
        //  "data": {
        //    "namePatient": "string",
        //    "yearOfBirth": 0,
        //    "address": "string",
        //    "sex": "string",
        //    "phone": "string",
        //    "identityCard": "string",
        //    "job": "string",
        //    "timeStampPaid": 0,
        //    "service": "string",
        //    "priceService": 0,
        //    "priceSchedule": 0,
        //    "timeStampSchedule": "string",
        //    "namePrescription": "string",
        //    "medicine": [
        //      {
        //        "nameMedicine": "string",
        //        "quantity": 0,
        //        "priceMedicine": 0,
        //        "totalPrice": 0
        //      }
        //    ]
        //  }
        //}
        public class DataRs 
        {
            public string status { get; set; }
            public string msg { get; set; }
            public Results data { get; set; }
        }
        public class Results
        {
            public List<ResultMedicineTT> medicine { get; set; }
        }

        public class ResultMedicineTT
        {

            public string nameMedicine { get; set; }
            public string useMedicine { get; set; }
            public string unit { get; set; }
            public string quantity { get; set; }
            public string priceMedicine { get; set; }
            public string totalPrice { get; set; }
            public string QuantilyMedicine { get; set; }
        }
    }
}
