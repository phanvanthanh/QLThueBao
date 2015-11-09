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
    public partial class frmdsnhom : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        bool exp;
        public frmdsnhom()
        {
            InitializeComponent();
            FunAndPro.CheckUser(cmdSua);
            FunAndPro.CheckUser(cmdCat);
            dien_dl();
        }
        public void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;
            if (App.admin)
            {
                EntityQuery<nhom_kh> Query = dstb.GetNhom_khQuery();
                LoadOperation<nhom_kh> LoadOp = dstb.Load(Query.OrderBy(p=>p.ma_kh), LoadOp_Complete, null);
            }
            else
            {
                EntityQuery<nhom_kh> Query = dstb.GetNhom_khQuery();
                LoadOperation<nhom_kh> LoadOp = dstb.Load(Query.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ma_kh), LoadOp_Complete, null);
            }
        }
        void LoadOp_Complete(LoadOperation<nhom_kh> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                //dataPager1.Source = lo.Entities;
                //PagedCollectionView pagedCollectionView = new PagedCollectionView(lo.Entities);                
                //dataPager1.Source = pagedCollectionView;
                //dataPager1.PageSize = 200;
                //gridControl1.ItemsSource = DevExpress.Xpf.Core.Native.DataBindingHelper.ExtractDataSourceFromCollectionView(dataPager1.Source);
                gridControl1.GroupBy(makh);
                gridControl1.ItemsSource = lo.Entities;
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

        private void Tim()
        {
            string tim, tim1;
            tim = this.txttim.Text == null ? "" : this.txttim.Text.Trim().ToUpper();
            this.txttim.Text = tim;
            gridControl1.ExpandAllGroups();
            for (int i = 0; i < gridControl1.VisibleRowCount; i++)
            {
                int rowHandle = gridControl1.GetRowHandleByVisibleIndex(i);
                if (!gridControl1.IsGroupRowHandle(rowHandle))
                {
                    tim1 = gridControl1.GetCellValue(rowHandle, sodt).ToString().Trim();
                    if (tim1==tim)
                    {
                        gridControl1.ExpandGroupRow(rowHandle);
                        gridControl1.View.FocusedRowHandle = rowHandle;
                        return;
                    }
                }
            }
            gridControl1.CollapseAllGroups();
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
                frmeditcd editcd = new frmeditcd(false, sdt,1);
                editcd.txtsdt.Text = sdt;
                this.Hide();
                editcd.Show();                
            }
        }

        private void cmdCat_Click(object sender, RoutedEventArgs e)
        {
            if (App.sua)
            {
                string sdt = gridControl1.GetFocusedRowCellValue(sodt).ToString().Trim();
                txttim.Text = sdt;
                frmcatcd catcd = new frmcatcd(sdt,false);
                catcd.txtsdt.Text = sdt;
                this.Hide();
                catcd.Show();
            }
        }

        private void grid_GroupRowExpanding(object sender, DevExpress.Xpf.Grid.RowAllowEventArgs e)
        {
            this.gridControl1.ShowLoadingPanel = true;
        }

        private void grid_GroupRowExpanded(object sender, DevExpress.Xpf.Grid.RowEventArgs e)
        {
            this.gridControl1.ShowLoadingPanel = false;
            exp = true;
        }

        private void CmdExpand_Click(object sender, RoutedEventArgs e)
        {
            if (exp)
            {
                gridControl1.CollapseAllGroups();
                exp = false;
            }
            else
                gridControl1.ExpandAllGroups();
        }     

        //private void Tim()
        //{
        //    gridControl1.ShowLoadingPanel = true;
        //    string chuoi;
        //    chuoi = this.txttim.Text == null ? "" : this.txttim.Text.Trim().ToUpper();
        //    EntityQuery<nhom_kh> Query = dstb.GetNhom_khQuery();
        //    LoadOperation<nhom_kh> LoadOp = dstb.Load(Query.Where
        //                                        (p =>
        //                                             p.so_dt == chuoi ||
        //                                             p.ma_kh == chuoi ||
        //                                             p.ma_kh.Contains(chuoi) ||
        //                                             p.ten_dktb.Trim().ToUpper().EndsWith(chuoi) ||
        //                                             p.ten_dktb.Trim().ToUpper().StartsWith(chuoi) ||
        //                                             p.ten_dktb.Trim().ToUpper().Contains(chuoi)
        //                                        ), dien_dlF, null);
        //}

        //private void dien_dlF(LoadOperation<nhom_kh> lo)
        //{
        //    gridControl1.ItemsSource = lo.Entities; ;
        //    gridControl1.ShowLoadingPanel = false;
        //}
    }
}
