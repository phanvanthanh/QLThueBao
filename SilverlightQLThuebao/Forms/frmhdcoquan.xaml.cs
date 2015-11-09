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
    public partial class frmhdcoquan : ChildWindow
    {
        public frmhdcoquan()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtdaidien.Text.Trim() == "")
            {
                App.nguoidaidien = "";
                App.chucvu = "";
            }
            else
            {
                App.nguoidaidien = txtdaidien.Text.Trim();
                App.chucvu = txtchucvu.Text.Trim();
            }
            this.DialogResult = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {           
            this.DialogResult = false;           
        }
    }
}

