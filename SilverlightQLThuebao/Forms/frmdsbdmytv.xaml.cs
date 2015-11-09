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
    public partial class frmdsbdmytv : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<mytv> LoadOp;
        public frmdsbdmytv()
        {
            InitializeComponent();            
            dthangbd.EditValue = App.Current_d;            
            dien_dl();
        }
        public void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;           
            EntityQuery<mytv> Query = dstb.GetMytvsQuery();
            LoadOp = dstb.Load(Query.Where(p => p.ma_huyen == App.ma_huyen && ((p.ngay_ld.Value.Month == dthangbd.DateTime.Month && p.ngay_ld.Value.Year == dthangbd.DateTime.Year) || (p.ngay_ngung.Value.Month == dthangbd.DateTime.Month && p.ngay_ngung.Value.Year == dthangbd.DateTime.Year))), LoadOp_Complete, null);
        }
        void LoadOp_Complete(LoadOperation<mytv> lo)
        {
            //if (lo.Entities.Count() > 0)
            //{
                dataPager1.Source = lo.Entities;
                PagedCollectionView pagedCollectionView = new PagedCollectionView(lo.Entities);                
                dataPager1.Source = pagedCollectionView;
                dataPager1.PageSize = 200;
                gridControl1.ItemsSource = DevExpress.Xpf.Core.Native.DataBindingHelper.ExtractDataSourceFromCollectionView(dataPager1.Source);
                this.Title = "Danh sách biến động thuê bao MyTV - " + lo.Entities.Count().ToString();
            //}            

            gridControl1.ShowLoadingPanel = false;
        }

     
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            dien_dl();
        }

        //void Tim()
        //{
        //    gridControl1.ShowLoadingPanel = true;
        //    for (int i = 0; i < dataPager1.PageCount; i++)
        //    {
        //        dataPager1.PageIndex = i;
        //        for (int j = 0; j < gridControl1.VisibleRowCount; j++)
        //        {
        //            int rowHandle = gridControl1.GetRowHandleByVisibleIndex(j);
        //            if (gridControl1.GetCellValue(rowHandle, sodt).ToString().Trim() == this.txttim.Text.Trim())
        //            {
        //                gridControl1.ShowLoadingPanel = false;
        //                gridControl1.View.FocusedRowHandle = rowHandle;
        //                return;
        //            }
        //        }
        //    }
        //}

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            
            sua();
        }

        void sua()
        {
            //if (App.sua)
            //{
            //    string usr = gridControl1.GetFocusedRowCellValue(account).ToString().Trim();              
            //    frmeditmy editmy = new frmeditmy(usr);
            //    editmy.txtusr.Text = usr;
            //    this.Hide();
            //    editmy.Show();
            //}
        }       
    }
}
