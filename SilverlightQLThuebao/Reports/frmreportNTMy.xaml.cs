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
    public partial class frmreportNTMy : DXWindow
    {
        public string m_prsoHD, m_prngayHD, m_prtenKH, m_prmaKH, m_prnhanvien, m_prDCLD1, m_prSDT1, m_prsoBGM, m_prgoiCuoc, m_prtgHM, m_prkhac, m_prloaiCap;
        ReportPreviewModel model = new ReportPreviewModel("../ReportService1.svc");
        public frmreportNTMy(string report)
        {
            InitializeComponent();
           // model.ReportName = "SilverlightQLThuebao.Web." +report;
            model.ReportName = "SilverlightQLThuebao.Web." + report;
           // MessageBox.Show(prPN);
            model.AutoShowParametersPanel = false;
            documentPreview1.Model = model;
            model.RequestDefaultParameterValues += new EventHandler(model_RequestDefaultParameterValues);
            model.CreateDocument();
        }

        void model_RequestDefaultParameterValues(object sender, EventArgs e)
        {
            model.Parameters["prsoHD"].Value = m_prsoHD;
            model.Parameters["prngayHD"].Value = m_prngayHD;
            model.Parameters["prtenkh"].Value = m_prtenKH;
            model.Parameters["prmaKH"].Value = m_prmaKH;
            model.Parameters["prTTVT"].Value = "Đại diện bên B: " + Converter.TCVN3ToUnicode(App.ten_huyen);
            model.Parameters["prnv"].Value =  Converter.TCVN3ToUnicode(m_prnhanvien);
            model.Parameters["prdcld"].Value = m_prDCLD1;
            model.Parameters["prsoDT"].Value = m_prSDT1;
            model.Parameters["prsoBGM"].Value = m_prsoBGM;
            model.Parameters["prgoiCuoc"].Value = m_prgoiCuoc;
            model.Parameters["prloaiCap"].Value = Converter.TCVN3ToUnicode(m_prloaiCap);
            model.Parameters["prtgHM"].Value = m_prtgHM;
            model.Parameters["prKhac"].Value = m_prkhac;  
            // model.CreateDocument(); 

        }
    }
}
