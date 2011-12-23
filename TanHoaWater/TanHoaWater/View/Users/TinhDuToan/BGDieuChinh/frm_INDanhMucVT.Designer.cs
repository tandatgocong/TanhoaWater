namespace TanHoaWater.View.Users.TinhDuToan.BGDieuChinh
{
    partial class frm_INDanhMucVT
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet = new TanHoaWater.DataSet();
            this.bGDCCHITIETBGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bGDC_CHITIETBGTableAdapter = new TanHoaWater.DataSetTableAdapters.BGDC_CHITIETBGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bGDCCHITIETBGBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.bGDCCHITIETBGBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TanHoaWater.View.Users.TinhDuToan.BGDieuChinh.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(951, 516);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bGDCCHITIETBGBindingSource
            // 
            this.bGDCCHITIETBGBindingSource.DataMember = "BGDC_CHITIETBG";
            this.bGDCCHITIETBGBindingSource.DataSource = this.dataSet;
            // 
            // bGDC_CHITIETBGTableAdapter
            // 
            this.bGDC_CHITIETBGTableAdapter.ClearBeforeFill = true;
            // 
            // frm_INDanhMucVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 516);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_INDanhMucVT";
            this.Text = "frm_INDanhMucVT";
            this.Load += new System.EventHandler(this.frm_INDanhMucVT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bGDCCHITIETBGBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource bGDCCHITIETBGBindingSource;
        private DataSetTableAdapters.BGDC_CHITIETBGTableAdapter bGDC_CHITIETBGTableAdapter;


    }
}