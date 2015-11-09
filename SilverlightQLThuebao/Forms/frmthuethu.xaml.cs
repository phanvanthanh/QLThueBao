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
    public partial class frmthuethu : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<nv_thuethu> LoadOptuyen;
        public frmthuethu()
        {
            InitializeComponent();
           // FunAndPro.CheckUser(cmdSua);
            FunAndPro.CheckUser(cmdThem);
            FunAndPro.CheckUser(cmdXoa);
            dien_dl();
        }
        void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;
            EntityQuery<nv_thuethu> Queryt = dstb.GetNv_thuethuQuery();
            LoadOptuyen = dstb.Load(Queryt.Where(p => p.ma_huyen == App.ma_huyen && p.ten !=null).OrderBy(p => p.ten), LoadOpTT_Complete, null);
        }

        void LoadOpTT_Complete(LoadOperation<nv_thuethu> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                gridControl1.ItemsSource = lo.Entities;
                gridControl1.ShowLoadingPanel = false;
            }
        }

        private void cmdXoa_Click(object sender, RoutedEventArgs e)
        {
            if (gridControl1.GetFocusedRow() != null)
            {
                string ma = gridControl1.GetFocusedRowCellValue(ten).ToString().Trim();
                //int rowHandle = gridControl1.View.FocusedRowHandle;
                MessageBoxResult result = MessageBox.Show("Muốn xóa nhân viên thu cước :" + ma + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    //kiem tra xem trong danh sach thue bao tuyen nay co su dung chua?
                    EntityQuery<tuyen> Query = dstb.GetTuyenthucuocQuery(App.ma_huyen,ma);
                    LoadOperation<tuyen> LoadOp = dstb.Load(Query, CheckNVCompleted, true);
                    //end kiem tra xem trong danh sach thue bao tuyen nay co su dung chua
                }
                else
                    return;

            }
            else
                MessageBox.Show("Chưa chọn nhân viên cần xóa !");
        }
        void CheckNVCompleted(LoadOperation<tuyen> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Tuyến này đã sử dụng trong dữ liệu không thể xóa !");
            }
            else
            {
                string ma = gridControl1.GetFocusedRowCellValue(ten).ToString().Trim();
                EntityQuery<nv_thuethu> Query = dstb.GetNv_thuethuQuery();
                LoadOperation<nv_thuethu> LoadOp = dstb.Load(Query.Where(p => p.ten.Trim() == ma), DeleteCompleted, true);
            }
        }
        private void DeleteCompleted(LoadOperation<nv_thuethu> lo)
        {
            nv_thuethu nv = lo.Entities.First();
            dstb.nv_thuethus.Remove(nv);
            dstb.SubmitChanges(OnSubmitCompleted, null);
        }
        private void OnSubmitCompleted(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            dien_dl();
        }

        private void cmdThem_Click(object sender, RoutedEventArgs e)
        {
            frmnhapnv nv = new frmnhapnv();
            this.DialogResult=false;
            nv.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
