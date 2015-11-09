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
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;

namespace SilverlightQLThuebao
{
    public partial class frmtimint : DXWindow
    {
        public frmtimint()
        {
            InitializeComponent();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (txttim.Text.Trim() != "")
            {
                QLThuebaoDomainContext db = new QLThuebaoDomainContext();
                if (chkInt.IsChecked == true)
                {
                    EntityQuery<internet> Query = db.GetInternetsQuery();
                    LoadOperation<internet> Load = db.Load(Query.Where(p => p.user_name.Trim().Contains(txttim.Text.Trim())).OrderBy(p => p.ma_huyen), lo =>
                    {
                        gridInt.Visibility = Visibility.Visible;
                        gridmy.Visibility = Visibility.Collapsed;
                        gridInt.ItemsSource = lo.Entities;                      
                    }, null);
                }
                else
                {
                    EntityQuery<mytv> Query = db.GetMytvsQuery();
                    LoadOperation<mytv> Load = db.Load(Query.Where(p => p.user_name.Trim().Contains(txttim.Text.Trim())).OrderBy(p=>p.ma_huyen), lo =>
                    {
                        gridInt.Visibility = Visibility.Collapsed;
                        gridmy.Visibility = Visibility.Visible;
                        gridmy.ItemsSource = lo.Entities;                        
                    }, null);
                }
            }
        }

        private void chkInt_Checked(object sender, RoutedEventArgs e)
        {
            chkMy.IsChecked = false;
        }

        private void chkInt_Unchecked(object sender, RoutedEventArgs e)
        {
            chkMy.IsChecked = true;
        }

        private void chkMy_Checked(object sender, RoutedEventArgs e)
        {
            chkInt.IsChecked = false;
        }

        private void chkMy_Unchecked(object sender, RoutedEventArgs e)
        {
            chkInt.IsChecked = true;
        }
    }

}
