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
    public partial class frmtramvt : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<tram_vt> LoadOp;
        public frmtramvt()
        {
            InitializeComponent();
            dien_dl();
        }

        void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;
            EntityQuery<tram_vt> Query = dstb.GetTram_vtQuery();
            LoadOp = dstb.Load(Query.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten_tram), LoadOp_Complete, null);
        }

        void LoadOp_Complete(LoadOperation<tram_vt> lo)
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
            frmnhaptram frm = new frmnhaptram(false);
            this.DialogResult = false;
            frm.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            frmnhaptram frm = new frmnhaptram(true);
            frm.txtmaxa.Text = gridControl1.GetFocusedRowCellValue(ma_tram).ToString().Trim();
            frm.txtmaxa.IsReadOnly = true;
            frm.txtten.Text = gridControl1.GetFocusedRowCellValue(ten_tram).ToString().Trim();
            this.DialogResult = false;
            frm.Show();
        }

        private void cmdXoa_Click(object sender, RoutedEventArgs e)
        {

            if (gridControl1.GetFocusedRow() != null)
            {
                string ma = gridControl1.GetFocusedRowCellValue(ma_tram).ToString().Trim();
                //int rowHandle = gridControl1.View.FocusedRowHandle;
                MessageBoxResult result = MessageBox.Show("Muốn xóa trạm viễn thông :" + gridControl1.GetFocusedRowCellValue(ten_tram).ToString().Trim() + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    //kiem tra xem trong danh sach thue bao tuyen nay co su dung chua?
                    EntityQuery<matram> Query = dstb.GetTramQuery(App.ma_huyen,ma);
                    LoadOperation<matram> LoadOp = dstb.Load(Query, CheckMTCompleted, true);
                    //end kiem tra xem trong danh sach thue bao tuyen nay co su dung chua                    
                }
                else
                    return;

            }
            else
                MessageBox.Show("Chưa chọn nhân viên cần xóa !");
        }
        void CheckMTCompleted(LoadOperation<matram> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                MessageBox.Show("Trạm này đã sử dụng trong dữ liệu không thể xóa !");
            }
            else
            {
                string ma = gridControl1.GetFocusedRowCellValue(ma_tram).ToString().Trim();
                EntityQuery<tram_vt> Query = dstb.GetTram_vtQuery();
                LoadOperation<tram_vt> LoadOp = dstb.Load(Query.Where(p => p.ma_tram == ma && p.ma_huyen == App.ma_huyen), DeleteCompleted, true);
            }
        }
        private void DeleteCompleted(LoadOperation<tram_vt> lo)
        {
            tram_vt tram = lo.Entities.First();
            dstb.tram_vts.Remove(tram);
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

