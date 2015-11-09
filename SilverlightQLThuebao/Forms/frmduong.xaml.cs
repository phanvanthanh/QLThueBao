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
    public partial class frmduong : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<ma_duong> LoadOp;
        public frmduong()
        {
            InitializeComponent();
            dien_dl();
        }

        void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;
            EntityQuery<ma_duong> Query = dstb.GetMa_duongQuery();
           // LoadOp = dstb.Load(Query.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten_duong), LoadOp_Complete, null);
            LoadOp = dstb.Load(Query.OrderBy(p => p.ten_duong), LoadOp_Complete, null);
        }

        void LoadOp_Complete(LoadOperation<ma_duong> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                gridControl1.ItemsSource = lo.Entities;
            }
            gridControl1.ShowLoadingPanel = false;
        }

        private void cmdThem_Click(object sender, RoutedEventArgs e)
        {
            if (txtten.Text.Trim() != "")
            {
                ma_duong xa = new ma_duong
                {
                    ten_duong = txtten.Text.Trim(),
                    ma_huyen = App.ma_huyen
                };
                dstb.ma_duongs.Add(xa);
                dstb.SubmitChanges(OnSubmitCompleted, true);
                txtten.Text = "";
            }
            else
                MessageBox.Show("Chưa nhập tên đường !");
        }        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }     

        private void cmdXoa_Click(object sender, RoutedEventArgs e)
        {

            if (gridControl1.GetFocusedRow() != null)
            {
                int ma = Convert.ToInt32(gridControl1.GetFocusedRowCellValue(id));
                //int rowHandle = gridControl1.View.FocusedRowHandle;
                MessageBoxResult result = MessageBox.Show("Muốn xóa xã :" + gridControl1.GetFocusedRowCellValue(ten_duong).ToString().Trim() + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    //kiem tra xem trong danh sach thue bao tuyen nay co su dung chua?
                    EntityQuery<ma_duong> Query = dstb.GetMa_duongQuery();
                    LoadOperation<ma_duong> LoadOp = dstb.Load(Query.Where(p=>p.id==ma), DeleteCompleted, true);
                    //end kiem tra xem trong danh sach thue bao tuyen nay co su dung chua                    
                }
                else
                    return;

            }
            else
                MessageBox.Show("Chưa chọn nhân viên cần xóa !");
        }
     
        private void DeleteCompleted(LoadOperation<ma_duong> lo)
        {
            ma_duong duong = lo.Entities.First();
            dstb.ma_duongs.Remove(duong);
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

