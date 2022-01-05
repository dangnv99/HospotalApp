namespace QuanLiPhongKham
{
    partial class FormDanhSachThuoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDanhSachThuoc));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtUseMedicine = new DevExpress.XtraEditors.MemoEdit();
            this.txtPriceMedicine = new DevExpress.XtraEditors.TextEdit();
            this.txtQuantily = new DevExpress.XtraEditors.TextEdit();
            this.txtNameMedicine = new DevExpress.XtraEditors.TextEdit();
            this.txtUnit = new DevExpress.XtraEditors.TextEdit();
            this.gcMedicine = new DevExpress.XtraGrid.GridControl();
            this.gvMedicine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUseMedicine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceMedicine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantily.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameMedicine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnUpdate);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.btnAdd);
            this.layoutControl1.Controls.Add(this.txtUseMedicine);
            this.layoutControl1.Controls.Add(this.txtPriceMedicine);
            this.layoutControl1.Controls.Add(this.txtQuantily);
            this.layoutControl1.Controls.Add(this.txtNameMedicine);
            this.layoutControl1.Controls.Add(this.txtUnit);
            this.layoutControl1.Controls.Add(this.gcMedicine);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1120, 641);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(849, 300);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(126, 22);
            this.btnUpdate.StyleController = this.layoutControl1;
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(979, 300);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(129, 22);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(718, 300);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(127, 22);
            this.btnAdd.StyleController = this.layoutControl1;
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtUseMedicine
            // 
            this.txtUseMedicine.Location = new System.Drawing.Point(793, 60);
            this.txtUseMedicine.Name = "txtUseMedicine";
            this.txtUseMedicine.Size = new System.Drawing.Size(315, 188);
            this.txtUseMedicine.StyleController = this.layoutControl1;
            this.txtUseMedicine.TabIndex = 10;
            // 
            // txtPriceMedicine
            // 
            this.txtPriceMedicine.Location = new System.Drawing.Point(793, 276);
            this.txtPriceMedicine.Name = "txtPriceMedicine";
            this.txtPriceMedicine.Size = new System.Drawing.Size(315, 20);
            this.txtPriceMedicine.StyleController = this.layoutControl1;
            this.txtPriceMedicine.TabIndex = 9;
            // 
            // txtQuantily
            // 
            this.txtQuantily.Location = new System.Drawing.Point(793, 252);
            this.txtQuantily.Name = "txtQuantily";
            this.txtQuantily.Size = new System.Drawing.Size(315, 20);
            this.txtQuantily.StyleController = this.layoutControl1;
            this.txtQuantily.TabIndex = 8;
            // 
            // txtNameMedicine
            // 
            this.txtNameMedicine.Location = new System.Drawing.Point(793, 36);
            this.txtNameMedicine.Name = "txtNameMedicine";
            this.txtNameMedicine.Size = new System.Drawing.Size(315, 20);
            this.txtNameMedicine.StyleController = this.layoutControl1;
            this.txtNameMedicine.TabIndex = 6;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(793, 12);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(315, 20);
            this.txtUnit.StyleController = this.layoutControl1;
            this.txtUnit.TabIndex = 5;
            // 
            // gcMedicine
            // 
            this.gcMedicine.Location = new System.Drawing.Point(12, 12);
            this.gcMedicine.MainView = this.gvMedicine;
            this.gcMedicine.Name = "gcMedicine";
            this.gcMedicine.Size = new System.Drawing.Size(702, 617);
            this.gcMedicine.TabIndex = 4;
            this.gcMedicine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMedicine});
            // 
            // gvMedicine
            // 
            this.gvMedicine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvMedicine.GridControl = this.gcMedicine;
            this.gvMedicine.Name = "gvMedicine";
            this.gvMedicine.OptionsView.ShowGroupPanel = false;
            this.gvMedicine.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvMedicine_RowCellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã thuốc";
            this.gridColumn1.FieldName = "unit";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên thuốc";
            this.gridColumn2.FieldName = "nameMedicine";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Cách sử dụng";
            this.gridColumn3.FieldName = "useMedicine";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Đơn vị  tính";
            this.gridColumn4.FieldName = "quantily";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Đơn giá";
            this.gridColumn5.FieldName = "priceMedicine";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1120, 641);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcMedicine;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(706, 621);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtUnit;
            this.layoutControlItem2.Location = new System.Drawing.Point(706, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(394, 24);
            this.layoutControlItem2.Text = "Mã thuốc:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(70, 20);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtNameMedicine;
            this.layoutControlItem3.Location = new System.Drawing.Point(706, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(394, 24);
            this.layoutControlItem3.Text = "Tên thuốc:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(70, 20);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtQuantily;
            this.layoutControlItem5.Location = new System.Drawing.Point(706, 240);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(394, 24);
            this.layoutControlItem5.Text = "Đơn vi tính:";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(70, 20);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtPriceMedicine;
            this.layoutControlItem6.Location = new System.Drawing.Point(706, 264);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(394, 24);
            this.layoutControlItem6.Text = "Đơn giá:";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(70, 20);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtUseMedicine;
            this.layoutControlItem4.Location = new System.Drawing.Point(706, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(394, 192);
            this.layoutControlItem4.Text = "Cách sử dụng:";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(70, 20);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnAdd;
            this.layoutControlItem7.Location = new System.Drawing.Point(706, 288);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(131, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnDelete;
            this.layoutControlItem8.Location = new System.Drawing.Point(967, 288);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(133, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnUpdate;
            this.layoutControlItem9.Location = new System.Drawing.Point(837, 288);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(130, 26);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(706, 314);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(394, 307);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FormDanhSachThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 641);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDanhSachThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách kho thuốc";
            this.Load += new System.EventHandler(this.FormDanhSachThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUseMedicine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceMedicine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantily.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameMedicine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.MemoEdit txtUseMedicine;
        private DevExpress.XtraEditors.TextEdit txtPriceMedicine;
        private DevExpress.XtraEditors.TextEdit txtQuantily;
        private DevExpress.XtraEditors.TextEdit txtNameMedicine;
        private DevExpress.XtraEditors.TextEdit txtUnit;
        private DevExpress.XtraGrid.GridControl gcMedicine;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMedicine;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;

    }
}