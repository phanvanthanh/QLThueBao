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
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;
namespace SilverlightQLThuebao
{
    public partial class frmxaphuong : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<ma_xa> LoadOp;
        public frmxaphuong()
        {
            InitializeComponent();
            dien_dl();
        }

        void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;
            EntityQuery<ma_xa> Query = dstb.GetMa_xaQuery();
            LoadOp = dstb.Load(Query.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten), LoadOp_Complete, null);
        }

        void LoadOp_Complete(LoadOperation<ma_xa> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                gridControl1.ItemsSource = lo.Entities;
            }
            gridControl1.ShowLoadingPanel = false;
        }

        private void cmdThem_Click(object sender, RoutedEventArgs e)
        {
           // this.DialogResult = true;
            frmnhapxa frm = new frmnhapxa(false);
            this.DialogResult = false;
            frm.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            frmnhapxa frm = new frmnhapxa(true);
            frm.txtmaxa.Text = gridControl1.GetFocusedRowCellValue(maxa).ToString().Trim();
            frm.txtmaxa.IsReadOnly = true;
            frm.txtten.Text = gridControl1.GetFocusedRowCellValue(ten).ToString().Trim();
            this.DialogResult = false;
            frm.Show();
        }

        private void cmdXoa_Click(object sender, RoutedEventArgs e)
        {

            if (gridControl1.GetFocusedRow() != null)
            {
                string ma = gridControl1.GetFocusedRowCellValue(maxa).ToString().Trim();
                //int rowHandle = gridControl1.View.FocusedRowHandle;
                MessageBoxResult result = MessageBox.Show("Muốn xóa xã :" + gridControl1.GetFocusedRowCellValue(ten).ToString().Trim() + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    //kiem tra xem trong danh sach thue bao tuyen nay co su dung chua?
                    EntityQuery<maxas> Query = dstb.GetXaQuery(App.ma_huyen, ma);
                    LoadOperation<maxas> LoadOp = dstb.Load(Query, CheckMXCompleted, true);
                    //end kiem tra xem trong danh sach thue bao tuyen nay co su dung chua                    
                }
                else
                    return;

            }
            else
                MessageBox.Show("Chưa chọn nhân viên cần xóa !");
        }
        void CheckMXCompleted(LoadOperation<maxas> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Xã này đã sử dụng trong dữ liệu không thể xóa !");
            }
            else
            {
                string ma = gridControl1.GetFocusedRowCellValue(maxa).ToString().Trim();
                EntityQuery<ma_xa> Query = dstb.GetMa_xaQuery();
                LoadOperation<ma_xa> LoadOp = dstb.Load(Query.Where(p => p.maxa == ma && p.ma_huyen == App.ma_huyen), DeleteCompleted, true);
            }
        }
        private void DeleteCompleted(LoadOperation<ma_xa> lo)
        {
            ma_xa xa = lo.Entities.First();
            dstb.ma_xas.Remove(xa);
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
    }
}

