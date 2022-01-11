using QuanLiPhongKham.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongKham
{
    public partial class PayOnline : Form
    {
        string sotien;
        PictureBox image;
        CreatSchedule row;
        public PayOnline(string sotien_ , PictureBox image_, CreatSchedule row_)
        {
            this.sotien = sotien_;
            this.image = image_;
            this.row = row_;
            InitializeComponent();
        }

        private void PayOnline_Load(object sender, EventArgs e)
        {
            txtTT.Text = sotien + " VNĐ";
            pbTT.Image = image.Image;
        }

        private void pbTT_Click(object sender, EventArgs e)
        {
            // Cập nhật trạng thái lịch hẹn
            string url = "http://localhost/data/api/Schedule/update-schedule";  //https://localhost:44343/api/Schedule/update-schedule //http://localhost/data/api/Schedule/update-schedule
            WebClient wc = new WebClient();

            wc.QueryString.Add("DoctorId", row.doctorId);
            wc.QueryString.Add("PatientId", row.patientId);
            wc.QueryString.Add("DateTimeStamp", Convert.ToDateTime(row.dateTimeStamp.ToString()).ToString("dd-MM-yyyy"));
            wc.QueryString.Add("ServiceId", row.serviceId);
            wc.QueryString.Add("Id", row.id);
            wc.QueryString.Add("Status", "2");
            var data_ = wc.UploadValues(url, "POST", wc.QueryString);
            var responseString = UnicodeEncoding.UTF8.GetString(data_);
            if (responseString.Contains("thành công"))
            {

                DevExpress.XtraEditors.XtraMessageBox.Show("Thanh toán thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);

            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Thanh toán thất bại", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
            }
            this.Close();
        }
    }
}
