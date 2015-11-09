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
    public partial class frmapkhom : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<ma_ap> LoadOp;
        LoadOperation<ma_xa> LoadOpX;
        public frmapkhom()
        {
            InitializeComponent();
            EntityQuery<ma_xa> QueryX = dstb.GetMa_xaQuery();
            LoadOpX = dstb.Load(QueryX.Where(p=>p.ma_huyen==App.ma_huyen).OrderBy(p=>p.ten), LoadOpX_Complete, null);           
        }

        void LoadOpX_Complete(LoadOperation<ma_xa> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbxa.DisplayMember = ("ten").Trim();
                this.cmbxa.ValueMember = "maxa";
                this.cmbxa.ItemsSource = lo.Entities;
                this.cmbxa.SelectedIndex = 0;
                string m_xa = this.cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim();
                dien_dl(m_xa);
            }
        }

        void dien_dl(string m_ma)
        {
            gridControl1.ShowLoadingPanel = true;
            EntityQuery<ma_ap> Query = dstb.GetMa_apQuery();
            LoadOp = dstb.Load(Query.Where(p => p.maxa== m_ma).OrderBy(p => p.ten_ap), LoadOp_Complete, null);
        }

        void LoadOp_Complete(LoadOperation<ma_ap> lo)
        {
            if (lo.Entities.Count() > 0)         
                gridControl1.ItemsSource = lo.Entities;
            gridControl1.ShowLoadingPanel = false;
        }

        private void cmdThem_Click(object sender, RoutedEventArgs e)
        {
           // this.DialogResult = true;
            frmnhapap frm = new frmnhapap(false, cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim());
            frm.txtghichu.Text = cmbxa.Text;
            this.DialogResult = false;
            frm.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            frmnhapap frm = new frmnhapap(true, cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim());
            frm.txtmaap.Text = gridControl1.GetFocusedRowCellValue(maap).ToString().Trim();
            frm.txtmaap.IsReadOnly = true;
            frm.txtten.Text = gridControl1.GetFocusedRowCellValue(ten_ap).ToString().Trim();
            frm.txtghichu.Text = cmbxa.Text;
            this.DialogResult = false;
            frm.Show();
        }

        private void cmdXoa_Click(object sender, RoutedEventArgs e)
        {

            if (gridControl1.GetFocusedRow() != null)
            {
                string ma = gridControl1.GetFocusedRowCellValue(maap).ToString().Trim();
                //int rowHandle = gridControl1.View.FocusedRowHandle;
                MessageBoxResult result = MessageBox.Show("Muốn xóa ấp :" + gridControl1.GetFocusedRowCellValue(ten_ap).ToString().Trim() + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    //kiem tra xem trong danh sach thue bao tuyen nay co su dung chua?
                    EntityQuery<ma_ap> Query = dstb.GetMa_apQuery();
                    LoadOperation<ma_ap> LoadOp = dstb.Load(Query.Where(p => p.maap == ma), DeleteCompleted, true);
                    //end kiem tra xem trong danh sach thue bao tuyen nay co su dung chua                    
                }
                else
                    return;

            }
            else
                MessageBox.Show("Chưa chọn nhân viên cần xóa !");
        }
     
        private void DeleteCompleted(LoadOperation<ma_ap> lo)
        {
            ma_ap ap = lo.Entities.First();
            dstb.ma_aps.Remove(ap);
            dstb.SubmitChanges(OnSubmitCompleted, null);
        }

        private void OnSubmitCompleted(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
            {
                string m_xa = this.cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim();
                if (m_xa != "")               
                   dien_dl(m_xa);                        
            }
        }

        private void cmbxa_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            string m_xa = cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim();
            if (m_xa != "")          
                dien_dl(m_xa);            
        }
    }
}

