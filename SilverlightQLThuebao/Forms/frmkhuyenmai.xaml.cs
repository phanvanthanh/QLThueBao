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
    public partial class frmkhuyenmai : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<kh_mai> LoadOp;
        public frmkhuyenmai()
        {
            InitializeComponent();
            dien_dl();
        }

        void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;
            EntityQuery<kh_mai> Query = dstb.GetKh_maiQuery();
            LoadOp = dstb.Load(Query.OrderBy(p => p.ngay_bd), LoadOp_Complete, null);
        }

        void LoadOp_Complete(LoadOperation<kh_mai> lo)
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
            frmnhapkm frm = new frmnhapkm(false);
            this.DialogResult = false;
            frm.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            frmnhapkm frm = new frmnhapkm(true);
            frm.txtmakm.Text = gridControl1.GetFocusedRowCellValue(ma_km).ToString().Trim();
            frm.txtmakm.IsReadOnly = true;
            frm.txtten.Text = gridControl1.GetFocusedRowCellValue(ten_ct).ToString().Trim();
            frm.dbatdau.EditValue = Convert.ToDateTime(gridControl1.GetFocusedRowCellValue(ngay_bd));
            frm.dketthuc.EditValue = Convert.ToDateTime(gridControl1.GetFocusedRowCellValue(ngay_kt));
            this.DialogResult = false;
            frm.Show();
        }

        private void cmdXoa_Click(object sender, RoutedEventArgs e)
        {

            if (gridControl1.GetFocusedRow() != null)
            {
                string ma = gridControl1.GetFocusedRowCellValue(ma_km).ToString().Trim();
                //int rowHandle = gridControl1.View.FocusedRowHandle;
                MessageBoxResult result = MessageBox.Show("Muốn xóa chương trình KM :" + gridControl1.GetFocusedRowCellValue(ten_ct).ToString().Trim() + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    //kiem tra xem trong danh sach thue bao tuyen nay co su dung chua?
                    EntityQuery<ds_codinh> Query = dstb.GetDs_codinhQuery();
                    LoadOperation<ds_codinh> LoadOp = dstb.Load(Query.Where(p=>p.ma_km.Trim()==ma), CheckCDCompleted, true);
                    //end kiem tra xem trong danh sach thue bao tuyen nay co su dung chua                    
                }
                else
                    return;

            }
            else
                MessageBox.Show("Chưa chọn chương trình khuyến mãi cần xóa !");
        }
        void CheckCDCompleted(LoadOperation<ds_codinh> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Chương trình KM này đã sử dụng trong dữ liệu không thể xóa !");
            }
            else
            {
                string ma = gridControl1.GetFocusedRowCellValue(ma_km).ToString().Trim();
                EntityQuery<Gphone> Query = dstb.GetGphonesQuery();
                LoadOperation<Gphone> LoadOp = dstb.Load(Query.Where(p=>p.ma_km.Trim()==ma), CheckGPCompleted, true);
            }
        }

        void CheckGPCompleted(LoadOperation<Gphone> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Chương trình KM này đã sử dụng trong dữ liệu không thể xóa !");
            }
            else
            {
                string ma = gridControl1.GetFocusedRowCellValue(ma_km).ToString().Trim();
                EntityQuery<mytv> Query = dstb.GetMytvsQuery();
                LoadOperation<mytv> LoadOp = dstb.Load(Query.Where(p => p.ma_km.Trim() == ma), CheckMYCompleted, true);
            }
        }

        void CheckMYCompleted(LoadOperation<mytv> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Chương trình KM này đã sử dụng trong dữ liệu không thể xóa !");
            }
            else
            {
                string ma = gridControl1.GetFocusedRowCellValue(ma_km).ToString().Trim();
                EntityQuery<kh_mai> Query = dstb.GetKh_maiQuery();
                LoadOperation<kh_mai> LoadOp = dstb.Load(Query.Where(p => p.ma_km.Trim() == ma), DeleteCompleted, true);
            }
        }     

        private void DeleteCompleted(LoadOperation<kh_mai> lo)
        {
            kh_mai km = lo.Entities.First();
            dstb.kh_mais.Remove(km);
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

