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
    public partial class frmtkslgandb : DXWindow
    {
        public frmtkslgandb()
        {
            InitializeComponent();
            rdnhanvien.IsChecked = true;
            rddiaban.IsChecked = false;
            thang.EditValue = DateTime.Now;
            thang.IsReadOnly = true;
            GetData();
           // CallTimer();
        }       

        void GetData()
        {
            bool dba;
            if (rdnhanvien.IsChecked==true)
                dba=true;
            else
                dba=false;
            grid.ShowLoadingPanel = true;
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();            
            InvokeOperation<System.Nullable<int>> p = db.Excute_TKsoluongtbGanNV(App.kythuat,dba);
            p.Completed += new EventHandler(Completed);
          
        }


        void Completed(object sende, EventArgs e)
        {
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            EntityQuery<SLGanDB> Query = db.GetSLGanDBQuery();
            LoadOperation<SLGanDB> LoadOp = db.Load(Query.Where(p => App.nhomtd.Contains(p.ma_huyen)).OrderBy(p => p.ma_huyen).OrderBy(p => p.ten_tuyen), LoadOp_Complete, null);
               
        }

        void LoadOp_Complete(LoadOperation<SLGanDB> lo)
        {
            grid.ItemsSource = lo.Entities;
           // MessageBox.Show(lo.Entities.Count().ToString());
            grid.GroupBy("ma_huyen");
            if (rddiaban.IsChecked == true)
            {
                ma_tuyen.Visible = true;
                ten_tuyen.Visible = true;
            }
            else
            {
                ma_tuyen.Visible = false;
               // ten_tuyen.Visible = false;
            }
            grid.ExpandAllGroups();
            tien.Header = "Cước " + lo.Entities.ElementAt(0).thang.Trim();
            grid.ShowLoadingPanel = false;
            
        }

      private void XemButton_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }

      private void rdnhanvien_Checked(object sender, RoutedEventArgs e)
      {
          rddiaban.IsChecked = false;
      }

      private void rddiaban_Checked(object sender, RoutedEventArgs e)
      {
          rdnhanvien.IsChecked = false;
      }

      private void in1Item_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
      {
          if (grid.GetFocusedRow() != null)
          {
              string m_tuyen = grid.GetFocusedRowCellValue(ma_tuyen).ToString().Trim();
              string m_huyen = grid.GetFocusedRowCellValue(ma_huyen).ToString().Trim();
              frmdsgandiaban frm = new frmdsgandiaban(App.kythuat,m_tuyen,m_huyen,false);
              frm.Width = this.ActualWidth;
              frm.Height = this.ActualHeight;
              frm.Show();
          }
      }
      private void inAllItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
      {
          if (grid.GetFocusedRow() != null)
          {
              //string m_tuyen = grid.GetFocusedRowCellValue(ma_tuyen).ToString().Trim();
              string m_huyen = grid.GetFocusedRowCellValue(ma_huyen).ToString().Trim();
              frmdsgandiaban frm = new frmdsgandiaban(App.kythuat, "", m_huyen, true);
              frm.Width = this.ActualWidth;
              frm.Height = this.ActualHeight;
              frm.Show();
          }
      }

      private void inItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
      {
          if (grid.GetFocusedRow() != null)
          {
              //string m_tuyen = grid.GetFocusedRowCellValue(ma_tuyen).ToString().Trim();
              string m_huyen = grid.GetFocusedRowCellValue(ma_huyen).ToString().Trim();
              frmdsgandiaban frm = new frmdsgandiaban(App.kythuat, "", m_huyen,false);
              frm.Width = this.ActualWidth;
              frm.Height = this.ActualHeight;
              frm.Show();
          }
      }

    }
}

