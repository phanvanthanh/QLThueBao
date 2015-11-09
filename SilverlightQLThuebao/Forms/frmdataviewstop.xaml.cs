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
    public partial class frmdataviewstop : DXWindow
    {        
        public frmdataviewstop(string loai, string mbd, string mhuyen,DateTime ngaybd, DateTime ngaykt)
        {
            InitializeComponent();
            dien_dl(loai, mbd, mhuyen, ngaybd, ngaykt);          
        }

        void dien_dl(string mloai, string mbd,string mhuyen,DateTime ngaybd, DateTime ngaykt) //mbd M: hoa mang N: ngung C: cat T:thtb
        {
            QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
            // loai co dinh
            if (mloai == "C")
            {
                EntityQuery<codinh_log> Query = dstb.GetCodinh_logQuery();
                LoadOperation<codinh_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && p.lydocat == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpCDComplete, null);
                
            }

            // loai Gphone
            if (mloai == "G")
            {
                EntityQuery<Gphone_log> Query = dstb.GetGphone_logQuery();
                LoadOperation<Gphone_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && p.lydocat == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt && p.loai_tb == false), LoadOpGPComplete, null);
                
            }

         
            // loai MyTV
            if (mloai == "M")
            {
               EntityQuery<mytv_log> Query = dstb.GetMytv_logQuery();
               LoadOperation<mytv_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && p.lydocat == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpMYComplete, null);
            
            }


            // loai internet
            if (mloai == "I")
            {
                 EntityQuery<internet_log> Query = dstb.GetInternet_logQuery();
                 LoadOperation<internet_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && p.ma_dv == "ADSL" && p.lydocat == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpINTComplete, null);               
            }

            // loai ftth
            if (mloai == "F")
            { 
                EntityQuery<internet_log> Query = dstb.GetInternet_logQuery();
                LoadOperation<internet_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && p.ma_dv == "FIBER" && p.lydocat == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpINTComplete, null);
                
            }

        }

        void LoadOpCDComplete(LoadOperation<codinh_log> lo)
        {
            gridCdGp.Visibility = Visibility.Visible;
            gridmyint.Visibility = Visibility.Collapsed;
            gridCdGp.ItemsSource = lo.Entities;
            gridCdGp.GroupBy("so_dt");
            gridCdGp.ExpandAllGroups();
        }

        void LoadOpGPComplete(LoadOperation<Gphone_log> lo)
        {
            gridCdGp.Visibility = Visibility.Visible;
            gridmyint.Visibility = Visibility.Collapsed;
            gridCdGp.ItemsSource = lo.Entities;
           // gridCdGp.GroupBy("so_dt");
           // gridCdGp.ExpandAllGroups();
        }

        void LoadOpMYComplete(LoadOperation<mytv_log> lo)
        {
            gridCdGp.Visibility = Visibility.Collapsed;
            gridmyint.Visibility = Visibility.Visible;
            gridmyint.ItemsSource = lo.Entities;
            //gridmyint.GroupBy("user_name");
           // gridmyint.ExpandAllGroups();
        }

        void LoadOpINTComplete(LoadOperation<internet_log> lo)
        {
            gridCdGp.Visibility = Visibility.Collapsed;
            gridmyint.Visibility = Visibility.Visible;
            gridmyint.ItemsSource = lo.Entities;
            //gridmyint.GroupBy("user_name");
            //gridmyint.ExpandAllGroups();
        }
    }
}
