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
    public partial class frmcscodinh : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<ma_diaban> LoadOptuyen;
        LoadOperation<tram_vt> LoadOptram;
        LoadOperation<ma_xa> LoadOpxa;
        LoadOperation<ds_codinh> LoadOpS;        
        string sdt,m_tuyen;
        string m_tram;
        string S_null;
        public frmcscodinh()
        {
            InitializeComponent();
            FunAndPro.CheckUser(cmdSua);
           // FunAndPro.CheckUser(cmdCat);            
           // dien_dl();           
            EntityQuery<ma_diaban> Queryt = dstb.GetMa_diabanQuery();
            LoadOptuyen = dstb.Load(Queryt.Where(p => p.ma_huyen == App.ma_huyen && p.kt == false).OrderBy(p => p.ten_tuyen), LoadOpTT_Complete, null);

            EntityQuery<tram_vt> Query = dstb.GetTram_vtQuery();
            LoadOptram = dstb.Load(Query.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten_tram), LoadOpTR_Complete, null);

            EntityQuery<ma_xa> Queryx = dstb.GetMa_xaQuery();
            LoadOpxa = dstb.Load(Queryx.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten), LoadOpXA_Complete, null);
          
        }

        void LoadOpTT_Complete(LoadOperation<ma_diaban> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbtuyen.ItemsSource = lo.Entities;
                this.cmbtuyen.DisplayMember = ("ten_tuyen").Trim();
                this.cmbtuyen.ValueMember = "ma_tuyen";                                
            }
        }

        void LoadOpTR_Complete(LoadOperation<tram_vt> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbtram.ItemsSource = lo.Entities;
                this.cmbtram.DisplayMember = ("ten_tram").Trim();
                this.cmbtram.ValueMember = "ma_tram";
            }
        }

        void LoadOpXA_Complete(LoadOperation<ma_xa> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbxa.ItemsSource = lo.Entities;
                this.cmbxa.DisplayMember = ("ten").Trim();
                this.cmbxa.ValueMember = "maxa";
                cmbxa.SelectedIndex = 0;
                dien_dl(cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim());
            }
        }

        public void dien_dl(string m_xa)
        {         
            gridControl1.ShowLoadingPanel = true;
            this.gridControl1.ItemsSource = new TuyenCSKH(); // lay bang rong dua vao
            tableView1.DeleteRow(0);            

            EntityQuery<ds_codinh> QueryC = dstb.GetDs_codinhQuery();
            LoadOpS = dstb.Load(QueryC.Where(p => p.ma_huyen == App.ma_huyen && p.village.Trim()==m_xa).OrderBy(p => p.so_dt), LoadOp_Complete,true);
           
        }
        void LoadOp_Complete(LoadOperation<ds_codinh> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                //gridControl1.ItemsSource = lo.Entities;

                for (int i = 0; i < lo.Entities.Count(); i++)
                {
                    (this.gridControl1.ItemsSource as TuyenCSKH).Add(new tuyencskh
                    {
                        so_dt = lo.Entities.ElementAt(i).so_dt,
                        ma_kh = lo.Entities.ElementAt(i).ma_kh,
                        ten_dktb = lo.Entities.ElementAt(i).ten_dktb == null ? "" : lo.Entities.ElementAt(i).ten_dktb,
                        ten_dkdb = lo.Entities.ElementAt(i).ten_dkdb == null ? "" :lo.Entities.ElementAt(i).ten_dkdb,
                        dia_chitb = lo.Entities.ElementAt(i).dia_chitb == null ? "" :lo.Entities.ElementAt(i).dia_chitb,
                        dc_tbld = lo.Entities.ElementAt(i).dc_tbld == null ? "" : lo.Entities.ElementAt(i).dc_tbld,
                        ma_tram = lo.Entities.ElementAt(i).ma_tram == null ? "" : lo.Entities.ElementAt(i).ma_tram,
                        ma_nvcs = lo.Entities.ElementAt(i).ma_nvcs == null ? "" : lo.Entities.ElementAt(i).ma_nvcs
                    });
                    gridControl1.ShowLoadingPanel = false;
                }
               
                gridControl1.ShowLoadingPanel = false;
                //if (txttim.Text.Trim() != "")
                //    Tim();                    
            }
            gridControl1.ShowLoadingPanel = false;
            this.Title = "Danh Chăm sóc khách hàng : " + lo.Entities.Count().ToString();
        }

        private void cmdSua_Click(object sender, RoutedEventArgs e)
        {
            SaveDate();
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
            for (int j = 0; j < gridControl1.VisibleRowCount; j++)
                {
                    int rowHandle = gridControl1.GetRowHandleByVisibleIndex(j);
                    if (gridControl1.GetCellValue(rowHandle, sodt).ToString().Trim() == this.txttim.Text.Trim())
                    {
                       // gridControl1.ShowLoadingPanel = false;
                        gridControl1.View.FocusedRowHandle = rowHandle;
                        return;
                    }
                }
            MessageBox.Show("Không tìm thấy thông tin trong tuyến này !");
            gridControl1.ShowLoadingPanel = false;
        }

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {            
           // sua();
        }

        void SaveDate()
        {  
            gridControl1.ShowLoadingPanel = true;
            for (int i = 0; i < gridControl1.VisibleRowCount; i++)
            {
                sdt = gridControl1.GetCellValue(i, sodt).ToString().Trim();
                m_tram = (gridControl1.GetCellValue(i, ma_tram) == null || gridControl1.GetCellValue(i, ma_tram).ToString().Trim() == "") ? S_null : gridControl1.GetCellValue(i, ma_tram).ToString();
                m_tuyen = (gridControl1.GetCellValue(i, ma_nvcs) == null || gridControl1.GetCellValue(i, ma_nvcs).ToString().Trim() == "") ? S_null : gridControl1.GetCellValue(i, ma_nvcs).ToString();
                // Update ds_codinh
                for (int j = 0; j < LoadOpS.Entities.Count(); j++)
                {
                    if (LoadOpS.Entities.ElementAt(j).so_dt.Trim() == sdt)
                    {
                        LoadOpS.Entities.ElementAt(j).ma_tram = m_tram;
                        LoadOpS.Entities.ElementAt(j).ma_nvcs = m_tuyen;
                        break;                    
                    }
                }              
            }
            dstb.SubmitChanges(OnSubmitCompleted, true);
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
                MessageBox.Show("Đã lưu thay đổi !");
                //this.Hide();
                //frmdscodinh frmtuyen = new frmdscodinh();
                //frmtuyen.Width = this.ActualWidth;
                //frmtuyen.Height = this.ActualHeight;
                //frmtuyen.Show();
            }
        }
     

        private void XemButton_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show(cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim());
            dien_dl(cmbxa.GetKeyValue(cmbxa.SelectedIndex).ToString().Trim());
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
