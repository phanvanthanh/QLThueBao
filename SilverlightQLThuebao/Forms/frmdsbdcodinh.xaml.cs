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
    public partial class frmdsbdcodinh : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<ds_codinh> LoadOp;
        public frmdsbdcodinh()
        {
            InitializeComponent();
            FunAndPro.CheckUser(cmdSua);
            dthangbd.EditValue = App.Current_d;            
            dien_dl();
        }
        public void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;
            string m_thangbd = dthangbd.DateTime.Month < 10 ? dthangbd.DateTime.Month.ToString().PadLeft(2, '0') : dthangbd.DateTime.Month.ToString(); 
            m_thangbd += dthangbd.DateTime.Year.ToString();                        
            EntityQuery<ds_codinh> Query = dstb.GetDs_codinhQuery();
            LoadOp = dstb.Load(Query.Where(p => p.ma_huyen == App.ma_huyen && p.thangbd==m_thangbd), LoadOp_Complete, null);
        }
        void LoadOp_Complete(LoadOperation<ds_codinh> lo)
        {
            //if (lo.Entities.Count() > 0)
            //{
            gridControl1.ItemsSource = lo.Entities;
                //dataPager1.Source = lo.Entities;
                //PagedCollectionView pagedCollectionView = new PagedCollectionView(lo.Entities);                
                //dataPager1.Source = pagedCollectionView;
                //dataPager1.PageSize = 200;
                //gridControl1.ItemsSource = DevExpress.Xpf.Core.Native.DataBindingHelper.ExtractDataSourceFromCollectionView(dataPager1.Source);
                this.Title = "Danh sách biến động thuê bao cố định - " + lo.Entities.Count().ToString();
            //}            

            gridControl1.ShowLoadingPanel = false;
        }

        private void cmdSua_Click(object sender, RoutedEventArgs e)
        {
            FunAndPro callF = new FunAndPro();
            callF.GetDateTime();
            Nullable<DateTime> m_ngayhd, m_ngaykn, m_ngayld, m_ngaycap;          
             if (LoadOp.Entities.Count() > 0)
              {
                  MessageBoxResult result = MessageBox.Show("Muốn thay tiền thuê bao tháng này bằng thuê bao tháng kế ?", "Xác nhận", MessageBoxButton.OKCancel);
                  if (result == MessageBoxResult.OK)
                  {
                      gridControl1.ShowLoadingPanel = true;
                     for (int i = 0; i < LoadOp.Entities.Count(); i++)
                     {
                         LoadOp.Entities.ElementAt(i).tien_tb = LoadOp.Entities.ElementAt(i).tienno == null ? 0 : LoadOp.Entities.ElementAt(i).tienno;

                         if (LoadOp.Entities.ElementAt(i).ngay_hd.HasValue)
                             m_ngayhd = LoadOp.Entities.ElementAt(i).ngay_hd;
                         else
                             m_ngayhd = null;

                         if (LoadOp.Entities.ElementAt(i).ngay_kn.HasValue)
                             m_ngaykn = LoadOp.Entities.ElementAt(i).ngay_kn;
                         else
                             m_ngaykn = null;

                         if (LoadOp.Entities.ElementAt(i).ngay_ld.HasValue)
                             m_ngayld = LoadOp.Entities.ElementAt(i).ngay_ld;
                         else
                             m_ngayld = null;

                         if (LoadOp.Entities.ElementAt(i).ngay_cap.HasValue)
                             m_ngaycap = LoadOp.Entities.ElementAt(i).ngay_cap;
                         else
                             m_ngaycap = null;
       

                         codinh_log dsl = new codinh_log
                         {
                             so_dt = LoadOp.Entities.ElementAt(i).so_dt,
                             ten_dktb = LoadOp.Entities.ElementAt(i).ten_dktb == null ? "" : LoadOp.Entities.ElementAt(i).ten_dktb,
                             ten_dkdb = LoadOp.Entities.ElementAt(i).ten_dkdb == null ? "" : LoadOp.Entities.ElementAt(i).ten_dkdb,
                             dia_chitb = LoadOp.Entities.ElementAt(i).dia_chitb == null ? "" : LoadOp.Entities.ElementAt(i).dia_chitb,
                             dc_tbld = LoadOp.Entities.ElementAt(i).dc_tbld == null ? "" : LoadOp.Entities.ElementAt(i).dc_tbld,
                             tuyen_tc = LoadOp.Entities.ElementAt(i).tuyen_tc == null ? "" : LoadOp.Entities.ElementAt(i).tuyen_tc,
                             tien_tb = LoadOp.Entities.ElementAt(i).tien_tb,
                             tb_dv = LoadOp.Entities.ElementAt(i).tb_dv,
                             tienno = LoadOp.Entities.ElementAt(i).tienno,
                             khg_vat = LoadOp.Entities.ElementAt(i).khg_vat,
                             ma_tram = LoadOp.Entities.ElementAt(i).ma_tram,
                             pl = LoadOp.Entities.ElementAt(i).pl,
                             may_ngung = LoadOp.Entities.ElementAt(i).may_ngung,
                             ma_huyen = LoadOp.Entities.ElementAt(i).ma_huyen,
                             sohopdong = LoadOp.Entities.ElementAt(i).sohopdong,
                             ngay_hd = m_ngayhd,
                             ngay_ld = m_ngayld,
                             village = LoadOp.Entities.ElementAt(i).village,
                             ma_kh = LoadOp.Entities.ElementAt(i).ma_kh,
                             ngay_kn = m_ngaykn,
                             note_ngay_kn = LoadOp.Entities.ElementAt(i).note_ngay_kn,
                             ms_thue = LoadOp.Entities.ElementAt(i).ms_thue,
                             socmnd = LoadOp.Entities.ElementAt(i).socmnd,
                             noi_cap = LoadOp.Entities.ElementAt(i).noi_cap,
                             ngay_cap = m_ngaycap,
                             e_mail = LoadOp.Entities.ElementAt(i).e_mail,
                             thoi_gian = App.Current_d,
                             ma_km = LoadOp.Entities.ElementAt(i).ma_km,
                             users = App.User_name
                         };

                         dstb.codinh_logs.Add(dsl);

                     }
                     dstb.SubmitChanges(OnSubmitCompleted, true);
                  }
              }           
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
                gridControl1.ShowLoadingPanel = false;
                MessageBox.Show("Đã thay tiền thuê bao xong");               
            }
        }



        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            dien_dl();
        }

        //void Tim()
        //{
        //    gridControl1.ShowLoadingPanel = true;
        //    for (int i = 0; i < dataPager1.PageCount; i++)
        //    {
        //        dataPager1.PageIndex = i;
        //        for (int j = 0; j < gridControl1.VisibleRowCount; j++)
        //        {
        //            int rowHandle = gridControl1.GetRowHandleByVisibleIndex(j);
        //            if (gridControl1.GetCellValue(rowHandle, sodt).ToString().Trim() == this.txttim.Text.Trim())
        //            {
        //                gridControl1.ShowLoadingPanel = false;
        //                gridControl1.View.FocusedRowHandle = rowHandle;
        //                return;
        //            }
        //        }
        //    }
        //}

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            
            sua();
        }

        void sua()
        {
            if (App.sua)
            {              
                string sdt = gridControl1.GetFocusedRowCellValue(sodt).ToString().Trim();
               // txttim.Text = sdt;
                frmeditcd editcd = new frmeditcd(false, sdt,2);
                editcd.txtsdt.Text = sdt;
                this.Hide();
                editcd.Show();                
            }
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
                
                if (gridControl1.GetCellValue(rowHandle, sodt).ToString().Trim() == this.txttim.Text.Trim())
                {                   
                    gridControl1.ShowLoadingPanel = false;
                    gridControl1.View.FocusedRowHandle = rowHandle;
                    gridControl1.View.MoveFocusedRow(rowHandle);
                    return;
                }
            }
            MessageBox.Show("Không tìm thấy số điện thoại " + this.txttim.Text.Trim() +" trong danh sách này !");
            gridControl1.ShowLoadingPanel = false;
        }
    }
}
