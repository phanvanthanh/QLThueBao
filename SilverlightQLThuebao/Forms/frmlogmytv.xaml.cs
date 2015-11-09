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
    public partial class frmlogmytv : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();   
        public int rowN, rowH, n, m, n_records;
        public frmlogmytv()
        {
            InitializeComponent();          
           // Loaded+=new RoutedEventHandler(frmfmstonghop_Loaded);
            if (App.admin)
                cmdXoa.IsEnabled = true;
            else
                cmdXoa.IsEnabled = false;
           
        }
        void frmfmstonghop_Loaded(object sender, RoutedEventArgs e)
        {
            Tim();
        }

        private void Tim()
        {
            LoadOperation<mytv_log> LoadOp;            
            grid.ShowLoadingPanel = true;
            string chuoi;
            chuoi = this.txttim.Text == null ? "" : this.txttim.Text.Trim().ToUpper();
            EntityQuery<mytv_log> Query = dstb.GetMytv_logQuery();
            LoadOp = dstb.Load(Query.Where(p => p.user_name.Trim() == chuoi).OrderBy(p=>p.thoi_gian), dien_dl, null);
           
        }

        private void dien_dl(LoadOperation<mytv_log> lo)
        {
            grid.ItemsSource = lo.Entities;           
            grid.ShowLoadingPanel = false;
        }
    
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            Tim();
        }
    
        private void cmdXoa_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            frmxoalog frmxoa = new frmxoalog(0);
            frmxoa.Show();
        }    


        private void grid_GroupRowExpanding(object sender, DevExpress.Xpf.Grid.RowAllowEventArgs e)
        {
            this.grid.ShowLoadingPanel = true;
        }

        private void grid_GroupRowExpanded(object sender, DevExpress.Xpf.Grid.RowEventArgs e)
        {
            this.grid.ShowLoadingPanel = false;
        }

        private void chkall_Checked(object sender, RoutedEventArgs e)
        {
            txttim.IsEnabled = false;
        }

        private void chkall_Unchecked(object sender, RoutedEventArgs e)
        {
            txttim.IsEnabled = true;
        }
    }
}

