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
    public partial class frmreport : DXWindow
    {
        public string m_prBenA, m_prChucVu, m_prCMND, m_prDiachi, m_prTK, m_prNH, m_prMST, m_prSoHD, m_prMkh, m_prSTT1, m_prLoaidv1, m_prDCLD1, m_prSDT1, m_prDVCT1, m_prGoicuoc1, m_prEmail, m_prdtlh, m_prso119;
        ReportPreviewModel model = new ReportPreviewModel("../ReportService1.svc");
        public frmreport(string report)
        {
            InitializeComponent();
           // model.ReportName = "SilverlightQLThuebao.Web." +report;
            model.ReportName = "SilverlightQLThuebao.Web."+ report;
           // MessageBox.Show(prPN);
            model.AutoShowParametersPanel = false;
            documentPreview1.Model = model;
            model.RequestDefaultParameterValues += new EventHandler(model_RequestDefaultParameterValues);
            model.CreateDocument();
        }

        void model_RequestDefaultParameterValues(object sender, EventArgs e)
        {
            model.Parameters["prBenA"].Value = m_prBenA;           
            model.Parameters["prChucVu"].Value = m_prChucVu;
            model.Parameters["prDiachi"].Value = m_prDiachi;            
            model.Parameters["prTK"].Value = m_prTK;
            model.Parameters["prNH"].Value = m_prNH;
            model.Parameters["prMST"].Value = m_prMST;
            model.Parameters["prCMND"].Value = m_prCMND;
            model.Parameters["prEmail"].Value = m_prEmail;
            model.Parameters["prMkh"].Value = m_prMkh;
            model.Parameters["prSoHD"].Value = m_prSoHD;
            model.Parameters["prSTT1"].Value = m_prSTT1;
            model.Parameters["prLoaidv1"].Value = m_prLoaidv1;
            model.Parameters["prDCLD1"].Value = m_prDCLD1;
            model.Parameters["prSDT1"].Value = m_prSDT1;
            model.Parameters["prDVCT1"].Value = m_prDVCT1;
            model.Parameters["prGoicuoc1"].Value = m_prGoicuoc1;
            model.Parameters["prdtlh"].Value = m_prdtlh;
            model.Parameters["prso119"].Value = m_prso119; 
            // model.CreateDocument(); 

        }
    }
}
