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
    public partial class frmtest : ChildWindow
    {
        ReportPreviewModel model = new ReportPreviewModel("../ReportService1.svc");
        public frmtest()
        {
            InitializeComponent();
            model.ReportName = "SilverlightQLThuebao.Web.XtraReport1";
            model.AutoShowParametersPanel = false;
            documentPreview1.Model = model;
            // model.RequestDefaultParameterValues += new EventHandler(model_RequestDefaultParameterValues);
            model.CreateDocument();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

