using Inventec.Common.Controls.EditorLoader;
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

namespace QuanLiPhongKham
{
    public partial class FormTiepDon : Form
    {
        public FormTiepDon()
        {
            InitializeComponent();
        }

        responServicve service_;
        static byte[] ImageBytes;
        public string imagepath;
        
        bool isCameraRunning = false;
        #region Hàm sử lí họi api
        public void call(UserCreat data_)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data_, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/User/Creat-User";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;

                var result = response.Content.ReadAsStringAsync().Result;
                if (result != null)
                {
                    resultReq rs = new resultReq();
                    rs = JsonConvert.DeserializeObject<resultReq>(result);
                    if (rs.msg.Contains("thành công"))
                    {
                        RequestUserRole role = new RequestUserRole();
                        role.roleId = "724d3d68-6dd4-4381-a8b7-771b807b5e54";
                        role.userId = rs.data;
                        var json_ = JsonConvert.SerializeObject(role, Formatting.Indented);
                        File.WriteAllText("utf8.json", json_, Encoding.UTF8);
                        File.WriteAllText("default.json", json_, Encoding.Default);
                        var data1 = new System.Net.Http.StringContent(json_, Encoding.UTF8, "application/json");
                        var url1 = "http://localhost/data/api/User/User-Role";
                        var client1 = new HttpClient();
                        var response1 = client1.PostAsync(url1, data1).Result;

                        CreatScheduleDangKy Schedule = new Models.CreatScheduleDangKy();
                        Schedule.doctorId = cboDoctor.EditValue.ToString();
                        Schedule.serviceId = cboService.EditValue.ToString();
                        Schedule.patientId = rs.data;
                        Schedule.dateTimeStamp = Convert.ToDateTime(txtDateLichKham.EditValue.ToString()).ToString("dd-MM-yyyy");
                        CreatSchedule(Schedule);
                       
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Thêm bệnh nhân thất bại", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }

                }
            }

            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void LoadService()
        {
            try
            {
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
                service_ = new responServicve();
                service_ = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<responServicve>(responseString);
                List<ColumnInfo> columnInfos = new List<ColumnInfo>();
                columnInfos.Add(new ColumnInfo("name", "", 100, 1));
                ControlEditorADO controlEditorADO = new ControlEditorADO("name", "id", columnInfos, false, 100);
                ControlEditorLoader.Load(cboService, service_.data, controlEditorADO);
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

        public void CreatSchedule(CreatScheduleDangKy Schedule)
        {

            try
            {
                var json = JsonConvert.SerializeObject(Schedule, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/Schedule/creat-shedule";   //https://localhost:44343/api/Schedule/creat-shedule //http://localhost/data/api/Schedule/creat-shedule
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;

                var result = response.Content.ReadAsStringAsync().Result;

                if (result != null)
                {
                    resultReq rs = new resultReq();
                    rs = JsonConvert.DeserializeObject<resultReq>(result);
                    if (rs.msg.Contains("thành công"))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Tiếp đón bệnh nhân thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }


        #endregion

        private void FormTiepDon_Load(object sender, EventArgs e)
        {
            try
            {
                LoadService();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
        private void btnTiepDon_Click(object sender, EventArgs e)
        {
            try
            {
                UserCreat creat = new UserCreat();
                creat.name = txtName.Text;
                creat.job = txtJob.Text;
                creat.phone = txtPhone.Text;

                if (chkNam.Checked == true)
                {
                    creat.sex = "Nam";
                }
                else
                {
                    creat.sex = "Nữ";
                }
                
                creat.address = txtAddress.Text;
                creat.identityCard = txtCMND.Text;
                creat.yearOfBirth = txtNamSinh.Text;
                creat.username = RandomString(8);
                creat.password = RandomString(8);
                if (ImageBytes != null && ImageBytes.Count() > 0)
                {
                    creat.avatar = Convert.ToBase64String(ImageBytes);
                }
               
                call(creat);

            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void cboService_EditValueChanged(object sender, EventArgs e)
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

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.AddExtension = true;
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pbPatient.Image = new Bitmap(openFileDialog.FileName);
                    //foreach (string fileName in openFileDialog.FileNames)
                    //{
                    ImageBytes = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                    imagepath = openFileDialog.FileName;

                    this.Refresh();
                    //}
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                pbPatient.Image = null;
                ImageBytes = null;
                this.Refresh();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }
    }
}
