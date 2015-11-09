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
    public partial class frmtkkm : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<khmai> LoadOpkm;
        int rowkm = 0;
        public frmtkkm()
        {
            InitializeComponent();
            dbegin.Visibility = Visibility.Collapsed;
            dend.Visibility = Visibility.Collapsed;
            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;
            dbegin.EditValue = App.Current_d.AddDays(-3);
            dend.EditValue = App.Current_d;
            EntityQuery<khmai> Querykm = dstb.GetKhmaiQuery();
            LoadOpkm = dstb.Load(Querykm.Where(p=>p.ma_km !="0").OrderByDescending(t => t.ngay_bd), LoadOpTK_Complete, null);
          
        }

        void LoadOpTK_Complete(LoadOperation<khmai> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbkm.DisplayMember = ("ten_ct").Trim();
                this.cmbkm.ValueMember = "ma_km";
                this.cmbkm.ItemsSource = lo.Entities;
                rowkm = lo.Entities.Count();
            }
        }

        void dien_dl()
        {
            //string km= cmbkm.GetKeyValue(cmbkm.SelectedIndex).ToString().Trim();
            string km =  FunAndPro.GetSelectedKeyValue(cmbkm, rowkm);           
            if (km == "")
            {
                MessageBox.Show("Chưa chọn chương trình khuyến mãi hoặc loại thuê bao !");
                return;
            }

            if (rcodinh.IsChecked == true)
            {
                gridCodinh.Visibility =Visibility.Visible;
                gridGphone.Visibility = Visibility.Collapsed;
                gridmy.Visibility = Visibility.Collapsed;
                gridInt.Visibility = Visibility.Collapsed;
                gridCodinh.ShowLoadingPanel = true;  
                EntityQuery<ds_codinh> Query = dstb.GetDs_codinhQuery();
                LoadOperation<ds_codinh> LoadOp;
                if (chkFilter.IsChecked==true)
                    LoadOp = dstb.Load(Query.Where(p => km.Contains(p.ma_km.Trim()) && App.nhomtd.Contains(p.ma_huyen)).OrderBy(p => p.ngay_hd), LoadOpcd_Complete, null);         
                else
                    LoadOp = dstb.Load(Query.Where(p => km.Contains(p.ma_km.Trim()) && App.nhomtd.Contains(p.ma_huyen) && p.ngay_hd>=dbegin.DateTime && p.ngay_hd<=dend.DateTime).OrderBy(p => p.ngay_hd), LoadOpcd_Complete, null);         
            }

            if (rgphone.IsChecked == true)
            {
                gridCodinh.Visibility = Visibility.Collapsed;
                gridGphone.Visibility = Visibility.Visible;
                gridmy.Visibility = Visibility.Collapsed;
                gridInt.Visibility = Visibility.Collapsed;
                gridGphone.ShowLoadingPanel = true;
                LoadOperation<Gphone> LoadOp;
                EntityQuery<Gphone> Query = dstb.GetGphonesQuery();
                if (chkFilter.IsChecked==true)
                    LoadOp = dstb.Load(Query.Where(p => km.Contains(p.ma_km.Trim()) && App.nhomtd.Contains(p.ma_huyen)).OrderBy(p => p.ngay_hd), LoadOpgp_Complete, null);           
                else
                    LoadOp = dstb.Load(Query.Where(p => km.Contains(p.ma_km.Trim()) && App.nhomtd.Contains(p.ma_huyen) && p.ngay_hd >= dbegin.DateTime && p.ngay_hd <= dend.DateTime).OrderBy(p => p.ngay_hd), LoadOpgp_Complete, null);           
            }

            if (rmytv.IsChecked == true)
            {
                gridCodinh.Visibility = Visibility.Collapsed;
                gridGphone.Visibility = Visibility.Collapsed;
                gridmy.Visibility = Visibility.Visible;
                gridInt.Visibility = Visibility.Collapsed;
                gridGphone.ShowLoadingPanel = true;
                LoadOperation<mytv> LoadOp;
                EntityQuery<mytv> Query = dstb.GetMytvsQuery();
                if (chkFilter.IsChecked == true)
                    LoadOp = dstb.Load(Query.Where(p => km.Contains(p.ma_km.Trim()) && App.nhomtd.Contains(p.ma_huyen)).OrderBy(p => p.ngay_hd), LoadOpmy_Complete, null);             
                else
                    LoadOp = dstb.Load(Query.Where(p => km.Contains(p.ma_km.Trim()) && App.nhomtd.Contains(p.ma_huyen) && p.ngay_hd >= dbegin.DateTime && p.ngay_hd <= dend.DateTime).OrderBy(p => p.ngay_hd), LoadOpmy_Complete, null);             
            }

            if (rint.IsChecked == true)
            {
                gridCodinh.Visibility = Visibility.Collapsed;
                gridGphone.Visibility = Visibility.Collapsed;
                gridmy.Visibility = Visibility.Collapsed;
                gridInt.Visibility = Visibility.Visible;
                gridGphone.ShowLoadingPanel = true;
                LoadOperation<internet> LoadOp;
                EntityQuery<internet> Query = dstb.GetInternetsQuery();
                if (chkFilter.IsChecked == true)
                    LoadOp = dstb.Load(Query.Where(p => km.Contains(p.ma_km.Trim()) && p.ma_dv.Trim() == "ADSL" && App.nhomtd.Contains(p.ma_huyen)).OrderBy(p => p.ngay_hd), LoadOpint_Complete, null);
                else
                    LoadOp = dstb.Load(Query.Where(p => km.Contains(p.ma_km.Trim()) && p.ma_dv.Trim() == "ADSL" && App.nhomtd.Contains(p.ma_huyen) && p.ngay_hd >= dbegin.DateTime && p.ngay_hd <= dend.DateTime).OrderBy(p => p.ngay_hd), LoadOpint_Complete, null);
                    
            }

            if (rfib.IsChecked == true)
            {
                gridCodinh.Visibility = Visibility.Collapsed;
                gridGphone.Visibility = Visibility.Collapsed;
                gridmy.Visibility = Visibility.Collapsed;
                gridInt.Visibility = Visibility.Visible;
                gridGphone.ShowLoadingPanel = true;
                LoadOperation<internet> LoadOp;
                EntityQuery<internet> Query = dstb.GetInternetsQuery();
                if (chkFilter.IsChecked == true)
                    LoadOp = dstb.Load(Query.Where(p => km.Contains(p.ma_km.Trim()) && p.ma_dv.Trim() == "FIBER" && App.nhomtd.Contains(p.ma_huyen)).OrderBy(p => p.ngay_hd), LoadOpfib_Complete, null);
                else
                    LoadOp = dstb.Load(Query.Where(p => km.Contains(p.ma_km.Trim()) && p.ma_dv.Trim() == "FIBER" && App.nhomtd.Contains(p.ma_huyen) && p.ngay_hd >= dbegin.DateTime && p.ngay_hd <= dend.DateTime).OrderBy(p => p.ngay_hd), LoadOpfib_Complete, null);

            }
        }


        void LoadOpcd_Complete(LoadOperation<ds_codinh> lo)
        {             
            //if (lo.Entities.Count() > 0)
            //{
                gridCodinh.ItemsSource = lo.Entities;
                gridCodinh.GroupBy("ma_huyen");
                gridCodinh.GroupBy("ma_tram");
            //}
            gridCodinh.ShowLoadingPanel = false;
            this.Title = "Thống kê khuyến mãi điện thoại cố định - " + lo.Entities.Count().ToString();
        }

        void LoadOpgp_Complete(LoadOperation<Gphone> lo)
        {
            //if (lo.Entities.Count() > 0)
            //{
                gridGphone.ItemsSource = lo.Entities;
                gridGphone.GroupBy("ma_huyen");
                gridGphone.GroupBy("ma_tram");
            //}
            gridGphone.ShowLoadingPanel = false;
            this.Title = "Thống kê khuyến mãi điện thoại Gphone - " + lo.Entities.Count().ToString();
        }

        void LoadOpmy_Complete(LoadOperation<mytv> lo)
        {
            //if (lo.Entities.Count() > 0)
            //{
                gridmy.ItemsSource = lo.Entities;
                gridmy.GroupBy("ma_huyen");
                gridmy.GroupBy("ma_tram");
            //}
            gridmy.ShowLoadingPanel = false;
            this.Title = "Thống kê khuyến mãi thuê bao MyTv - " + lo.Entities.Count().ToString();
        }

        void LoadOpint_Complete(LoadOperation<internet> lo)
        {
            //if (lo.Entities.Count() > 0)
            //{
                gridInt.ItemsSource = lo.Entities;
                gridInt.GroupBy("ma_huyen");
                gridInt.GroupBy("ma_tram");
           // }
            gridInt.ShowLoadingPanel = false;
            this.Title = "Thống kê khuyến mãi thuê bao MegaVNN - " + lo.Entities.Count().ToString();
        }

        void LoadOpfib_Complete(LoadOperation<internet> lo)
        {
            //if (lo.Entities.Count() > 0)
            //{
            gridInt.ItemsSource = lo.Entities;
            gridInt.GroupBy("ma_huyen");
            gridInt.GroupBy("ma_tram");
            // }
            gridInt.ShowLoadingPanel = false;
            this.Title = "Thống kê khuyến mãi thuê bao FiberVNN - " + lo.Entities.Count().ToString();
        }
    
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (cmbkm.Text.Trim() == "")
            {
                MessageBox.Show("Chưa chọn chương trình khuyến mại !");
                return;
            }
            else
            dien_dl();
        }

        private void rcodinh_Checked(object sender, RoutedEventArgs e)
        {
            rgphone.IsChecked = false;
            rmytv.IsChecked = false;
            rint.IsChecked = false;
            rfib.IsChecked = false;
        }

        private void rgphone_Checked(object sender, RoutedEventArgs e)
        {
            rcodinh.IsChecked = false;
            rmytv.IsChecked = false;
            rint.IsChecked = false;
            rfib.IsChecked = false;
        }

        private void rmytv_Checked(object sender, RoutedEventArgs e)
        {
            rcodinh.IsChecked = false;
            rgphone.IsChecked = false;
            rint.IsChecked = false;
            rfib.IsChecked = false;
        }

        private void rint_Checked(object sender, RoutedEventArgs e)
        {
            rcodinh.IsChecked = false;
            rgphone.IsChecked = false;
            rmytv.IsChecked = false;
            rfib.IsChecked = false;
        }

        private void rfib_Checked(object sender, RoutedEventArgs e)
        {
            rcodinh.IsChecked = false;
            rgphone.IsChecked = false;
            rmytv.IsChecked = false;
            rint.IsChecked = false;
        }

        private void chkFilter_Checked(object sender, RoutedEventArgs e)
        {
            dbegin.Visibility = Visibility.Collapsed;
            dend.Visibility = Visibility.Collapsed;
            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;
        }

        private void chkFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            dbegin.Visibility = Visibility.Visible;
            dend.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
        }

    }
}
