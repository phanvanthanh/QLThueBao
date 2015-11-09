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
    public partial class frmdsgphone : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        public frmdsgphone()
        {
            InitializeComponent();
            FunAndPro.CheckUser(cmdSua);
            FunAndPro.CheckUser(cmdCat);
            dien_dl();
        }
        public void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;
            EntityQuery<Gphone> Query = dstb.GetGphonesQuery();
            LoadOperation<Gphone> LoadOp = dstb.Load(Query.Where(p => p.ma_huyen == App.ma_huyen), LoadOp_Complete, null);
        }
        void LoadOp_Complete(LoadOperation<Gphone> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                dataPager1.Source = lo.Entities;
                PagedCollectionView pagedCollectionView = new PagedCollectionView(lo.Entities);                
                dataPager1.Source = pagedCollectionView;
                dataPager1.PageSize = 200;
                gridControl1.ItemsSource = DevExpress.Xpf.Core.Native.DataBindingHelper.ExtractDataSourceFromCollectionView(dataPager1.Source);
                this.Title = "Danh sách thuê bao Gphone - " + lo.Entities.Count().ToString();
                gridControl1.ShowLoadingPanel = false;
                if (txttim.Text.Trim() != "")
                    Tim();
                    
            }

        }

        private void cmdSua_Click(object sender, RoutedEventArgs e)
        {
            sua();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            Tim();
        }

        void Tim()
        {
            gridControl1.ShowLoadingPanel = true;
            for (int i = 0; i < dataPager1.PageCount; i++)
            {
                dataPager1.PageIndex = i;
                for (int j = 0; j < gridControl1.VisibleRowCount; j++)
                {
                    int rowHandle = gridControl1.GetRowHandleByVisibleIndex(j);
                    if (gridControl1.GetCellValue(rowHandle, sodt).ToString().Trim() == this.txttim.Text.Trim())
                    {
                        gridControl1.ShowLoadingPanel = false;
                        gridControl1.View.FocusedRowHandle = rowHandle;
                        return;
                    }
                }
            }
            gridControl1.ShowLoadingPanel = false;
        }

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            
            sua();
        }

        void sua()
        {
            if (App.sua)
            {
                string sdt = gridControl1.GetFocusedRowCellValue(sodt).ToString().Trim();
                txttim.Text = sdt;
                frmeditgp editgp = new frmeditgp(false, sdt,1);
                editgp.txtsdt.Text = sdt;
                this.Hide();
                editgp.Show();                
            }
        }

        private void cmdCat_Click(object sender, RoutedEventArgs e)
        {       
            if (App.sua)
            {
                string sdt = gridControl1.GetFocusedRowCellValue(sodt).ToString().Trim();
                txttim.Text = sdt;
                frmcatgp catgp = new frmcatgp(sdt,true);
                catgp.txtsdt.Text = sdt;
                this.Hide();
                catgp.Show();
            }
        }        
        //private void Tim()
        //{
        //    gridControl1.ShowLoadingPanel = true;
        //    string chuoi;
        //    chuoi = this.txttim.Text == null ? "" : this.txttim.Text.Trim().ToUpper();            
        //    EntityQuery<ds_codinh> Query = dstb.GetDs_codinhQuery();
        //    LoadOperation<ds_codinh> LoadOp = dstb.Load(Query.Where
        //                                        (p =>
        //                                             p.so_dt == chuoi ||
        //                                             p.ten_dktb.Trim().ToUpper().EndsWith(chuoi) ||
        //                                             p.ten_dktb.Trim().ToUpper().StartsWith(chuoi) ||
        //                                             p.ten_dktb.Trim().ToUpper().Contains(chuoi)                                                    
        //                                        ), dien_dlF, null);
        //}

        //private void dien_dlF(LoadOperation<ds_codinh> lo)
        //{
        //    gridControl1.ItemsSource = lo.Entities;          ;
        //    gridControl1.ShowLoadingPanel = false;
        //}
    }
}
