using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using System.ServiceModel.DomainServices.Client;
using SilverlightQLThuebao.Web.Services;
using SilverlightQLThuebao.Web.Models;

namespace SilverlightQLThuebao
{
    public partial class frmbao119 : ChildWindow
    {
        LoadOperation<C119TVPrefix> Load;
        public frmbao119()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtsogoibao.Text.Trim() == "" || txtsogoibao.Text.Trim().Length < 7)
            {
                MessageBox.Show("Chưa nhập vào số gọi báo hoặc số gọi báo chưa đúng !");
                return;
            }

            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            string m_user = App.User_name.Length > 12 ? App.User_name.Substring(0, 13) : App.User_name;
            InvokeOperation<System.Nullable<int>> p = db.Excute_p_bao119(txtsdt.Text.Trim(), App.refix_119, txtsogoibao.Text.Trim());
            p.Completed += new EventHandler(GetData);
            //QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            //EntityQuery<C119TVPrefix> Query = db.GetC119TVPrefixQuery();
            //Load = db.Load(Query.OrderBy(p=>p.nPrefixBegin),LoadOpComplete,null);

          
        }

        //void LoadOpComplete(LoadOperation<C119TVPrefix> lo)
        //{
        //    bool found=false;
        //    if (lo.Entities.Count()>0)
        //    {
        //        for (int i = 0; i < lo.Entities.Count(); i++)
        //        {
        //            int les=lo.Entities.ElementAt(i).nPrefixBegin.ToString().Trim().Length;
                  
        //            if (lo.Entities.ElementAt(i).nPrefixBegin<=Convert.ToInt16(txtsdt.Text.Trim().Substring(0,les)) && lo.Entities.ElementAt(i).nPrefixEnd>=Convert.ToInt16(txtsdt.Text.Trim().Substring(0,les)))
        //            {                       
        //                QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        //                string m_user = App.User_name.Length > 12 ? App.User_name.Substring(0, 13) : App.User_name;
        //                InvokeOperation<System.Nullable<int>> p = db.Excute_p_bao119(txtsdt.Text.Trim(), Convert.ToInt16(lo.Entities.ElementAt(i).nGroupID), txtsogoibao.Text.Trim());
        //                p.Completed += new EventHandler(GetData);
        //                found = true;
        //                break;
        //            }
        //        }
        //    }
        //    if (found == false)
        //    {
        //        MessageBox.Show("Đầu số này chưa được cài đặt. vui lòng liên hệ TTCNTT !");
        //        return;
        //    }
        //}

           


        void GetData(object sender, EventArgs e)
        {
            MessageBox.Show("Đã báo 119 xong !");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

         
        private void txttentb_DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            grid.ShowLoadingPanel = true;
            txtsdt.IsEnabled = false;
            txttentb.IsEnabled = false;
            QLThuebaoDomainContext dbs = new QLThuebaoDomainContext();
            if (App.admin_119)
            {
                EntityQuery<ds119s> Query = dbs.Getds119Query(txttentb.Text.Trim());
                LoadOperation<ds119s> Load = dbs.Load(Query, LoadOpComplete, null);
            }
            else
            {
                EntityQuery<ds119s> Query = dbs.Getds119Query(txttentb.Text.Trim());
                LoadOperation<ds119s> Load = dbs.Load(Query.Where(p => p.ma_huyen == App.ma_huyen), LoadOpComplete, null);
            }
        }

        private void txtsdt_DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            grid.ShowLoadingPanel = true;
            txtsdt.IsEnabled = false;
            txttentb.IsEnabled = false;
            QLThuebaoDomainContext dbs = new QLThuebaoDomainContext();
            if (App.admin_119)
            {
                EntityQuery<ds119s> Query = dbs.Getds119Query(txtsdt.Text.Trim());
                LoadOperation<ds119s> Load = dbs.Load(Query, LoadOpComplete, null);
            }
            else
            {
                EntityQuery<ds119s> Query = dbs.Getds119Query(txtsdt.Text.Trim());
                LoadOperation<ds119s> Load = dbs.Load(Query.Where(p=>p.ma_huyen==App.ma_huyen), LoadOpComplete, null);
            }
        }

        void LoadOpComplete(LoadOperation<ds119s> lo)
        {
            grid.ItemsSource = lo.Entities;
            txtsdt.IsEnabled = true;
            txttentb.IsEnabled = true;
            grid.ShowLoadingPanel = false;
        }

        private void view_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            string m_so = grid.GetFocusedRowCellValue(so_dt).ToString().Trim();
            string m_ten = grid.GetFocusedRowCellValue(tentb).ToString().Trim();
            string m_dc = grid.GetFocusedRowCellValue(diachidb).ToString().Trim();
            txtsdt.Text = m_so;
            txttentb.Text = m_ten;
            txttendb.Text = m_dc;
        }

        private void txttendb_DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            grid.ShowLoadingPanel = true;
            txtsdt.IsEnabled = false;
         
            QLThuebaoDomainContext dbs = new QLThuebaoDomainContext();
            if (App.admin_119)
            {
                EntityQuery<ds119s> Query = dbs.Getds119Query(txttendb.Text.Trim());
                LoadOperation<ds119s> Load = dbs.Load(Query, LoadOpComplete, null);
            }
            else
            {
                EntityQuery<ds119s> Query = dbs.Getds119Query(txttendb.Text.Trim());
                LoadOperation<ds119s> Load = dbs.Load(Query.Where(p => p.ma_huyen == App.ma_huyen), LoadOpComplete, null);
            }
        }
     
    }
}

