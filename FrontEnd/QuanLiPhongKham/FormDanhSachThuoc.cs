
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
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongKham
{
    public partial class FormDanhSachThuoc : Form
    {
        public FormDanhSachThuoc()
        {
            InitializeComponent();
        }
        #region - Hàm sử lý gọi api -

        public void LoadMdedicine()
        {
            try
            {
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] data = encoder.GetBytes("");
                HttpWebRequest request = WebRequest.Create("http://localhost/data/api/Medicine/get-List-Medicine") as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                request.Expect = "application/json";
                request.GetRequestStream().Write(data, 0, data.Length);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resultReq_ medi = new resultReq_();
                medi = Inventec.WCF.JsonConvert.JsonConvert.Deserialize<resultReq_>(responseString);
                gcMedicine.BeginUpdate();
                gcMedicine.DataSource = medi.data;
                gcMedicine.EndUpdate();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public void create(Medicine data_)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data_, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/Medicine/create-Medicine";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                if (result.Contains("thành công"))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm thuốc thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    LoadMdedicine();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm thuốc thất bại", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public void createupdate(Medicine data_)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data_, Formatting.Indented);
                File.WriteAllText("utf8.json", json, Encoding.UTF8);
                File.WriteAllText("default.json", json, Encoding.Default);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost/data/api/Medicine/update-Medicine";
                var client = new HttpClient();
                var response = client.PostAsync(url, data).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                if (result.Contains("thành công"))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Sửa thuốc thành công", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    LoadMdedicine();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Sửa thuốc thất bại", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        #endregion
        private void FormDanhSachThuoc_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMdedicine();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var data = (ResultMedicine)gvMedicine.GetFocusedRow();
                if (data != null)
                {
                    string url = "http://localhost/data/api/Medicine/delete-Medicine";
                    WebClient wc = new WebClient();
                    wc.QueryString.Add("id", data.idMedicine);
                    var datawc = wc.UploadValues(url, "POST", wc.QueryString);
                    var responseString = UnicodeEncoding.UTF8.GetString(datawc);
                }
            }
            catch (Exception ex)
            {

                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = new Guid();
                Medicine medi = new Medicine();
                medi.idMedicine = id.ToString();
                medi.nameMedicine = txtNameMedicine.Text;
                medi.priceMedicine = txtPriceMedicine.Text;
                medi.quantily = txtQuantily.Text;
                medi.unit = txtUnit.Text;
                medi.useMedicine = txtUseMedicine.Text;
                create(medi);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var data = (ResultMedicine)gvMedicine.GetFocusedRow();
                if (data != null)
                {
                    Medicine medi = new Medicine();
                    medi.nameMedicine = txtNameMedicine.Text;
                    medi.priceMedicine = txtPriceMedicine.Text;
                    medi.quantily = txtQuantily.Text;
                    medi.unit = txtUnit.Text;
                    medi.useMedicine = txtUseMedicine.Text;
                    medi.idMedicine = data.idMedicine;
                    createupdate(medi);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void gvMedicine_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                var data = (ResultMedicine)gvMedicine.GetFocusedRow();
                if (data != null)
                {

                    txtNameMedicine.Text = data.nameMedicine;
                    txtPriceMedicine.Text = data.priceMedicine;
                    txtQuantily.Text = data.quantily;
                    txtUnit.Text = data.unit;
                    txtUseMedicine.Text = data.useMedicine;
                    data.idMedicine = data.idMedicine;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
