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
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;

namespace SilverlightQLThuebao
{
    public partial class frmdstam : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        public frmdstam()
        {
            InitializeComponent();            
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            prgb.Visibility = Visibility;
            InvokeOperation<System.Nullable<int>> p = dstb.CreateTableTemp();
            p.Completed += new EventHandler(Completed);
        }

        void Completed(object sende, EventArgs e)
        {
            this.DialogResult = false;
            MessageBox.Show("Đã tạo file tính cước xong !");            
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
     
    }
}

