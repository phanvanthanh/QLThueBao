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
    public partial class frmdsbdint : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<INTERNET> LoadOp;
        public frmdsbdint()
        {
            InitializeComponent();           
            dthangbd.EditValue = App.Current_d;            
            dien_dl();
        }
        public void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;
            EntityQuery<INTERNET> Query = dstb.GetINTERNETQuery();
            LoadOp = dstb.Load(Query.Where(p => p.ma_huyen == App.ma_huyen && ((p.ngay_ld.Value.Month == dthangbd.DateTime.Month && p.ngay_ld.Value.Year == dthangbd.DateTime.Year) || (p.ngay_ngung.Value.Month == dthangbd.DateTime.Month && p.ngay_ngung.Value.Year == dthangbd.DateTime.Year))), LoadOp_Complete, null);
        }
        void LoadOp_Complete(LoadOperation<INTERNET> lo)
        {
            //if (lo.Entities.Count() > 0)
            //{
            gridControl1.ItemsSource = lo.Entities;
                //dataPager1.Source = lo.Entities;
                //PagedCollectionView pagedCollectionView = new PagedCollectionView(lo.Entities);                
                //dataPager1.Source = pagedCollectionView;
                //dataPager1.PageSize = 200;
                //gridControl1.ItemsSource = DevExpress.Xpf.Core.Native.DataBindingHelper.ExtractDataSourceFromCollectionView(dataPager1.Source);
                this.Title = "Danh sách biến động thuê bao Internet - " + lo.Entities.Count().ToString();
            //}
            gridControl1.ShowLoadingPanel = false;
        }
     
        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            dien_dl();
        }

      
        private void FindButtons_Click(object sender, RoutedEventArgs e)
        {
            Tim();
        }

        void Tim()
        {
            for (int j = 0; j < gridControl1.VisibleRowCount; j++)
            {
                int rowHandle = gridControl1.GetRowHandleByVisibleIndex(j);                
                
                if (gridControl1.GetCellValue(rowHandle, account).ToString().Trim() == this.txttim.Text.Trim())
                {                   
                    gridControl1.ShowLoadingPanel = false;
                    gridControl1.View.FocusedRowHandle = rowHandle;
                    gridControl1.View.MoveFocusedRow(rowHandle);
                    return;
                }
            }
            MessageBox.Show("Không tìm thấy thuê bao" + this.txttim.Text.Trim() +" trong danh sách này !");
            gridControl1.ShowLoadingPanel = false;
        }
    }
}
