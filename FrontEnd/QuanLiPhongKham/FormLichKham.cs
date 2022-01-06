using System;
using Newtonsoft.Json;
using QuanLiPhongKham.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList.Data;
using System.Threading;
using Inventec.Common.Controls.EditorLoader;


namespace QuanLiPhongKham
{
    public partial class FormLichKham : Form
    {
        public FormLichKham()
        {
            InitializeComponent();
        }

        #region
        responUserRole getrolePatient;
        responUserRole getroleDoctor;
        ResultFetListSchedule Schedule;
        responServicve service;

        private void thread()
        {
            try
            {
                Thread thread = new Thread(() =>
                {
                    LoadSchedule();
                });
                thread.Start();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        private void thread1()
        {
            try
            {
                bool fs = false;
                Thread thread = new Thread(() =>
                {
                    GetdataPatient();
                });
                thread.Start();

                Thread thread1 = new Thread(() =>
                {
                    LoadService();
                });
                thread1.Start();
                Thread thread2 = new Thread(() =>
                {
                    GetdataDoctor();
                });
                thread2.Start();
                //Thread thread3 = new Thread(() =>
                //{
                //    LoadSchedule();
                //});

                //if (thread.IsAlive == true && thread1.IsAlive == true && thread2.IsAlive == true )
                //{
                //    thread3.Start();
                //}
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        public void Cancle(CancleShuedule data_)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data_, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/Schedule/cancel-schedule-patient";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                if (result.Contains("thành công"))
                {
                    thread();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Hủy lịch thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);

                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Hủy lịch thất bại", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public void GetdataPatient()
        {
            try
            {
                responUserRole getrole = new responUserRole();
                getrole.code = "patient";
                var json = JsonConvert.SerializeObject(getrole, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/User/get-list-user-by-role";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                getrolePatient = new responUserRole();
                getrolePatient = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<responUserRole>(result);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public void GetdataDoctor()
        {
            try
            {
                responUserRole getrole = new responUserRole();
                getrole.code = "doctor";
                var json = JsonConvert.SerializeObject(getrole, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/User/get-list-user-by-role";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                getroleDoctor = new responUserRole();
                getroleDoctor = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<responUserRole>(result);

            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public void LoadSchedule()
        {
            try
            {

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] data = encoder.GetBytes(""); // a json object, or xml, whatever...
                HttpWebRequest request = WebRequest.Create("http://localhost/data/api/Schedule/GetList-schedule") as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                request.Expect = "application/json";
                request.GetRequestStream().Write(data, 0, data.Length);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Schedule = new ResultFetListSchedule();
                Schedule = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<ResultFetListSchedule>(responseString);
                gcSchedule.DataSource = Schedule.data;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        public void LoadService()
        {
            try
            {
                //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("http://localhost/data/api/Service/get-list-Service");
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] data = encoder.GetBytes(""); // a json object, or xml, whatever...
                HttpWebRequest request = WebRequest.Create("http://localhost/data/api/Service/get-list-Service") as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                request.Expect = "application/json";
                request.GetRequestStream().Write(data, 0, data.Length);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                service = new responServicve();
                service = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<responServicve>(responseString);
                List<ColumnInfo> columnInfos = new List<ColumnInfo>();
                columnInfos.Add(new ColumnInfo("name", "", 100, 1));
                ControlEditorADO controlEditorADO = new ControlEditorADO("name", "id", columnInfos, false, 100);
                ControlEditorLoader.Load(cboService, service.data, controlEditorADO);

            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        public void LoadDoctor(GetDoctorService doctorservice)
        {
            try
            {
                responDoctorService getDS = new responDoctorService();
                getDS.id = cboService.EditValue.ToString();
                var json = JsonConvert.SerializeObject(getDS, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/User/get-list-doctor-service";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                responDoctorService getrole_ = new responDoctorService();
                getrole_ = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<responDoctorService>(result);

                List<ColumnInfo> columnInfos = new List<ColumnInfo>();
                columnInfos.Add(new ColumnInfo("nameDoctor", "", 100, 1));
                ControlEditorADO controlEditorADO = new ControlEditorADO("nameDoctor", "id", columnInfos, false, 100);
                ControlEditorLoader.Load(cboDoctor, getrole_.data, controlEditorADO);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }
        #endregion

        private void FormLichKham_Load(object sender, EventArgs e)
        {
            try
            {
                //thread1();
                GetdataPatient();
                LoadService();
                GetdataDoctor();
                LoadSchedule();
                // thread();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gvSchedule_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

            try
            {
                if (e.IsGetData && e.Column.UnboundType != DevExpress.Data.UnboundColumnType.Bound)
                {
                    var row = (CreatSchedule)((IList)((BaseView)sender).DataSource)[e.ListSourceRowIndex];
                    if (e.Column.FieldName == "PatientName")
                    {
                        e.Value = getrolePatient.data.FirstOrDefault(o => o.id == row.patientId).name;
                    }
                    if (e.Column.FieldName == "DoctorName")
                    {
                        e.Value = getroleDoctor.data.FirstOrDefault(o => o.id == row.doctorId).name;
                    }
                    if (e.Column.FieldName == "ScheduleService")
                    {
                        e.Value = service.data.FirstOrDefault(o => o.id == row.serviceId).name;
                    }
                    if (e.Column.FieldName == "DateSchedule")
                    {
                        e.Value = row.dateTimeStamp;
                    }
                    if (e.Column.FieldName == "statusSTR")
                    {
                        if (row.status == "0")
                        {
                            e.Value = "Chưa khám";
                        }
                        if (row.status == "1")
                        {
                            e.Value = "Đã khám";
                        }
                        if (row.status == "2")
                        {
                            e.Value = "Đã thanh toán";
                        }
                        if (row.status == "3")
                        {
                            e.Value = "Đã hủy";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        private void gvSchedule_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.RowHandle >= 0)
                {

                    var row = (CreatSchedule)((IList)((BaseView)sender).DataSource)[e.RowHandle];
                    if (e.Column.FieldName == "statusSTR")
                    {
                        if (row.status == "0")
                        {
                            e.Appearance.ForeColor = Color.Red;
                        }
                        if (row.status == "1")
                        {
                            e.Appearance.ForeColor = Color.Green;
                        }
                        if (row.status == "2")
                        {
                            e.Appearance.ForeColor = Color.Yellow;
                        }
                        if (row.status == "3")
                        {
                            e.Appearance.ForeColor = Color.Violet;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        private void gvSchedule_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            try
            {
                var row = (CreatSchedule)gvSchedule.GetFocusedRow();
                if (row != null)
                {

                    txtPatient.Text = getrolePatient.data.FirstOrDefault(o => o.id == row.patientId).name;
                    //txtDoctor.Text = getroleDoctor.data.FirstOrDefault(o => o.id == row.doctorId).name;
                    //txtService.Text = service.data.FirstOrDefault(o => o.id == row.serviceId).name;
                    cboDoctor.EditValue = row.doctorId;
                    cboService.EditValue = row.serviceId;

                    txtLichKham.EditValue = row.dateTimeStamp;
                    if (row.status == "0")
                    {
                        txtStatus.Text = "Chưa khám";
                        txtStatus.ForeColor = Color.Red;
                    }
                    if (row.status == "1")
                    {
                        txtStatus.Text = "Đã khám";
                        txtStatus.ForeColor = Color.Green;
                    }
                    if (row.status == "2")
                    {
                        txtStatus.Text = "Đã thanh toán";
                        txtStatus.ForeColor = Color.Yellow;
                    }
                    if (row.status == "3")
                    {
                        txtStatus.Text = "Đã hủy";
                        txtStatus.ForeColor = Color.Violet;
                    }
                }
            }

            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {

            try
            {
                var data = (CreatSchedule)gvSchedule.GetFocusedRow();
                if (data != null)
                {
                    CancleShuedule cs = new CancleShuedule();
                    cs.scheduleID = data.id;
                    Cancle(cs);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                var data = (CreatSchedule)gvSchedule.GetFocusedRow();
                if (data != null)
                {
                    string url = "http://localhost/data/api/Schedule/delete-schedule";
                    WebClient wc = new WebClient();
                    wc.QueryString.Add("Id", data.id);
                    //wc.QueryString.Add("name", txtName.Text);
                    //wc.QueryString.Add("price", txtprice.Text);
                    var data_ = wc.UploadValues(url, "POST", wc.QueryString);
                    var responseString = UnicodeEncoding.UTF8.GetString(data_);
                    thread();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Xóa thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    //  LoadSchedule();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {

            try
            {

                FormTiepDon fr = new FormTiepDon();
                fr.ShowDialog();
                thread();

            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        private void cboService_EditValueChanged(object sender, System.EventArgs e)
        {

            try
            {
                GetDoctorService doctorservice = new GetDoctorService();
                doctorservice.id = cboService.EditValue.ToString();

                LoadDoctor(doctorservice);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            try
            {
                var row = (CreatSchedule)gvSchedule.GetFocusedRow();
                if (row != null)
                {
                    string url = "http://localhost/data/api/Schedule/update-schedule";  //https://localhost:44343/api/Schedule/update-schedule //http://localhost/data/api/Schedule/update-schedule
                    WebClient wc = new WebClient();
                    wc.QueryString.Add("Id", row.id);
                    wc.QueryString.Add("DoctorId", cboDoctor.EditValue.ToString());
                    wc.QueryString.Add("PatientId", row.patientId);
                    wc.QueryString.Add("DateTimeStamp", Convert.ToDateTime(txtLichKham.EditValue.ToString()).ToString("dd-MM-yyyy"));
                    wc.QueryString.Add("Status", "0");
                    wc.QueryString.Add("ServiceId", cboService.EditValue.ToString());
                    var data_ = wc.UploadValues(url, "POST", wc.QueryString);
                    var responseString = UnicodeEncoding.UTF8.GetString(data_);
                    //thread();
                    LoadSchedule();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }
    }
}
