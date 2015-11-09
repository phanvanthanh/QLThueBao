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
using System.ServiceModel.DomainServices.Client;
using SilverlightQLThuebao.Web.Services;
using SilverlightQLThuebao.Web.Models;

namespace SilverlightQLThuebao
{
    public partial class frmgoicuoc : DXWindow
    {
        bool m_found, m_update;
        string m_loai,m_so,m_loaib,m_goi;
        int m_sl;
        string m_id_goicuoc;
        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        public frmgoicuoc(int sl, bool update, string so, string ten, string dc, string loai,string goi, bool view, string id_goi)
        {
            InitializeComponent();
            m_sl = sl;
            m_update = update;
            m_so = so;
            m_loaib = loai;
            m_goi = goi;
            m_id_goicuoc = id_goi;
           // App.id_goicuoc = null;
            this.gridControl1.ItemsSource = new TuyenList(); // lay bang rong dua vao
            tableView1.DeleteRow(0);
            if (m_update == false && view==false)  // truong hop lap hop dong
            {
               // this.gridControl1.ItemsSource = null;
                (this.gridControl1.ItemsSource as TuyenList).Add(new tuyen()
                {
                    so_dt = so,
                    ten_dktb = ten,
                    dia_chitb = dc,
                    loai = loai,
                    tuyen_tc = App.User_name
                });
                App.id_goicuoc = null;
            }
            // truong hop dua ra danh sach de xem
            if (view == true)
            {
                cmdadd.IsEnabled = false;
                cmdLuu.IsEnabled = false;
                cmdxoa.IsEnabled = false;
               // this.gridControl1.ItemsSource = null;
                EntityQuery<tuyen> Q = db.GetdsgoicuocQuery(id_goi);
                LoadOperation<tuyen> Load = db.Load(Q, lo => 
                {
                    if (lo.Entities.Count()>0) 
                    {
                        for (int i = 0; i < lo.Entities.Count(); i++)
			            {
                            (this.gridControl1.ItemsSource as TuyenList).Add(new tuyen()
                            {
                               so_dt = lo.Entities.ElementAt(i).so_dt,
                               ten_dktb = lo.Entities.ElementAt(i).ten_dktb,
                               dia_chitb = lo.Entities.ElementAt(i).dia_chitb,
                               loai = lo.Entities.ElementAt(i).loai,
                               tuyen_tc = App.User_name
                           });
                           // MessageBox.Show(lo.Entities.ElementAt(i).ten_dktb.ToString());
                       } 
                    }
                    
                 }   
                    , null);
                
            }

            if (update && id_goi !="")
            {
                cmdadd.IsEnabled = true;
                cmdLuu.IsEnabled = true;
                cmdxoa.IsEnabled = true;
               // this.gridControl1.ItemsSource = null;
                EntityQuery<tuyen> Q = db.GetdsgoicuocQuery(id_goi);
                LoadOperation<tuyen> Load = db.Load(Q, lo =>
                {
                    if (lo.Entities.Count() > 0)
                    {
                        for (int i = 0; i < lo.Entities.Count(); i++)
                        {
                            (this.gridControl1.ItemsSource as TuyenList).Add(new tuyen()
                            {
                                so_dt = lo.Entities.ElementAt(i).so_dt,
                                ten_dktb = lo.Entities.ElementAt(i).ten_dktb,
                                dia_chitb = lo.Entities.ElementAt(i).dia_chitb,
                                loai = lo.Entities.ElementAt(i).loai,
                                tuyen_tc = App.User_name
                            });
                        }
                    }

                }
                    , null);
            }
        }

        private void txtsodt_DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            EntityQuery<ds_codinh> Query = db.GetDs_codinhQuery();
            LoadOperation<ds_codinh> Load = db.Load(Query.Where(p => p.so_dt == this.txtsodt.Text.Trim()), LoadOpComplete, null);
        }

