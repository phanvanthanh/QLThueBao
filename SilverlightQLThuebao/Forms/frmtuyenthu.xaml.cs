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
    public partial class frmtuyenthu : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<nv_thuethu> LoadOptuyen;
        LoadOperation<tuyen> LoadOp;
        LoadOperation<ds_codinh> LoadOpS;
        LoadOperation<Gphone> LoadOpG;
        LoadOperation<mytv> LoadOpM;
        LoadOperation<internet> LoadOpI; 
        string sdt,m_tuyen;
        decimal m_stt;        
        public frmtuyenthu(string tuyen)
        {
            InitializeComponent();
            FunAndPro.CheckUser(cmdSua);
           // FunAndPro.CheckUser(cmdCat);
            m_tuyen = tuyen;
           // dien_dl();           
            EntityQuery<nv_thuethu> Queryt = dstb.GetNv_thuethuQuery();
            LoadOptuyen = dstb.Load(Queryt.Where(p => p.ma_huyen == App.ma_huyen).OrderBy(p => p.ten), LoadOpTT_Complete, null);
          
        }

        void LoadOpTT_Complete(LoadOperation<nv_thuethu> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbtuyen.ItemsSource = lo.Entities;
                this.cmbtuyen.DisplayMember = ("ten").Trim();
                this.cmbtuyen.ValueMember = "ten";
                this.cmbtuyen1.ItemsSource = lo.Entities;
                this.cmbtuyen1.DisplayMember = ("ten").Trim();
                this.cmbtuyen1.ValueMember = "ten";
                if (m_tuyen != "")
                {
                     for (int i = 0; i < LoadOptuyen.Entities.Count(); i++)
                    {
                        if (cmbtuyen.GetKeyValue(i).ToString().Trim() == m_tuyen)
                        {
                            cmbtuyen.SelectedIndex = i;
                        }
                    }
                }
                else                
                    this.cmbtuyen.SelectedIndex = 0;
                dien_dl(cmbtuyen.Text.Trim());

            }
        }

        public void dien_dl(string m_tuyen)
        {         
            gridControl1.ShowLoadingPanel = true;
            this.gridControl1.ItemsSource = new TuyenList(); // lay bang rong dua vao
            tableView1.DeleteRow(0);            

            EntityQuery<ds_codinh> QueryC = dstb.GetDs_codinhQuery();
            LoadOpS = dstb.Load(QueryC.Where(p => p.tuyen_tc.Trim() == m_tuyen && p.ma_kh.Substring(0, 7) == App.batdau_mkh));

            EntityQuery<Gphone> QueryG = dstb.GetGphonesQuery();
            LoadOpG = dstb.Load(QueryG.Where(p => p.tuyen_tc.Trim() == m_tuyen && p.ma_kh.Substring(0, 7) == App.batdau_mkh));

            EntityQuery<mytv> QueryM = dstb.GetMytvsQuery();
            LoadOpM = dstb.Load(QueryM.Where(p => p.tuyen_tc.Trim() == m_tuyen && p.ma_kh.Substring(0, 7) == App.batdau_mkh));

            EntityQuery<internet> QueryI = dstb.GetInternetsQuery();
            LoadOpI = dstb.Load(QueryI.Where(p => p.tuyen_tc.Trim() == m_tuyen && p.ma_kh.Substring(0, 7) == App.batdau_mkh));
                        
            EntityQuery<tuyen> Query = dstb.GetTuyenthucuocQuery(App.ma_huyen, m_tuyen);
            LoadOp = dstb.Load(Query, LoadOp_Complete, null);
        }
        void LoadOp_Complete(LoadOperation<tuyen> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                //gridControl1.ItemsSource = lo.Entities;

                for (int i = 0; i < lo.Entities.Count(); i++)
                {
                    (this.gridControl1.ItemsSource as TuyenList).Add(new tuyen()
                    {
                        so_dt = lo.Entities.ElementAt(i).so_dt,
                        ma_kh = lo.Entities.ElementAt(i).ma_kh,
                        ten_dktb = lo.Entities.ElementAt(i).ten_dktb,
                        ten_dkdb = lo.Entities.ElementAt(i).ten_dkdb,
                        dia_chitb = lo.Entities.ElementAt(i).dia_chitb,
                        dc_tbld = lo.Entities.ElementAt(i).dc_tbld,
                        tuyen_tc = lo.Entities.ElementAt(i).tuyen_tc,
                        stt = lo.Entities.ElementAt(i).stt
                    });
                }
               
                gridControl1.ShowLoadingPanel = false;
                //if (txttim.Text.Trim() != "")
                //    Tim();                    
            }
            gridControl1.ShowLoadingPanel = false;
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
                        gridControl1.ShowLoadingPanel = false;
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
            FunAndPro callF = new FunAndPro();
            callF.GetDateTime();
            Nullable<DateTime> m_ngayhd, m_ngaykn, m_ngayld, m_ngaycap;
            decimal m_stt1;
            gridControl1.ShowLoadingPanel = true;
            for (int i = 0; i < gridControl1.VisibleRowCount; i++)
            {
                sdt = gridControl1.GetCellValue(i, sodt).ToString().Trim();
                m_stt = (gridControl1.GetCellValue(i, stt) == null || gridControl1.GetCellValue(i, stt).ToString().Trim() == "") ? 0 : Convert.ToDecimal(gridControl1.GetCellValue(i, stt));
                m_tuyen = gridControl1.GetCellValue(i, tuyen_tc).ToString().Trim();                
               // Update ds_codinh
                for (int j = 0; j < LoadOpS.Entities.Count(); j++)
                {
                    if (LoadOpS.Entities.ElementAt(j).so_dt.Trim() == sdt)
                    {
                        m_stt1 = (LoadOpS.Entities.ElementAt(j).stt == null || LoadOpS.Entities.ElementAt(j).stt.ToString().Trim() == "") ? 0 : Convert.ToDecimal(LoadOpS.Entities.ElementAt(j).stt);
                        if (LoadOpS.Entities.ElementAt(j).tuyen_tc.Trim() != m_tuyen || m_stt1 != m_stt)
                        {                          
                            LoadOpS.Entities.ElementAt(j).stt = m_stt;
                            LoadOpS.Entities.ElementAt(j).tuyen_tc = m_tuyen;

                            if (LoadOpS.Entities.ElementAt(j).ngay_hd.HasValue)
                                m_ngayhd = LoadOpS.Entities.ElementAt(j).ngay_hd;
                            else
                                m_ngayhd = null;

                            if (LoadOpS.Entities.ElementAt(j).ngay_kn.HasValue)
                                m_ngaykn = LoadOpS.Entities.ElementAt(j).ngay_kn;
                            else
                                m_ngaykn = null;

                            if (LoadOpS.Entities.ElementAt(j).ngay_ld.HasValue)
                                m_ngayld = LoadOpS.Entities.ElementAt(j).ngay_ld;
                            else
                                m_ngayld = null;

                            if (LoadOpS.Entities.ElementAt(j).ngay_cap.HasValue)
                                m_ngaycap = LoadOpS.Entities.ElementAt(j).ngay_cap;
                            else
                                m_ngaycap = null;


                            codinh_log dsl = new codinh_log
                            {
                                so_dt = LoadOpS.Entities.ElementAt(j).so_dt,
                                ten_dktb = LoadOpS.Entities.ElementAt(j).ten_dktb == null ? "" : LoadOpS.Entities.ElementAt(j).ten_dktb,
                                ten_dkdb = LoadOpS.Entities.ElementAt(j).ten_dkdb == null ? "" : LoadOpS.Entities.ElementAt(j).ten_dkdb,
                                dia_chitb = LoadOpS.Entities.ElementAt(j).dia_chitb == null ? "" : LoadOpS.Entities.ElementAt(j).dia_chitb,
                                dc_tbld = LoadOpS.Entities.ElementAt(j).dc_tbld == null ? "" : LoadOpS.Entities.ElementAt(j).dc_tbld,
                                tuyen_tc = m_tuyen,
                                stt = m_stt,
                                tien_tb = LoadOpS.Entities.ElementAt(j).tien_tb == null ? j : LoadOpS.Entities.ElementAt(j).tien_tb,
                                tb_dv = LoadOpS.Entities.ElementAt(j).tb_dv == null ? j : LoadOpS.Entities.ElementAt(j).tb_dv,
                                tienno = LoadOpS.Entities.ElementAt(j).tienno == null ? j : LoadOpS.Entities.ElementAt(j).tienno,
                                khg_vat = LoadOpS.Entities.ElementAt(j).khg_vat == null ? false : LoadOpS.Entities.ElementAt(j).khg_vat,
                                ma_tram = LoadOpS.Entities.ElementAt(j).ma_tram,
                                pl = LoadOpS.Entities.ElementAt(j).pl,
                                may_ngung = LoadOpS.Entities.ElementAt(j).may_ngung,
                                ma_huyen = LoadOpS.Entities.ElementAt(j).ma_huyen,
                                sohopdong = LoadOpS.Entities.ElementAt(j).sohopdong,
                                ngay_hd = m_ngayhd,
                                ngay_ld = m_ngayld,
                                village = LoadOpS.Entities.ElementAt(j).village,
                                ma_kh = LoadOpS.Entities.ElementAt(j).ma_kh,
                                ngay_kn = m_ngaykn,
                                note_ngay_kn = LoadOpS.Entities.ElementAt(j).note_ngay_kn,
                                ms_thue = LoadOpS.Entities.ElementAt(j).ms_thue,
                                socmnd = LoadOpS.Entities.ElementAt(j).socmnd,
                                noi_cap = LoadOpS.Entities.ElementAt(j).noi_cap,
                                ngay_cap = m_ngaycap,
                                e_mail = LoadOpS.Entities.ElementAt(j).e_mail,
                                thoi_gian = App.Current_d,
                                ma_km = LoadOpS.Entities.ElementAt(j).ma_km,
                                users = App.User_name
                            };
                            dstb.codinh_logs.Add(dsl);
                            break;
                        }
                    }
                }

                for (int k = 0; k < LoadOpG.Entities.Count(); k++)
                {
                    if (LoadOpG.Entities.ElementAt(k).so_dt == sdt)
                    {
                        if (LoadOpG.Entities.ElementAt(k).tuyen_tc.Trim() != m_tuyen || LoadOpG.Entities.ElementAt(k).stt != m_stt)
                        {
                            LoadOpG.Entities.ElementAt(k).stt = m_stt;
                            LoadOpG.Entities.ElementAt(k).tuyen_tc = m_tuyen;

                            if (LoadOpG.Entities.ElementAt(k).ngay_hd.HasValue)
                                m_ngayhd = LoadOpG.Entities.ElementAt(k).ngay_hd;
                            else
                                m_ngayhd = null;

                            if (LoadOpG.Entities.ElementAt(k).ngay_kn.HasValue)
                                m_ngaykn = LoadOpG.Entities.ElementAt(k).ngay_kn;
                            else
                                m_ngaykn = null;

                            if (LoadOpG.Entities.ElementAt(k).ngay_ld.HasValue)
                                m_ngayld = LoadOpG.Entities.ElementAt(k).ngay_ld;
                            else
                                m_ngayld = null;

                            if (LoadOpG.Entities.ElementAt(k).ngay_cap.HasValue)
                                m_ngaycap = LoadOpG.Entities.ElementAt(k).ngay_cap;
                            else
                                m_ngaycap = null;


                            Gphone_log dsl = new Gphone_log
                            {
                                so_dt = LoadOpG.Entities.ElementAt(k).so_dt,
                                ten_dktb = LoadOpG.Entities.ElementAt(k).ten_dktb == null ? "" : LoadOpG.Entities.ElementAt(k).ten_dktb,
                                ten_dkdb = LoadOpG.Entities.ElementAt(k).ten_dkdb == null ? "" : LoadOpG.Entities.ElementAt(k).ten_dkdb,
                                dia_chitb = LoadOpG.Entities.ElementAt(k).dia_chitb == null ? "" : LoadOpG.Entities.ElementAt(k).dia_chitb,
                                dc_tbld = LoadOpG.Entities.ElementAt(k).dc_tbld == null ? "" : LoadOpG.Entities.ElementAt(k).dc_tbld,
                                tuyen_tc = m_tuyen,
                                stt = m_stt,
                                tien_tb = LoadOpG.Entities.ElementAt(k).tien_tb,
                                tb_dv = LoadOpG.Entities.ElementAt(k).tb_dv,
                                tienno = LoadOpG.Entities.ElementAt(k).tienno,
                                khg_vat = LoadOpG.Entities.ElementAt(k).khg_vat,
                                pl = LoadOpG.Entities.ElementAt(k).pl,
                                may_ngung = LoadOpG.Entities.ElementAt(k).may_ngung,
                                ma_huyen = LoadOpG.Entities.ElementAt(k).ma_huyen,
                                sohopdong = LoadOpG.Entities.ElementAt(k).sohopdong,
                                ngay_hd = m_ngayhd,
                                ngay_ld = m_ngayld,
                                village = LoadOpG.Entities.ElementAt(k).village,
                                ma_kh = LoadOpG.Entities.ElementAt(k).ma_kh,
                                ngay_kn = m_ngaykn,
                                note_ngay_kn = LoadOpG.Entities.ElementAt(k).note_ngay_kn,
                                ms_thue = LoadOpG.Entities.ElementAt(k).ms_thue,
                                socmnd = LoadOpG.Entities.ElementAt(k).socmnd,
                                noi_cap = LoadOpG.Entities.ElementAt(k).noi_cap,
                                ngay_cap = m_ngaycap,
                                e_mail = LoadOpG.Entities.ElementAt(k).e_mail,
                                thoi_gian = App.Current_d,
                                ma_km = LoadOpG.Entities.ElementAt(k).ma_km,
                                users = App.User_name
                            };

                            dstb.Gphone_logs.Add(dsl);  

                        }
                    }
                }

                for (int l = 0; l < LoadOpM.Entities.Count(); l++)
                {
                    if (LoadOpM.Entities.ElementAt(l).user_name.Trim() == sdt)
                    {
                        if (LoadOpM.Entities.ElementAt(l).tuyen_tc.Trim() != m_tuyen || LoadOpM.Entities.ElementAt(l).stt != m_stt)
                        {
                            LoadOpM.Entities.ElementAt(l).stt = m_stt;
                            LoadOpM.Entities.ElementAt(l).tuyen_tc = m_tuyen;

                            if (LoadOpM.Entities.ElementAt(l).ngay_hd.HasValue)
                                m_ngayhd = LoadOpM.Entities.ElementAt(l).ngay_hd;
                            else
                                m_ngayhd = null;

                            if (LoadOpM.Entities.ElementAt(l).ngay_kn.HasValue)
                                m_ngaykn = LoadOpM.Entities.ElementAt(l).ngay_kn;
                            else
                                m_ngaykn = null;

                            if (LoadOpM.Entities.ElementAt(l).ngay_ld.HasValue)
                                m_ngayld = LoadOpM.Entities.ElementAt(l).ngay_ld;
                            else
                                m_ngayld = null;

                            if (LoadOpM.Entities.ElementAt(l).ngay_cap.HasValue)
                                m_ngaycap = LoadOpM.Entities.ElementAt(l).ngay_cap;
                            else
                                m_ngaycap = null;


                            mytv_log dsl = new mytv_log
                            {
                                user_name = LoadOpM.Entities.ElementAt(l).user_name,
                                ten_dktb = LoadOpM.Entities.ElementAt(l).ten_dktb == null ? "" : LoadOpM.Entities.ElementAt(l).ten_dktb,
                                ten_dkdb = LoadOpM.Entities.ElementAt(l).ten_dkdb == null ? "" : LoadOpM.Entities.ElementAt(l).ten_dkdb,
                                dia_chitb = LoadOpM.Entities.ElementAt(l).dia_chitb == null ? "" : LoadOpM.Entities.ElementAt(l).dia_chitb,
                                dc_tbld = LoadOpM.Entities.ElementAt(l).dc_tbld == null ? "" : LoadOpM.Entities.ElementAt(l).dc_tbld,
                                sohopdong = LoadOpM.Entities.ElementAt(l).sohopdong,
                                ngay_hd = m_ngayhd,
                                ngay_ld = m_ngayld,
                                tuyen_tc = m_tuyen,
                                stt = m_stt,
                                goi_cuoc = LoadOpM.Entities.ElementAt(l).goi_cuoc,
                                so_dt = LoadOpM.Entities.ElementAt(l).so_dt == null ? "" : LoadOpM.Entities.ElementAt(l).so_dt,
                                stb_serial = LoadOpM.Entities.ElementAt(l).stb_serial == null ? "" : LoadOpM.Entities.ElementAt(l).stb_serial,
                                loai_cap = LoadOpM.Entities.ElementAt(l).loai_cap == null ? "" : LoadOpM.Entities.ElementAt(l).loai_cap,
                                ht_ld = LoadOpM.Entities.ElementAt(l).ht_ld == null ? "" : LoadOpM.Entities.ElementAt(l).ht_ld,
                                ma_huyen = App.ma_huyen,
                                socmnd = LoadOpM.Entities.ElementAt(l).socmnd == null ? "" : LoadOpM.Entities.ElementAt(l).socmnd,
                                noi_cap = LoadOpM.Entities.ElementAt(l).noi_cap == null ? "" : LoadOpM.Entities.ElementAt(l).noi_cap,
                                ngay_cap = m_ngaycap,
                                ma_kh = LoadOpM.Entities.ElementAt(l).ma_kh,
                                pl = LoadOpM.Entities.ElementAt(l).pl == null ? "" : LoadOpM.Entities.ElementAt(l).pl,
                                ngay_kn = m_ngaykn,
                                note_ngay_kn = LoadOpM.Entities.ElementAt(l).note_ngay_kn == null ? "" : LoadOpM.Entities.ElementAt(l).note_ngay_kn,
                                ms_thue = LoadOpM.Entities.ElementAt(l).ms_thue == null ? "" : LoadOpM.Entities.ElementAt(l).ms_thue,
                                ngan_hang = LoadOpM.Entities.ElementAt(l).ngan_hang == null ? "" : LoadOpM.Entities.ElementAt(l).ngan_hang,
                                ma_km = LoadOpM.Entities.ElementAt(l).ma_km == null ? "" : LoadOpM.Entities.ElementAt(l).ma_km,
                                user_login = App.User_name,
                                thoi_gian = App.Current_d
                            };
                            dstb.mytv_logs.Add(dsl);
                        }
                    }
                } 
              // update internet

                for (int m = 0; m < LoadOpI.Entities.Count(); m++)
                {
                    if (LoadOpI.Entities.ElementAt(m).user_name.Trim() == sdt)
                    {
                        if (LoadOpI.Entities.ElementAt(m).tuyen_tc.Trim() != m_tuyen || LoadOpI.Entities.ElementAt(m).stt != m_stt)
                        {
                            LoadOpI.Entities.ElementAt(m).stt = m_stt;
                            LoadOpI.Entities.ElementAt(m).tuyen_tc = m_tuyen;

                            if (LoadOpI.Entities.ElementAt(m).ngay_hd.HasValue)
                                m_ngayhd = LoadOpI.Entities.ElementAt(m).ngay_hd;
                            else
                                m_ngayhd = null;

                            if (LoadOpI.Entities.ElementAt(m).ngay_kn.HasValue)
                                m_ngaykn = LoadOpI.Entities.ElementAt(m).ngay_kn;
                            else
                                m_ngaykn = null;

                            if (LoadOpI.Entities.ElementAt(m).ngay_ld.HasValue)
                                m_ngayld = LoadOpI.Entities.ElementAt(m).ngay_ld;
                            else
                                m_ngayld = null;

                            if (LoadOpI.Entities.ElementAt(m).ngay_cap.HasValue)
                                m_ngaycap = LoadOpI.Entities.ElementAt(m).ngay_cap;
                            else
                                m_ngaycap = null;


                            internet_log dsl = new internet_log
                            {
                                user_name = LoadOpI.Entities.ElementAt(m).user_name,
                                ten_dktb = LoadOpI.Entities.ElementAt(m).ten_dktb == null ? "" : LoadOpI.Entities.ElementAt(m).ten_dktb.Trim(),
                                ten_nsd = LoadOpI.Entities.ElementAt(m).ten_nsd == null ? "" : LoadOpI.Entities.ElementAt(m).ten_nsd.Trim(),
                                dia_chitb = LoadOpI.Entities.ElementAt(m).dia_chitb == null ? "" : LoadOpI.Entities.ElementAt(m).dia_chitb.Trim(),
                                dc_tbld = LoadOpI.Entities.ElementAt(m).dc_tbld == null ? "" : LoadOpI.Entities.ElementAt(m).dc_tbld.Trim(),
                                sohopdong =LoadOpI.Entities.ElementAt(m).sohopdong==null? "": LoadOpI.Entities.ElementAt(m).sohopdong.Trim(),
                                //ngay_hd = m_ngayhd,
                                //ngay_ld = m_ngayld,
                                tuyen_tc = m_tuyen,
                                stt = m_stt,
                                goi_cuoc = LoadOpI.Entities.ElementAt(m).goi_cuoc.Trim(),
                                //so_dt = LoadOpI.Entities.ElementAt(m).so_dt == null ? "" : LoadOpI.Entities.ElementAt(m).so_dt,
                                toc_do = LoadOpI.Entities.ElementAt(m).toc_do == null ? "" : LoadOpI.Entities.ElementAt(m).toc_do.Trim(),                                                               
                                //may_ngung = LoadOpI.Entities.ElementAt(m).may_ngung == null ? "" : LoadOpI.Entities.ElementAt(m).may_ngung,
                                ma_huyen = App.ma_huyen,
                                //socmnd = LoadOpI.Entities.ElementAt(m).socmnd == null ? "" : LoadOpI.Entities.ElementAt(m).socmnd.Trim(),
                                //noi_cap = LoadOpI.Entities.ElementAt(m).noi_cap == null ? "" : LoadOpI.Entities.ElementAt(m).noi_cap.Trim(),
                                //ngay_cap = m_ngaycap,
                                ma_kh = LoadOpI.Entities.ElementAt(m).ma_kh,                                
                                //ngay_kn = m_ngaykn,
                                //note_ngay_kn = LoadOpI.Entities.ElementAt(m).note_ngay_kn == null ? "" : LoadOpI.Entities.ElementAt(m).note_ngay_kn.Trim(),
                                //ms_thue = LoadOpI.Entities.ElementAt(m).ms_thue == null ? "" : LoadOpI.Entities.ElementAt(m).ms_thue.Trim(),
                                //ngan_hang = LoadOpI.Entities.ElementAt(m).ngan_hang == null ? "" : LoadOpI.Entities.ElementAt(m).ngan_hang.Trim(),
                                //ma_km = LoadOpI.Entities.ElementAt(m).ma_km == null ? "" : LoadOpI.Entities.ElementAt(m).ma_km.Trim(),
                                //ma_nvcs = LoadOpI.Entities.ElementAt(m).ma_nvcs == null ? "" : LoadOpI.Entities.ElementAt(m).ma_nvcs,
                                user_login = App.User_name,
                                thoi_gian = App.Current_d
                            };
                            dstb.internet_logs.Add(dsl);
                        }
                    }
                }    


              //  UpdateCodinh(sdt, m_tuyen, m_stt);
              //  UpdateGphone(sdt, m_tuyen, m_stt);
              //  UpdateMytv(sdt, m_tuyen, m_stt);
               //// xem co phai la thue bao Gphone k ?                           
               // EntityQuery<Gphone> QueryG = dstb.GetGphonesQuery();
               // LoadOpG = dstb.Load(QueryG.Where(p => p.ma_huyen == App.ma_huyen && p.so_dt == sdt), LoadOpG_Complete, null);
               // //xem co phai la thue bao MyTv k ?
               // EntityQuery<mytv> QueryM = dstb.GetMytvsQuery();
               // LoadOpM = dstb.Load(QueryM.Where(p => p.user_name.Trim() == sdt), LoadOpM_Complete, null);                         
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
               // dien_dl(cmbtuyen.Text.Trim());
                MessageBox.Show("Đã lưu thay đổi !");
                this.Hide();
                frmtuyenthu frmtuyen = new frmtuyenthu(cmbtuyen.Text.Trim());
                frmtuyen.Width = this.ActualWidth;
                frmtuyen.Height = this.ActualHeight;
                frmtuyen.Show();
            }
        }
     

        private void XemButton_Click(object sender, RoutedEventArgs e)
        {          
            dien_dl(cmbtuyen.Text.Trim());
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
