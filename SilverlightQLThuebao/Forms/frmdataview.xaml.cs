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
    public partial class frmdataview : DXWindow
    {        
        public frmdataview(string loai, string mbd, string mhuyen,DateTime ngaybd, DateTime ngaykt)
        {
            InitializeComponent();
            if (mhuyen=="WWW")
                dien_dl_all(loai, mbd, mhuyen, ngaybd, ngaykt);          
            else
                dien_dl(loai, mbd, mhuyen, ngaybd, ngaykt);          
        }

        void dien_dl(string mloai, string mbd,string mhuyen,DateTime ngaybd, DateTime ngaykt) //mbd M: hoa mang N: ngung C: cat T:thtb
        {
            QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
            // loai co dinh
            if (mloai == "C")
            {
                
                switch( mbd)
                {
                    case "T":
                        EntityQuery<codinh_log> Query = dstb.GetCodinh_logQuery();
                        LoadOperation<codinh_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && (p.may_ngung == "C" || p.may_ngung == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpCDComplete, null);
                        break;
                    case "M":
                        EntityQuery<codinh_log> QueryM = dstb.GetCodinh_logQuery();
                        LoadOperation<codinh_log> LoadM = dstb.Load(QueryM.Where(p => p.ma_huyen == mhuyen && p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt), LoadOpCDComplete, null);
                        break;
                    
                    default:
                        EntityQuery<codinh_log> Queryd = dstb.GetCodinh_logQuery();
                        LoadOperation<codinh_log> Loadd = dstb.Load(Queryd.Where(p => p.ma_huyen == mhuyen && p.may_ngung == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpCDComplete, null);
                        break;
                }
            }

            // loai Gphone
            if (mloai == "G")
            {

                switch (mbd)
                {
                    case "T":
                        EntityQuery<Gphone_log> Query = dstb.GetGphone_logQuery();
                        LoadOperation<Gphone_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && (p.may_ngung == "C" || p.may_ngung == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt && p.loai_tb == false), LoadOpGPComplete, null);
                        break;
                    case "M":
                        EntityQuery<Gphone_log> QueryM = dstb.GetGphone_logQuery();
                        LoadOperation<Gphone_log> LoadM = dstb.Load(QueryM.Where(p => p.ma_huyen == mhuyen && p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt && p.loai_tb == false), LoadOpGPComplete, null);
                        break;
                    default:
                        EntityQuery<Gphone_log> Queryd = dstb.GetGphone_logQuery();
                        LoadOperation<Gphone_log> Loadd = dstb.Load(Queryd.Where(p => p.ma_huyen == mhuyen && p.may_ngung == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt && p.loai_tb == false), LoadOpGPComplete, null);
                        break;
                }
            }

            // loai Gphone
            if (mloai == "GT")
            {

                switch (mbd)
                {
                    case "T":
                        EntityQuery<Gphone_log> Query = dstb.GetGphone_logQuery();
                        LoadOperation<Gphone_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && (p.may_ngung == "C" || p.may_ngung == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt && p.loai_tb == true), LoadOpGPComplete, null);
                        break;
                    case "M":
                        EntityQuery<Gphone_log> QueryM = dstb.GetGphone_logQuery();
                        LoadOperation<Gphone_log> LoadM = dstb.Load(QueryM.Where(p => p.ma_huyen == mhuyen && p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt && p.loai_tb == true), LoadOpGPComplete, null);
                        break;
                    default:
                        EntityQuery<Gphone_log> Queryd = dstb.GetGphone_logQuery();
                        LoadOperation<Gphone_log> Loadd = dstb.Load(Queryd.Where(p => p.ma_huyen == mhuyen && p.may_ngung == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt && p.loai_tb == true), LoadOpGPComplete, null);
                        break;
                }
            }


            // loai MyTV
            if (mloai == "M")
            {

                switch (mbd)
                {
                    case "T":
                        EntityQuery<mytv_log> Query = dstb.GetMytv_logQuery();
                        LoadOperation<mytv_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && (p.tinh_trang == "C" || p.tinh_trang == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpMYComplete, null);
                        break;
                    case "M":
                        EntityQuery<mytv_log> QueryM = dstb.GetMytv_logQuery();
                        LoadOperation<mytv_log> LoadM = dstb.Load(QueryM.Where(p => p.ma_huyen == mhuyen && p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt), LoadOpMYComplete, null);
                        break;
                    default:
                        EntityQuery<mytv_log> Queryd = dstb.GetMytv_logQuery();
                        LoadOperation<mytv_log> Loadd = dstb.Load(Queryd.Where(p => p.ma_huyen == mhuyen && p.tinh_trang == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpMYComplete, null);
                        break;
                }
            }


            // loai internet
            if (mloai == "I")
            {

                switch (mbd)
                {
                    case "T":
                        EntityQuery<internet_log> Query = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && p.ma_dv == "ADSL" && (p.may_ngung == "C" || p.may_ngung == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpINTComplete, null);
                        break;
                    case "M":
                        EntityQuery<internet_log> QueryM = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> LoadM = dstb.Load(QueryM.Where(p => p.ma_huyen == mhuyen && p.ma_dv == "ADSL" && p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt), LoadOpINTComplete, null);
                        break;
                    default:
                        EntityQuery<internet_log> Queryd = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> Loadd = dstb.Load(Queryd.Where(p => p.ma_huyen == mhuyen && p.ma_dv == "ADSL" && p.may_ngung == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpINTComplete, null);
                        break;
                }
            }

            // loai ftth
            if (mloai == "F")
            {

                switch (mbd)
                {
                    case "T":
                        EntityQuery<internet_log> Query = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> Load = dstb.Load(Query.Where(p => p.ma_huyen == mhuyen && p.ma_dv == "FIBER" && (p.may_ngung == "C" || p.may_ngung == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpINTComplete, null);
                        break;
                    case "M":
                        EntityQuery<internet_log> QueryM = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> LoadM = dstb.Load(QueryM.Where(p => p.ma_huyen == mhuyen && p.ma_dv == "FIBER" && p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt), LoadOpINTComplete, null);
                        break;
                    default:
                        EntityQuery<internet_log> Queryd = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> Loadd = dstb.Load(Queryd.Where(p => p.ma_huyen == mhuyen && p.ma_dv == "FIBER" && p.may_ngung == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpINTComplete, null);
                        break;
                }
            }

        }

        void LoadOpCDComplete(LoadOperation<codinh_log> lo)
        {
            gridCdGp.Visibility = Visibility.Visible;
            gridmyint.Visibility = Visibility.Collapsed;
            gridCdGp.ItemsSource = lo.Entities;
           // gridCdGp.GroupBy("so_dt");
           // gridCdGp.ExpandAllGroups();
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


        void dien_dl_all(string mloai, string mbd, string mhuyen, DateTime ngaybd, DateTime ngaykt) //mbd M: hoa mang N: ngung C: cat T:thtb
        {
            QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
            // loai co dinh
            if (mloai == "C")
            {

                switch (mbd)
                {
                    case "T":
                        EntityQuery<codinh_log> Query = dstb.GetCodinh_logQuery();
                        LoadOperation<codinh_log> Load = dstb.Load(Query.Where(p => (p.may_ngung == "C" || p.may_ngung == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt).OrderBy(p => p.so_dt), LoadOpCDComplete, null);
                        break;
                    case "M":
                        EntityQuery<codinh_log> QueryM = dstb.GetCodinh_logQuery();
                        LoadOperation<codinh_log> LoadM = dstb.Load(QueryM.Where(p => p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt).OrderBy(p => p.so_dt), LoadOpCDComplete, null);
                        break;
                    default:
                        EntityQuery<codinh_log> Queryd = dstb.GetCodinh_logQuery();
                        LoadOperation<codinh_log> Loadd = dstb.Load(Queryd.Where(p => p.may_ngung == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt).OrderBy(p => p.so_dt), LoadOpCDComplete, null);
                        break;
                }
            }

            // loai Gphone
            if (mloai == "G")
            {

                switch (mbd)
                {
                    case "T":
                        EntityQuery<Gphone_log> Query = dstb.GetGphone_logQuery();
                        LoadOperation<Gphone_log> Load = dstb.Load(Query.Where(p => (p.may_ngung == "C" || p.may_ngung == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt).OrderBy(p => p.so_dt), LoadOpGPComplete, null);
                        break;
                    case "M":
                        EntityQuery<Gphone_log> QueryM = dstb.GetGphone_logQuery();
                        LoadOperation<Gphone_log> LoadM = dstb.Load(QueryM.Where(p => p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt).OrderBy(p => p.so_dt), LoadOpGPComplete, null);
                        break;
                    default:
                        EntityQuery<Gphone_log> Queryd = dstb.GetGphone_logQuery();
                        LoadOperation<Gphone_log> Loadd = dstb.Load(Queryd.Where(p => p.may_ngung == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt).OrderBy(p => p.so_dt), LoadOpGPComplete, null);
                        break;
                }
            }

            // loai MyTV
            if (mloai == "M")
            {
                switch (mbd)
                {
                    case "T":
                        EntityQuery<mytv_log> Query = dstb.GetMytv_logQuery();
                        LoadOperation<mytv_log> Load = dstb.Load(Query.Where(p => (p.tinh_trang == "C" || p.tinh_trang == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt).OrderBy(p => p.user_name), LoadOpMYComplete, null);
                        break;
                    case "M":
                        EntityQuery<mytv_log> QueryM = dstb.GetMytv_logQuery();
                        LoadOperation<mytv_log> LoadM = dstb.Load(QueryM.Where(p => p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt).OrderBy(p => p.user_name), LoadOpMYComplete, null);
                        break;
                    default:
                        EntityQuery<mytv_log> Queryd = dstb.GetMytv_logQuery();
                        LoadOperation<mytv_log> Loadd = dstb.Load(Queryd.Where(p => p.tinh_trang == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt).OrderBy(p => p.user_name), LoadOpMYComplete, null);
                        break;
                }
            }


            // loai internet
            if (mloai == "I")
            {

                switch (mbd)
                {
                    case "T":
                        EntityQuery<internet_log> Query = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> Load = dstb.Load(Query.Where(p => p.ma_dv == "ADSL" && (p.may_ngung == "C" || p.may_ngung == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt), LoadOpINTComplete, null);
                        break;
                    case "M":
                        EntityQuery<internet_log> QueryM = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> LoadM = dstb.Load(QueryM.Where(p => p.ma_dv == "ADSL" && p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt).OrderBy(p => p.user_name), LoadOpINTComplete, null);
                        break;
                    default:
                        EntityQuery<internet_log> Queryd = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> Loadd = dstb.Load(Queryd.Where(p => p.ma_dv == "ADSL" && p.may_ngung == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt).OrderBy(p => p.user_name), LoadOpINTComplete, null);
                        break;
                }
            }

            // loai ftth
            if (mloai == "F")
            {
                switch (mbd)
                {
                    case "T":
                        EntityQuery<internet_log> Query = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> Load = dstb.Load(Query.Where(p => p.ma_dv == "FIBER" && (p.may_ngung == "C" || p.may_ngung == "N") && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt).OrderBy(p => p.user_name), LoadOpINTComplete, null);
                        break;
                    case "M":
                        EntityQuery<internet_log> QueryM = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> LoadM = dstb.Load(QueryM.Where(p => p.ma_dv == "FIBER" && p.ngay_hd >= ngaybd && p.ngay_hd <= ngaykt).OrderBy(p => p.user_name), LoadOpINTComplete, null);
                        break;
                    default:
                        EntityQuery<internet_log> Queryd = dstb.GetInternet_logQuery();
                        LoadOperation<internet_log> Loadd = dstb.Load(Queryd.Where(p => p.ma_dv == "FIBER" && p.may_ngung == mbd && p.ngay_ngung >= ngaybd && p.ngay_ngung <= ngaykt).OrderBy(p => p.user_name), LoadOpINTComplete, null);
                        break;
                }
            }

        }

      

    }
}
