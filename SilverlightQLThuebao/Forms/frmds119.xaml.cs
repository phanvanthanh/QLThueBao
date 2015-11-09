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
    public partial class frmds119 : DXWindow
    {      
        public frmds119()
        {
            InitializeComponent();            
            this.Loaded += new RoutedEventHandler(GetData);
            CallTimer();
        }

        public void CallTimer()
        {
            DispatcherTimer Timer = new DispatcherTimer();          
            Timer.Interval = new TimeSpan(0, 0, 0, 120);           
            Timer.Tick += new EventHandler(GetData);
            Timer.Start();            
        }

        void GetData(object sender, EventArgs e)
        {
            grid.ShowLoadingPanel = true;
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();           
            if (App.admin_119)
            {
                EntityQuery<ds_119> Query = db.GetDs_119Query();
                LoadOperation<ds_119> LoadOp = db.Load(Query.OrderByDescending(p => p.dtRecvTime), LoadOp_Complete, null);
                EntityQuery<dsw_119> Query1 = db.GetDsw_119Query();
                LoadOperation<dsw_119> LoadOp1 = db.Load(Query1.OrderByDescending(p => p.dtRecvTime), LoadOp1_Complete, null);
            }
            else
            {
                EntityQuery<ds_119> Query = db.GetDs_119Query();
                LoadOperation<ds_119> LoadOp = db.Load(Query.Where(p => App.nhomtd.Contains(p.ma_huyen)).OrderByDescending(p => p.dtRecvTime), LoadOp_Complete, null);
                EntityQuery<dsw_119> Query1 = db.GetDsw_119Query();
                LoadOperation<dsw_119> LoadOp1 = db.Load(Query1.Where(p => App.nhomtd.Contains(p.ma_huyen)).OrderByDescending(p => p.dtRecvTime), LoadOp1_Complete, null);
            }
        }




        //void GetData(object sender, EventArgs e)
        //{
        //    grid.ShowLoadingPanel = true;
        //    QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        //    InvokeOperation<System.Nullable<int>> p = db.Excute_get_119();
        //    p.Completed += new EventHandler(Completed);
        //}



        //void Completed(object sende, EventArgs e)
        //{           
        //    QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        //    if (App.admin_119)
        //    {
        //        EntityQuery<ds_119> Query = db.GetDs_119Query();
        //        LoadOperation<ds_119> LoadOp = db.Load(Query.OrderByDescending(p => p.dtRecvTime), LoadOp_Complete, null);
        //        EntityQuery<dsw_119> Query1 = db.GetDsw_119Query();
        //        LoadOperation<dsw_119> LoadOp1 = db.Load(Query1.OrderByDescending(p => p.dtRecvTime), LoadOp1_Complete, null);
        //    }
        //    else
        //    {
        //        EntityQuery<ds_119> Query = db.GetDs_119Query();
        //        LoadOperation<ds_119> LoadOp = db.Load(Query.Where(p => App.nhomtd.Contains(p.ma_huyen)).OrderByDescending(p => p.dtRecvTime), LoadOp_Complete, null);
        //        EntityQuery<dsw_119> Query1 = db.GetDsw_119Query();
        //        LoadOperation<dsw_119> LoadOp1 = db.Load(Query1.Where(p => App.nhomtd.Contains(p.ma_huyen)).OrderByDescending(p => p.dtRecvTime), LoadOp1_Complete, null);
        //    }
        //}

        void LoadOp_Complete(LoadOperation<ds_119> lo)
        {
            grid.ItemsSource = lo.Entities;
            grid.GroupBy("ma_huyen");
            grid.ExpandAllGroups();
            grid.ShowLoadingPanel = false;
            this.Title = "Danh sách báo hỏng 119 " + " - " + lo.Entities.Count().ToString() + " máy ( danh sách phía trên )";
        }

        void LoadOp1_Complete(LoadOperation<dsw_119> lo)
        {
            grid1.ItemsSource = lo.Entities;
            grid1.GroupBy("ma_huyen");
            grid1.ExpandAllGroups();
            grid1.ShowLoadingPanel = false;
            this.textBlock2.Text = "Các máy chờ sửa " + " - " + lo.Entities.Count().ToString() + " máy";
        }

        private void cmdThem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //if (App.them)
            //{
            frmbao119 frm = new frmbao119();
            frm.Closed += new EventHandler(RefreshDatas);
            frm.Show();
            //}
            //else
            //    MessageBox.Show("Không có quyền thêm dữ liệu !");
        }

        //void GetData(object sender, EventArgs e)
        //{
        //    grid.ShowLoadingPanel = true;
        //    QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        //    InvokeOperation<System.Nullable<int>> p = db.exe
        //    p.Completed += new EventHandler(Completed);
        //}

        private void SuaXong_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (grid.GetFocusedRow() != null)
            {
                //if (App.sua)
                //{
                    string m_dl = grid.GetFocusedRowCellValue(sDamagedPhoneNo).ToString().Trim();                  
                    frmsuaxong119 frm = new frmsuaxong119(m_dl);
                    frm.Closed += new EventHandler(GetData);
                    frm.Show();
                //}
                //else
                //    MessageBox.Show("Không có quyền sửa dữ liệu !");
            }
            else
                MessageBox.Show("Chưa chọn mẫu tin cần sửa !");
        }

        private void SuaXong1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (grid1.GetFocusedRow() != null)
            {
                //if (App.sua)
                //{
                    string m_dl = grid1.GetFocusedRowCellValue(sDamagedPhoneNo1).ToString().Trim();                  
                    frmsuaxong119 frm = new frmsuaxong119(m_dl);
                    frm.Closed += new EventHandler(RefreshDatas);
                    frm.Show();
                //}
                //else
                //    MessageBox.Show("Không có quyền sửa dữ liệu !");
            }
            else
                MessageBox.Show("Chưa chọn mẫu tin cần sửa !");
        }

        void RefreshDatas(object sender, EventArgs e)
        {
            grid.ShowLoadingPanel = true;
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            InvokeOperation<System.Nullable<int>> p = db.Excute_get_119_new();
            p.Completed += new EventHandler(GetData);
        }

        private void EditDataItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //if (grid.GetFocusedRow() != null)
            //{
            //    if (App.sua)
            //    {
            //        string m_dl = grid.GetFocusedRowCellValue(ma_dl).ToString().Trim();
            //        frmnhapdbl frm = new frmnhapdbl(m_dl);
            //        frm.Closed += new EventHandler(frm_Closed);
            //        frm.Show();
            //    }
            //    else
            //        MessageBox.Show("Không có quyền sửa dữ liệu !");
            //}
            //else
            //    MessageBox.Show("Chưa chọn đại lý cần sửa !");
        }

        private void DabaoItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {            
            if (grid.GetFocusedRow() != null)
            {
                string m_dl = grid.GetFocusedRowCellValue(sDamagedPhoneNo).ToString().Trim();
                QLThuebaoDomainContext db = new QLThuebaoDomainContext();
                InvokeOperation<System.Nullable<int>> p = db.Excute_p_Dathongbao_119(m_dl);
                p.Completed += new EventHandler(GetData);          
            }
            else
                MessageBox.Show("Chưa chọn số !");
        }

        private void RefreshDataItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            RefreshData();  
        }

        void RefreshData()
        {
            grid.ShowLoadingPanel = true;
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            InvokeOperation<System.Nullable<int>> p = db.Excute_get_119_new();
            p.Completed += new EventHandler(GetData);
        }

        private void BookRowItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            //frmbooktram frm = new frmbooktram();
            //frm.Width = App.m_ActW;
            //frm.Height = App.m_ActH;
            //frm.ShowDialog();
        }


        private void deleteRowItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (grid.GetFocusedRow() != null)
            {
                if (App.admin_119)
                {
                    string m_dl = grid.GetFocusedRowCellValue(sDamagedPhoneNo).ToString().Trim();
                    //int rowHandle = gridControl1.View.FocusedRowHandle;
                    MessageBoxResult result = MessageBox.Show("Muốn xóa số : " + m_dl + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
                        InvokeOperation<System.Nullable<int>> p = db.Excute_p_Delete_119(m_dl);
                        p.Completed += new EventHandler(RefreshDatas);          
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Không có quyền xóa dữ liệu !");
            }
            else
                MessageBox.Show("Chưa chọn mẫu tin cần xóa !");
        }

        private void sendSMSRowItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (grid.GetFocusedRow() != null)
            {
                //if (App.admin_119)
                //{
                //    string m_dl = grid.GetFocusedRowCellValue(sDamagedPhoneNo).ToString().Trim();
                //    //int rowHandle = gridControl1.View.FocusedRowHandle;
                //    MessageBoxResult result = MessageBox.Show("Muốn xóa số : " + m_dl + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                //    if (result == MessageBoxResult.OK)
                //    {
                //        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
                //        InvokeOperation<System.Nullable<int>> p = db.Excute_p_Delete_119(m_dl);
                //        p.Completed += new EventHandler(GetData);          
                //    }
                //    else
                //        return;
                //}
                //else
                    MessageBox.Show("Chức năng này chưa hoàn thiện !");
            }
            else
                MessageBox.Show("Chưa chọn mẫu tin gửi SMS !");
        }

        private void deleteRowItem1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (grid1.GetFocusedRow() != null)
            {
                if (App.admin_119)
                {
                    string m_dl = grid1.GetFocusedRowCellValue(sDamagedPhoneNo1).ToString().Trim();
                    //int rowHandle = gridControl1.View.FocusedRowHandle;
                    MessageBoxResult result = MessageBox.Show("Muốn xóa số : " + m_dl + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
                        InvokeOperation<System.Nullable<int>> p = db.Excute_p_Delete_119(m_dl);
                        p.Completed += new EventHandler(GetData);
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Không có quyền xóa dữ liệu !");
            }
            else
                MessageBox.Show("Chưa chọn mẫu tin cần xóa !");
        }

    }
}

