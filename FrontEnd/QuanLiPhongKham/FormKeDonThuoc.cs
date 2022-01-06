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
    public partial class FormKeDonThuoc : Form
    {
        public FormKeDonThuoc()
        {
            InitializeComponent();
        }


        #region --- Hàm xử lí gọi API ---
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

        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to base 64 string
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
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
                gcShedule.DataSource = Schedule.data;
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
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        public void callupate(UserCreat data_)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data_, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/User/Update-User";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;

                var result = response.Content.ReadAsStringAsync().Result;
                if (result != null)
                {
                    resultReq rs = new resultReq();
                    rs = JsonConvert.DeserializeObject<resultReq>(result);
                    if (rs.msg.Contains("thành công"))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Lưu thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Lưu thất bại thất bại", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        //public void LoadDoctor(GetDoctorService doctorservice)
        //{
        //    try
        //    {

        //        responDoctorService getDS = new responDoctorService();
        //        getDS.id = cboService.EditValue.ToString();
        //        var json = JsonConvert.SerializeObject(getDS, Formatting.Indented);
        //        File.WriteAllText("utf8.json", json, Encoding.UTF8);
        //        File.WriteAllText("default.json", json, Encoding.Default);
        //        var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
        //        var url = "http://localhost/data/api/User/get-list-doctor-service";
        //        var client = new HttpClient();
        //        var response = client.PostAsync(url, data).Result;
        //        string result = response.Content.ReadAsStringAsync().Result;
        //        responDoctorService getrole_ = new responDoctorService();
        //        getrole_ = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<responDoctorService>(result);

        //        List<ColumnInfo> columnInfos = new List<ColumnInfo>();
        //        columnInfos.Add(new ColumnInfo("nameDoctor", "", 100, 1));
        //        ControlEditorADO controlEditorADO = new ControlEditorADO("nameDoctor", "id", columnInfos, false, 100);
        //        ControlEditorLoader.Load(cboDoctor, getrole_.data, controlEditorADO);
        //    }
        //    catch (Exception ex)
        //    {
        //        Inventec.Common.Logging.LogSystem.Error(ex);
        //    }

        //}
        #endregion

        private void FormKeDonThuoc_Load(object sender, EventArgs e)
        {
            try
            {

                GetdataPatient();
                LoadService();
                GetdataDoctor();
                thread();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gvShedule_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
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

        private void gvShedule_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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

        private void gvShedule_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                var row = (CreatSchedule)gvShedule.GetFocusedRow();
                if (row != null)
                {
                    responUserRole getrolePatient_ = new responUserRole();
                    getrolePatient_.data = getrolePatient.data.Where(o => o.id == row.patientId).ToList();
                    txtName.Text = getrolePatient_.data.FirstOrDefault().name;
                    txtAdress.Text = getrolePatient_.data.FirstOrDefault().address;
                    txtPhone.Text = getrolePatient_.data.FirstOrDefault().phone;
                    txtJob.Text = getrolePatient_.data.FirstOrDefault().phone;
                    txtNote1.Text = getrolePatient_.data.FirstOrDefault().note1;
                    txtNote2.Text = getrolePatient_.data.FirstOrDefault().note2;
                    txtCMND.Text = getrolePatient_.data.FirstOrDefault().identityCard;
                    txtDateofborn.Text = getrolePatient_.data.FirstOrDefault().yearOfBirth;
                    //if (getrolePatient_.data.FirstOrDefault().avatar != null)
                    //{
                    //    pbPatient.Image = Base64ToImage(getrolePatient_.data.FirstOrDefault().avatar);
                    //}
                    //else
                    //{
                    //    pbPatient.Image = null;
                    //    pbPatient.Image = global::QuanLiPhongKham.Properties.Resources.chu_the;
                    //}
                    if (getrolePatient_.data.FirstOrDefault().sex.Contains("Nam"))
                    {
                        ChkNam.Checked = true;
                        chkNu.Checked = false;
                    }
                    else
                    {
                        ChkNam.Checked = false;
                        chkNu.Checked = true;
                    }
                }
            }

            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
