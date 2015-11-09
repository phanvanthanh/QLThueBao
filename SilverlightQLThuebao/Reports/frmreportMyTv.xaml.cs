using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Editors;
using System.Collections.ObjectModel;

namespace SilverlightQLThuebao
{
    public partial class frmreportMyTv : DXWindow
    {
        public string m_prBenA, m_prPN, m_prChucVu, m_prDC, m_prTK, m_prCMND, m_prNgayKN, m_prNgayTL, m_prMST, m_prSoHD, m_prHTTT, m_prSTT1, m_prDCLD1, m_prSDT1, m_prBGM1, m_prDVDT, m_prLoaiCap1, m_prGoiCuoc1, m_prACC1;
        ReportPreviewModel model = new ReportPreviewModel("../ReportService1.svc");
        public frmreportMyTv()
        {
            InitializeComponent();
             // model.ReportName = "SilverlightQLThuebao.Web." +report;
            model.ReportName = "SilverlightQLThuebao.Web.Rpthdmytv";
           // MessageBox.Show(prPN);
            model.AutoShowParametersPanel = false;
            documentPreview1.Model = model;
            model.RequestDefaultParameterValues += new EventHandler(model_RequestDefaultParameterValues);
            model.CreateDocument();
        }

        void model_RequestDefaultParameterValues(object sender, EventArgs e)
        {
            model.Parameters["prBenA"].Value = m_prBenA;
            model.Parameters["prTenPN"].Value = m_prPN;
            model.Parameters["prChucVu"].Value = m_prChucVu;
            model.Parameters["prDC"].Value = m_prDC;
            model.Parameters["prTK"].Value = m_prTK;
            model.Parameters["prCMND"].Value = m_prCMND;
            model.Parameters["prNgayKN"].Value = m_prNgayKN;
            model.Parameters["prNgayTL"].Value = m_prNgayTL;
            model.Parameters["prMST"].Value = m_prMST;
            model.Parameters["prSoHD"].Value = m_prSoHD;
            model.Parameters["prHTTT"].Value = m_prHTTT;
            model.Parameters["prSTT1"].Value = m_prSTT1;
            model.Parameters["prDCLD1"].Value = m_prDCLD1;
            model.Parameters["prSDT1"].Value = m_prSDT1;
            model.Parameters["prBGM1"].Value = m_prBGM1;
            model.Parameters["prLoaiCap1"].Value = m_prLoaiCap1;
            model.Parameters["prGoiCuoc1"].Value = m_prGoiCuoc1;
            model.Parameters["prACC1"].Value = m_prACC1;
            model.Parameters["prDVDT"].Value = m_prDVDT;
            // model.CreateDocument(); 

        }
    }    
}