        void LoadOpComplete(LoadOperation<ds_codinh> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                label1.Content = lo.Entities.ElementAt(0).ten_dktb.Trim();
                label2.Content = lo.Entities.ElementAt(0).dia_chitb.Trim();
                m_loai = "C";
                m_found = true;
                return;
            }
            else
            {
                EntityQuery<Gphone> Query = db.GetGphonesQuery();
                LoadOperation<Gphone> Load = db.Load(Query.Where(p => p.so_dt == this.txtsodt.Text.Trim()), LoadOpGComplete, null);
            }
        }

        void LoadOpGComplete(LoadOperation<Gphone> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                label1.Content = lo.Entities.ElementAt(0).ten_dktb.Trim();
                label2.Content = lo.Entities.ElementAt(0).dia_chitb.Trim();
                m_loai = "G";
                m_found = true;
                return;
            }
            else
            {
                EntityQuery<internet> Query = db.GetInternetsQuery();
                LoadOperation<internet> Load = db.Load(Query.Where(p => p.user_name.Trim() == this.txtsodt.Text.Trim()), LoadOpIComplete, null);
            }
        }

        void LoadOpIComplete(LoadOperation<internet> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                label1.Content = lo.Entities.ElementAt(0).ten_dktb.Trim();
                label2.Content = lo.Entities.ElementAt(0).dia_chitb.Trim();
                m_loai = "I";
                m_found = true;
                return;
            }
            else
            {
                EntityQuery<mytv> Query = db.GetMytvsQuery();
                LoadOperation<mytv> Load = db.Load(Query.Where(p => p.user_name.Trim() == this.txtsodt.Text.Trim()), LoadOpMComplete, null);
            }
        }

        void LoadOpMComplete(LoadOperation<mytv> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                label1.Content = lo.Entities.ElementAt(0).ten_dktb.Trim();
                label2.Content = lo.Entities.ElementAt(0).dia_chitb.Trim();
                m_loai = "M";
                m_found = true;
                return;
            }
            else
            {
                m_found = false;
                MessageBox.Show("Không tìm thấy thông tin nhập vào !");
            }
        }

        private void cmdadd_Click(object sender, RoutedEventArgs e)
        {
            if (label1.Content.ToString().Trim() == "")
            {
                MessageBox.Show("Thao tác chưa đúng !");
                return;
            }
            App.id_goicuoc = null;
            //if (m_found && gridControl1.VisibleRowCount < m_sl)
            //{
                (this.gridControl1.ItemsSource as TuyenList).Add(new tuyen()
                {
                    so_dt = txtsodt.Text.Trim(),
                    ten_dktb = label1.Content.ToString().Trim(),
                    dia_chitb = label2.Content.ToString().Trim(),
                    loai = m_loai,
                    tuyen_tc = App.User_name
                });
                txtsodt.Text = "";
                label1.Content = "";
                label2.Content = "";
                txtsodt.Focus();
            //}
            //else
            //{
            //    MessageBox.Show("Không tìm thấy số điện thoại/tên đăng nhập hoặc số lượng thuê bao nhiều hơn gói cước qui định !");
            //    return;
            //}
        }

        private void cmdxoa_Click(object sender, RoutedEventArgs e)
        {
            if (gridControl1.GetFocusedRow() != null)
            {
                if (m_update && m_id_goicuoc != "")
                {
                    MessageBoxResult result = MessageBox.Show("Muốn xóa thuê bao này ra khỏi nhóm ?", "Xác nhận", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        string ma = gridControl1.GetFocusedRowCellValue(so_dt).ToString().Trim();
                        string mloai = gridControl1.GetFocusedRowCellValue(loai).ToString().Trim();
                        if (mloai == "C")
                        {
                            EntityQuery<ds_codinh> Query = db.GetDs_codinhQuery();
                            LoadOperation<ds_codinh> Load = db.Load(Query.Where(p => p.so_dt == ma), lo => { if (lo.Entities.Count() > 0) { lo.Entities.ElementAt(0).id_goicuoc = null; lo.Entities.ElementAt(0).goi_th = null; db.SubmitChanges(OnSubmitCompleteds, true); } }, null);
                        }
                        if (mloai == "G")
                        {
                            EntityQuery<Gphone> Query = db.GetGphonesQuery();
                            LoadOperation<Gphone> Load = db.Load(Query.Where(p => p.so_dt == ma), lo => { if (lo.Entities.Count() > 0) { lo.Entities.ElementAt(0).id_goicuoc = null; lo.Entities.ElementAt(0).goi_th = null; db.SubmitChanges(OnSubmitCompleteds, true); } }, null);
                        }
                        if (mloai == "I")
                        {
                            EntityQuery<internet> Query = db.GetInternetsQuery();
                            LoadOperation<internet> Load = db.Load(Query.Where(p => p.user_name.Trim() == ma), lo => { if (lo.Entities.Count() > 0) { lo.Entities.ElementAt(0).id_goicuoc = null; lo.Entities.ElementAt(0).goi_th = null; db.SubmitChanges(OnSubmitCompleteds, true); } }, null);
                        }
                        if (mloai == "M")
                        {
                            EntityQuery<mytv> Query = db.GetMytvsQuery();
                            LoadOperation<mytv> Load = db.Load(Query.Where(p => p.user_name.Trim() == ma), lo => { if (lo.Entities.Count() > 0) { lo.Entities.ElementAt(0).id_goicuoc = null; lo.Entities.ElementAt(0).goi_th = null; db.SubmitChanges(OnSubmitCompleteds, true); } }, null);
                        }
                        int bg = tableView1.FocusedRowHandle;
                        tableView1.DeleteRow(bg);
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Muốn xóa thuê bao này ra khỏi nhóm ?", "Xác nhận", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        string ma = gridControl1.GetFocusedRowCellValue(so_dt).ToString().Trim();
                        for (int i = 0; i < gridControl1.VisibleRowCount; i++)
                        {
                            if (gridControl1.GetCellValue(i, so_dt).ToString().Trim() == ma)
                                tableView1.DeleteRow(i);
                        }

                    }
                }
            }
                else
                    MessageBox.Show("Chưa chọn thuê bao cần xóa !");
           
        }

        private void cmdLuu_Click(object sender, RoutedEventArgs e)
        {
            if (gridControl1.VisibleRowCount <= 0)
                return;
            cmdLuu.IsEnabled = false;
            //if (m_update == false)
            //{               
                if (m_loaib == "C")
                {                    
                    EntityQuery<ds_codinh> Query = db.GetDs_codinhQuery();
                    LoadOperation<ds_codinh> Load = db.Load(Query.Where(p => p.so_dt == m_so), LoadCompleteC, null);
                }
                if (m_loaib == "G")
                {
                    EntityQuery<Gphone> Query = db.GetGphonesQuery();
                    LoadOperation<Gphone> Load = db.Load(Query.Where(p => p.so_dt == m_so), LoadCompleteG, null);
                }
                if (m_loaib == "I")
                {
                    EntityQuery<internet> Query = db.GetInternetsQuery();
                    LoadOperation<internet> Load = db.Load(Query.Where(p => p.user_name.Trim() == m_so), LoadCompleteI, null);
                }
                if (m_loaib == "M")
                {
                    EntityQuery<mytv> Query = db.GetMytvsQuery();
                    LoadOperation<mytv> Load = db.Load(Query.Where(p => p.user_name.Trim() == m_so), LoadCompleteM, null);
                }
            //}
        }

        void LoadCompleteC(LoadOperation<ds_codinh> lo)
        {
           // string temps;
            if (lo.Entities.Count() > 0)
            {
                decimal id_goicuoc;
                if (lo.Entities.ElementAt(0).id_goicuoc == null)
                    id_goicuoc = 0;
                else
                    id_goicuoc = Convert.ToDecimal(lo.Entities.ElementAt(0).id_goicuoc.Trim());
                if (id_goicuoc == 0)
                {                  
                    EntityQuery<maxmakhachhang> Query = db.GetidgoicuocCDQuery();
                    LoadOperation<maxmakhachhang> LoadOp = db.Load(Query, LoadOpID_Complete, null);
                }
                else
                {
                    //MessageBox.Show("dasdsa");
                    //temps = lo.Entities.ElementAt(0).id_goicuoc.ToString().Trim().Substring(1,6);
                    //m_id_goicuoc = "1" + temps.PadLeft(6, '0');
                    m_id_goicuoc = Convert.ToString(Convert.ToDecimal(lo.Entities.ElementAt(0).id_goicuoc.ToString().Trim())+1);
                    Save();
                }
            }
            else
            {
                //temps = "1";
                //m_id_goicuoc = Convert.ToDecimal("1" + temps.PadLeft(6, '0'));
                EntityQuery<maxmakhachhang> Query = db.GetidgoicuocCDQuery();
                LoadOperation<maxmakhachhang> LoadOp = db.Load(Query, LoadOpID_Complete, null);
                //Save();
            }
        }

        void LoadCompleteG(LoadOperation<Gphone> lo)
        {
            //string temps;
            if (lo.Entities.Count() > 0)
            {
                decimal id_goicuoc;
                if (lo.Entities.ElementAt(0).id_goicuoc == null)
                    id_goicuoc = 0;
                else
                    id_goicuoc = Convert.ToDecimal(lo.Entities.ElementAt(0).id_goicuoc.Trim());
                if (id_goicuoc == 0)
                {
                    EntityQuery<maxmakhachhang> Query = db.GetidgoicuocGPQuery();
                    LoadOperation<maxmakhachhang> LoadOp = db.Load(Query, LoadOpID_Complete, null);
                }
                else
                {
                    //temps = lo.Entities.ElementAt(0).id_goicuoc.ToString().Trim();
                    //m_id_goicuoc = "2" + temps.PadLeft(6, '0');
                    m_id_goicuoc = Convert.ToString(Convert.ToDecimal(lo.Entities.ElementAt(0).id_goicuoc.ToString().Trim()) + 1);
                    Save();
                }
            }
            else
            {
                //temps = "1";
                //m_id_goicuoc = Convert.ToDecimal("2" + temps.PadLeft(6, '0'));
                //Save();
                EntityQuery<maxmakhachhang> Query = db.GetidgoicuocGPQuery();
                LoadOperation<maxmakhachhang> LoadOp = db.Load(Query, LoadOpID_Complete, null);
            }

        }

        void LoadCompleteI(LoadOperation<internet> lo)
        {
           // string temps;
            if (lo.Entities.Count() > 0)
            {
                decimal id_goicuoc;             
                if (lo.Entities.ElementAt(0).id_goicuoc == null)
                    id_goicuoc = 0;
                else                    
                    id_goicuoc= Convert.ToDecimal(lo.Entities.ElementAt(0).id_goicuoc.Trim());
                 
                if (id_goicuoc == 0)
                {
                    EntityQuery<maxmakhachhang> Query = db.GetidgoicuocINTQuery();
                    LoadOperation<maxmakhachhang> LoadOp = db.Load(Query, LoadOpID_Complete, null);
                }
                else
                {
                    //temps = lo.Entities.ElementAt(0).id_goicuoc.ToString().Trim();
                    //m_id_goicuoc = "3" + temps.PadLeft(6, '0');
                    m_id_goicuoc = Convert.ToString(Convert.ToDecimal(lo.Entities.ElementAt(0).id_goicuoc.ToString().Trim()) + 1);
                    Save();
                }
            }
            else
            {
                //temps = "1";
                //m_id_goicuoc = Convert.ToDecimal("3" + temps.PadLeft(6, '0'));
                //Save();
                EntityQuery<maxmakhachhang> Query = db.GetidgoicuocINTQuery();
                LoadOperation<maxmakhachhang> LoadOp = db.Load(Query, LoadOpID_Complete, null);
            }

        }

        void LoadCompleteM(LoadOperation<mytv> lo)
        {
           // string temps;
            if (lo.Entities.Count() > 0)
            {
                decimal id_goicuoc;
                if (lo.Entities.ElementAt(0).id_goicuoc == null)
                    id_goicuoc = 0;
                else
                    id_goicuoc = Convert.ToDecimal(lo.Entities.ElementAt(0).id_goicuoc.Trim());
                if (id_goicuoc == 0)
                {
                    EntityQuery<maxmakhachhang> Query = db.GetidgoicuocMYQuery();
                    LoadOperation<maxmakhachhang> LoadOp = db.Load(Query, LoadOpID_Complete, null);
                }
                else
                {
                    //temps = lo.Entities.ElementAt(0).id_goicuoc.ToString().Trim();
                   // m_id_goicuoc = "4" + temps.PadLeft(6, '0');
                    m_id_goicuoc = Convert.ToString(Convert.ToDecimal(lo.Entities.ElementAt(0).id_goicuoc.ToString().Trim()) + 1);
                    Save();
                }
            }
            else
            {
                //temps = "1";
                //m_id_goicuoc = Convert.ToDecimal("4" + temps.PadLeft(6, '0'));
                //Save();
                EntityQuery<maxmakhachhang> Query = db.GetidgoicuocMYQuery();
                LoadOperation<maxmakhachhang> LoadOp = db.Load(Query, LoadOpID_Complete, null);
            }
        }

        void LoadOpID_Complete(LoadOperation<maxmakhachhang> lo)
        {
            string temps;            
            if (lo.Entities.Count() > 0)
            {
                temps = lo.Entities.ElementAt(0).maxmakh == null ? "0" : lo.Entities.ElementAt(0).maxmakh.Trim();                
                temps = (Convert.ToDecimal(temps==""? "0":temps) + 1).ToString();
                m_id_goicuoc = temps;
            }
            else
            {
                temps = "1";
                if (m_loaib == "C")
                    m_id_goicuoc = "1" + temps.PadLeft(6, '0');
                if (m_loaib == "G")
                    m_id_goicuoc = "2" + temps.PadLeft(6, '0');
                if (m_loaib == "I")
                    m_id_goicuoc = "3" + temps.PadLeft(6, '0');
                if (m_loaib == "M")
                    m_id_goicuoc = "4" + temps.PadLeft(6, '0');                
            }
           
            Save();
        }

        void Save()
        {
            try
            {              
                for (int i = 0; i < gridControl1.VisibleRowCount; i++)
                {
                    string m_sodt = gridControl1.GetCellValue(i,so_dt).ToString().Trim();
                    string l = gridControl1.GetCellValue(i, loai).ToString().Trim();
                    string ten = gridControl1.GetCellValue(i, ten_dktb).ToString().Trim();
                    string dc = gridControl1.GetCellValue(i, dia_chitb).ToString().Trim();
                    db.Update_goi_cuoc_th(m_sodt, m_goi, m_id_goicuoc, l, ten, dc, App.User_name);
                    //if (l == "C")
                    //{                       
                    //    EntityQuery<ds_codinh> Q = db.GetDs_codinhQuery();
                    //    LoadOperation<ds_codinh> los = db.Load(Q.Where(p => p.so_dt == m_sodt), lo =>
                    //    { if (lo.Entities.Count() > 0) { lo.Entities.ElementAt(0).id_goicuoc = m_id_goicuoc; lo.Entities.ElementAt(0).goi_th = m_goi; } }, null);
                    //}
                    //if (l == "G")
                    //{
                    //    EntityQuery<Gphone> Q = db.GetGphonesQuery();
                    //    LoadOperation<Gphone> los = db.Load(Q.Where(p => p.so_dt == m_sodt), lo =>
                    //    { if (lo.Entities.Count() > 0) { lo.Entities.ElementAt(0).id_goicuoc = m_id_goicuoc; lo.Entities.ElementAt(0).goi_th = m_goi; } }, null);
                    //}
                    //if (l == "I")
                    //{
                    //    EntityQuery<internet> Q = db.GetInternetsQuery();
                    //    LoadOperation<internet> los = db.Load(Q.Where(p => p.user_name.Trim() == m_sodt), lo =>
                    //    { if (lo.Entities.Count() > 0) { lo.Entities.ElementAt(0).id_goicuoc = m_id_goicuoc; lo.Entities.ElementAt(0).goi_th = m_goi; } }, null);
                    //}
                    //if (l == "M")
                    //{                      
                    //    EntityQuery<mytv> Q = db.GetMytvsQuery();
                    //    LoadOperation<mytv> los = db.Load(Q.Where(p => p.user_name.Trim() == m_sodt), lo =>
                    //    { if (lo.Entities.Count() > 0) { lo.Entities.ElementAt(0).id_goicuoc = m_id_goicuoc; lo.Entities.ElementAt(0).goi_th = m_goi; } }, null);
                    //}

                    
                }

               //db.SubmitChanges(OnSubmitCompleted, true);
                App.id_goicuoc = m_id_goicuoc;
                MessageBox.Show("Đã lưu vào cơ sở dữ liệu");
                this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Exception Failed: {0}", e));
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
                App.id_goicuoc = m_id_goicuoc;
                this.cmdLuu.IsEnabled = false;                
                MessageBox.Show("Đã lưu vào cơ sở dữ liệu");
                this.Close();
            }
        }

        private void OnSubmitCompleteds(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
            {               
                this.cmdLuu.IsEnabled = false;
                MessageBox.Show("Đã lưu vào cơ sở dữ liệu");
               
            }
        }
    }
}
