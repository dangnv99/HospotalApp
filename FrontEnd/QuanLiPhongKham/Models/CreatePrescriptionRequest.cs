using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongKham.Models
{
    public class CreatePrescriptionRequest
    {
        public string IdSchedule { get; set; }
        public string Name { get; set; }
        public string TimeStamp { get; set; }
        public string Code { get; set; }
        public List<PrescriptionMedicineModels> Medicines { get; set; }
    }
    public class PrescriptionMedicineModels
    {
        public string IdMedicine { get; set; }
        public int QuantilyMedicine { get; set; }
    }
}
