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
    public partial class frmkhdoanhnghiep : DXWindow
    {
        public frmkhdoanhnghiep()
        {
            InitializeComponent();
            dngaybd.Visibility = Visibility.Collapsed;
            textBlock2.Text = "";
            textBlock1.Text = "Tháng :";
            dngaykt.DisplayFormatString = "MM";
            dngaykt.Mask = "MM";

            dngaybd.DateTime = App.Current_d;
            dngaykt.DateTime = App.Current_d;
            dien_dl();
        }
        void dien_dl()
        {
            int m_kt;            
            m_kt = dngaykt.DateTime.Month;            
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            EntityQuery<khachhangDN> Query = db.GetKhachhangDNQuery();
            if (checkEdit1.IsChecked == true)
            {
                LoadOperation<khachhangDN> Load = db.Load(Query.Where(p =>p.ngay_tl.Value.Month == m_kt).OrderBy(p => p.ngay_tl), lo =>
                {
                    gridControl1.ItemsSource = lo.Entities;
                    this.Title = "Khách hàng là doanh nghiệp : " + lo.Entities.Count().ToString();
                }, true);
            }
            else
            {
                LoadOperation<khachhangDN> Load = db.Load(Query.Where(p => p.ngay_tl.Value >= dngaybd.DateTime && p.ngay_tl.Value <= dngaykt.DateTime).OrderBy(p => p.ngay_tl), lo =>
                {
                    gridControl1.ItemsSource = lo.Entities;
                    this.Title = "Khách hàng là doanh nghiệp : " + lo.Entities.Count().ToString();
                }, true);
            }
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            dien_dl();
        }

        private void checkEdit1_Checked(object sender, RoutedEventArgs e)
        {
            dngaybd.Visibility = Visibility.Collapsed;
            textBlock2.Text = "";
            textBlock1.Text = "Tháng :";
            dngaykt.DisplayFormatString = "MM";
            dngaykt.Mask = "MM";
        }

        private void checkEdit1_Unchecked(object sender, RoutedEventArgs e)
        {
            dngaybd.Visibility = Visibility.Visible;
            textBlock2.Text = "Từ ngày";
            textBlock1.Text = "Đến ngày";
            dngaybd.DisplayFormatString = "dd/MM/yyyy";
            dngaybd.Mask = "dd/MM/yyyy";
            dngaykt.DisplayFormatString = "dd/MM/yyyy";
            dngaykt.Mask = "dd/MM/yyyy";
        }
    }
}
