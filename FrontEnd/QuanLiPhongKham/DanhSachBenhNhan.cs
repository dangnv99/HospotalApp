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
    public partial class DanhSachBenhNhan : Form
    {
        public DanhSachBenhNhan()
        {
            InitializeComponent();
        }
        responUserRole getrole;

        #region Hàm xử lý gọi api
        public void Getdata()
        {
            try
            {
                getrole = new responUserRole();
                getrole.code = "patient";
                var json = JsonConvert.SerializeObject(getrole, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/User/get-list-user-by-role";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                responUserRole getrole_ = new responUserRole();
                getrole_ = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<responUserRole>(result);
                gdPatient.DataSource = getrole_.data;

            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

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


                        DevExpress.XtraEditors.XtraMessageBox.Show("Thêm bệnh nhân thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
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
                        DevExpress.XtraEditors.XtraMessageBox.Show("Sửa bệnh nhân thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Sửa bệnh nhân thất bại", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
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
        #endregion

        private void DanhSachBenhNhan_Load(object sender, EventArgs e)
        {
            try
            {
                Getdata();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);                
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                UserCreat creat = new UserCreat();
                creat.name = txtName.Text;
                creat.job = txtjob.Text;
                creat.phone = txtPhone.Text;
                if (ChkNam.Checked == true)
                {
                    creat.sex ="Nam";
                }
                else
                {
                    creat.sex = "Nữ";    
                }
                creat.address = txtAddress.Text;
                creat.identityCard = txtCMND.Text;
                creat.yearOfBirth = txtDate.Text;
                creat.username = RandomString(8);
                creat.password = RandomString(8);
                call(creat);
                Getdata();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var data = (getUserlist)gvPatient.GetFocusedRow();
                UserCreat update = new UserCreat();
                update.id = data.id;
                update.name = txtName.Text;
                update.job = txtjob.Text;
                update.phone = txtPhone.Text;
                if (ChkNam.Checked == true)
                {
                    update.sex = "Nam";
                }
                else
                {
                    update.sex = "Nữ";
                }
                update.address = txtAddress.Text;
                update.identityCard = txtCMND.Text;
                update.yearOfBirth = txtDate.Text;
               // update.avatar = 
                callupate(update);
                Getdata();
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
                var data = (getUserlist)gvPatient.GetFocusedRow();
                if (data != null)
                {
                    string url = "http://localhost/data/api/User/Delete-User";
                    WebClient wc = new WebClient();
                    wc.QueryString.Add("id", data.id);
                    var datawc = wc.UploadValues(url, "POST", wc.QueryString);
                    var responseString = UnicodeEncoding.UTF8.GetString(datawc);
                    Getdata();
                }
            }
            catch (Exception ex)
            {

                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gvPatient_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                try
                {
                    var data = (getUserlist)gvPatient.GetFocusedRow();
                    if (data != null)
                    {
                        txtName.Text = data.name;
                        txtjob.Text = data.job;
                        txtPhone.Text = data.phone;
                        if (data.sex == "Nam")
                        {
                            ChkNam.Checked = true;
                            ChkNu.Checked = false;
                        }
                        else
                        {
                            ChkNam.Checked = false;
                            ChkNu.Checked = true;
                        }
                        txtAddress.Text = data.address;
                        txtCMND.Text = data.identityCard;
                        txtDate.Text = data.yearOfBirth;
                        if (data.avatar != null)
                        {
                            pbPatient.Image = Base64ToImage(data.avatar);
                        }
                        else 
                        {
                            pbPatient.Image = null;
                            pbPatient.Image = global::QuanLiPhongKham.Properties.Resources.chu_the;
                        }
                      
                    }
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

        }

        private void txtName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ChkNam.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void ChkNam_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ChkNu.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void ChkNu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDate.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtDate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPhone.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtPhone_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddress.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCMND.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtjob_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtjob.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtCMND_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtjob.Focus();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
