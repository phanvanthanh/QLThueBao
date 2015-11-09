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

namespace SilverlightQLThuebao
{
    public partial class frmnhiemthucd : ChildWindow
    {
        public frmnhiemthucd()
        {
            InitializeComponent();
            dngayhm.EditValue = DateTime.Now; 
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
              if (txttennv.Text.Trim() == "")
            {
                App.nhanvienld = "";
                App.tghoamang = "";
                App.thongtinkhac = "";
            }
            else
            {
                App.nhanvienld = txttennv.Text.Trim();
                App.tghoamang = dngayhm.DateTime.Day.ToString().PadLeft(2, '0') + "/" + dngayhm.DateTime.Month.ToString().PadLeft(2, '0') + "/" + dngayhm.DateTime.Year.ToString() + " " + dngayhm.DateTime.ToShortTimeString();
                App.thongtinkhac = txtghichu.Text.Trim();
            }
            this.DialogResult = false;
        }
        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

