using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Data;
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
    public partial class frmtkptgphone : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        public frmtkptgphone()
        {
            InitializeComponent();
            dngaybd.EditValue = App.Current_d.AddDays(-10);
            dngaykt.EditValue = App.Current_d;
        }

        void dien_dl()
        {
            DateTime ngaybd, ngaykt;
            gridControl1.ShowLoadingPanel = true;               
            this.gridControl1.ItemsSource = new DSCatmo(); // lay bang rong dua vao
            tableView1.DeleteRow(0);
            ngaybd = this.dngaybd.DateTime;
            ngaykt = this.dngaykt.DateTime;
            if (dngaybd.Text.Trim() == "" || dngaykt.Text.Trim() == "")
                MessageBox.Show("Chưa chọn ngày cần xem !");
            else
            {
                if (chkngayhd.IsChecked == true)
                {
                    EntityQuery<Gphone> Query = dstb.GetGphonesQuery();
                    LoadOperation<Gphone> LoadOp = dstb.Load(Query.Where(p => p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt && App.nhomtd.Contains(p.ma_huyen)).OrderBy(p => p.ma_huyen).OrderBy(p => p.ngay_hd), LoadOp_Complete, null);
                }
                else
                {
                    EntityQuery<Gphone> Query = dstb.GetGphonesQuery();
                    LoadOperation<Gphone> LoadOp = dstb.Load(Query.Where(p => p.ngay_ld >= ngaybd && p.ngay_ld <= ngaykt && App.nhomtd.Contains(p.ma_huyen)).OrderBy(p => p.ma_huyen).OrderBy(p => p.ngay_hd), LoadOp_Complete, null);
                }
            }
        }


        void LoadOp_Complete(LoadOperation<Gphone> lo)
        {          
            if (lo.Entities.Count() > 0)
            {
                gridControl1.ItemsSource = lo.Entities;               
            }
            gridControl1.ShowLoadingPanel = false;
            this.Title = "Thống kê phát triển điện thoại Gphone - " + lo.Entities.Count().ToString();
        }

    
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            dien_dl();
        }   
    }
}
