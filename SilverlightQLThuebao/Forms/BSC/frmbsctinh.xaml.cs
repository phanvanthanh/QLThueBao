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
    public partial class frmbsctinh : DXWindow
    {
        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        int m_count = 0;
        decimal[] m_exits;
        LoadOperation<BSCT> Load;
        LoadOperation<Phong_huyen> Loads;
        public frmbsctinh()
        {
            InitializeComponent();
            //EntityQuery<Phong_huyen> Querys = db.GetPhong_huyenQuery();
            //if (App.adminBSC_VTT)           
            //    Loads = db.Load(Querys.Where(p => p.kythuat == true).OrderBy(p => p.nhom), LoadOpCompleteS, null);
           
            //if (App.adminBSC_TTKD)           
            //    Loads = db.Load(Querys.Where(p => p.kythuat == App.kythuat).OrderBy(p => p.nhom), LoadOpCompleteS, null);
            //btnsave.IsEnabled = false;  
        }
        //void get_data()
        //{            
        //    this.gridControl1.ItemsSource = new BSC_tinh(); // lay bang rong dua vao
        //    tableView1.DeleteRow(0);           
        //    gridControl1.ShowLoadingPanel = true;           
          
        //    if (App.adminBSC_VTT)
        //    {
        //        if (cmbdv.EditValue.ToString().Trim() == "KKD")
        //        {
        //            EntityQuery<BSCT> Query = db.GetKpis_tinhQuery(false);
        //            Load = db.Load(Query, LoadOpComplete, null);
        //        }
        //        else
        //        {
        //            EntityQuery<BSCT> Query = db.GetKpis_tinhQuery(true);
        //            Load = db.Load(Query, LoadOpComplete, null);
        //        }
        //    }
        //    if (App.adminBSC_TTKD)
        //    {
        //        EntityQuery<BSCT> Query = db.GetKpis_tinhQuery(false);
        //        Load = db.Load(Query, LoadOpComplete, null);
        //    }
            

        //}
        //void LoadOpComplete(LoadOperation<BSCT> lo)
        //{            
        //    if (lo.Entities.Count() > 0)
        //    {

        //        if (gridControl2.VisibleRowCount > 0)
        //        {
        //            m_exits = new decimal[gridControl2.VisibleRowCount];
        //            for (int i = 0; i < gridControl2.VisibleRowCount; i++)
        //            {
        //                int rowHandle = gridControl2.GetRowHandleByVisibleIndex(i);
        //                if (!gridControl2.IsGroupRowHandle(rowHandle))
        //                    m_exits[i] = (decimal)gridControl2.GetCellValue(rowHandle, id1);
        //            }
        //            for (int i = 0; i < lo.Entities.Count(); i++)
        //            {
        //                if (!m_exits.Contains(lo.Entities.ElementAt(i).id))
        //                {
        //                    (this.gridControl1.ItemsSource as BSC_tinh).Add(new BSCT
        //                    {
        //                        id = lo.Entities.ElementAt(i).id,
        //                        ten_vien_canh = lo.Entities.ElementAt(i).ten_vien_canh,
        //                        ma_kpis = lo.Entities.ElementAt(i).ma_kpis,
        //                        ten_kpis = lo.Entities.ElementAt(i).ten_kpis.Trim(),
        //                        ten_kpos = lo.Entities.ElementAt(i).ten_kpos.Trim(),
        //                        dvt = lo.Entities.ElementAt(i).dvt,
        //                        check = lo.Entities.ElementAt(i).check == null ? false : lo.Entities.ElementAt(i).check,
        //                        //tonghop = lo.Entities.ElementAt(i).tonghop == null ? false : lo.Entities.ElementAt(i).tonghop,
        //                        loai_dvt = lo.Entities.ElementAt(i).loai_dvt
        //                    });
        //                }
        //            }               

        //        }
        //        else
        //        {
        //            //this.gridControl2.ItemsSource = new BSC_tinh_temp(); // lay bang rong dua vao
        //            //tableView2.DeleteRow(0);
        //            for (int i = 0; i < lo.Entities.Count(); i++)
        //            {
        //                (this.gridControl1.ItemsSource as BSC_tinh).Add(new BSCT
        //                {
        //                    id = lo.Entities.ElementAt(i).id,
        //                    ten_vien_canh = lo.Entities.ElementAt(i).ten_vien_canh,
        //                    ma_kpis = lo.Entities.ElementAt(i).ma_kpis,
        //                    ten_kpis = lo.Entities.ElementAt(i).ten_kpis.Trim(),
        //                    ten_kpos = lo.Entities.ElementAt(i).ten_kpos.Trim(),
        //                    dvt = lo.Entities.ElementAt(i).dvt,
        //                    check = lo.Entities.ElementAt(i).check == null ? false : lo.Entities.ElementAt(i).check,
        //                    //tonghop = lo.Entities.ElementAt(i).tonghop == null ? false : lo.Entities.ElementAt(i).tonghop,
        //                    loai_dvt = lo.Entities.ElementAt(i).loai_dvt
        //                });
        //            }               
        //        }
        //        gridControl1.GroupBy("ten_vien_canh");
        //        gridControl1.GroupBy("ten_kpos");
        //        gridControl1.ExpandAllGroups();
        //    }
        //    gridControl1.ShowLoadingPanel = false;
        //}


        private void btnchon_Click(object sender, RoutedEventArgs e)
        {
        //    for (int i = 0; i < gridControl1.VisibleRowCount; i++)
        //    {
        //        int rowHandle = gridControl1.GetRowHandleByVisibleIndex(i);
        //        if (!gridControl1.IsGroupRowHandle(rowHandle))
        //        {
        //            if ((bool)gridControl1.GetCellValue(rowHandle, check) == true)
        //            {

        //                (this.gridControl2.ItemsSource as BSC_tinh_temp).Add(new BSCT
        //                {
        //                    id = (decimal)gridControl1.GetCellValue(rowHandle, id),
        //                    ten_vien_canh = (string)gridControl1.GetCellValue(rowHandle, ten_vien_canh),
        //                    ma_kpis = (string)gridControl1.GetCellValue(rowHandle, ma_kpis),
        //                    ten_kpis = (string)gridControl1.GetCellValue(rowHandle, ten_kpis),
        //                    ten_kpos = (string)gridControl1.GetCellValue(rowHandle, ten_kpos),
        //                    dvt = (string)gridControl1.GetCellValue(rowHandle, dvt),
        //                    //check = lo.Entities.ElementAt(i).check==null? false: lo.Entities.ElementAt(i).check,
        //                    chitieugiao = 0

        //                });
        //            }
        //        }
        //    }
        //    gridControl2.GroupBy("ten_vien_canh");
        //    gridControl2.GroupBy("ten_kpos");
        //    gridControl2.ExpandAllGroups();

        //    //remove các mẫu tin đã chọn
        //xoa:
        //    gridControl1.UngroupBy("ten_kpos");
        //    gridControl1.UngroupBy("ten_vien_canh");
        //    int m_count = gridControl1.VisibleRowCount;
        //    for (int j = 0; j < m_count; j++)
        //    {
        //        int rowHandlej = gridControl1.GetRowHandleByVisibleIndex(j);
        //        if ((bool)gridControl1.GetCellValue(rowHandlej, check) == true)
        //        {
        //            tableView1.DeleteRow(j);
        //            goto xoa;
        //        }
        //    }
        //    gridControl1.GroupBy("ten_vien_canh");
        //    gridControl1.GroupBy("ten_kpos");
        //    gridControl1.ExpandAllGroups();
        //    btnsave.IsEnabled = true;
        }

        private void btnbochon_Click(object sender, RoutedEventArgs e)
        {
            //decimal m_id = (decimal)gridControl2.GetFocusedRowCellValue(id1);
            //gridControl2.UngroupBy("ten_kpos");
            //gridControl2.UngroupBy("ten_vien_canh");
            //for (int i = 0; i < gridControl2.VisibleRowCount; i++)
            //{
            //    int rowHandle = gridControl2.GetRowHandleByVisibleIndex(i);
            //    if ((decimal)gridControl2.GetCellValue(rowHandle, id1) == m_id)
            //        tableView2.DeleteRow(i);
            //}
            //gridControl2.GroupBy("ten_vien_canh");
            //gridControl2.GroupBy("ten_kpos");
            //gridControl2.ExpandAllGroups();
            //get_data();
            //btnsave.IsEnabled = true;
        }

        //void LoadOpCompleteS(LoadOperation<Phong_huyen> lo)
        //{
        //    if (lo.Entities.Count() > 0)
        //    {
        //        this.cmbdv.DisplayMember = ("ten_dv").Trim();
        //        this.cmbdv.ValueMember = "ma_dv";
        //        this.cmbdv.ItemsSource = lo.Entities;
        //    }
        //}

        private void cmbdv_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            //get_data();
        }

        private void cmdview_Click(object sender, RoutedEventArgs e)
        {
            //this.gridControl2.ItemsSource = new BSC_tinh_temp(); // lay bang rong dua vao
            //tableView2.DeleteRow(0);
            //gridControl2.ShowLoadingPanel = true;
            //string m_dv = cmbdv.EditValue.ToString().Trim();
            //string m_tg = thang.DateTime.Month.ToString().Trim() + thang.DateTime.Year.ToString().Trim();
            //EntityQuery<BSCT> Query = db.GetExitsKpis_tinhQuery(m_tg, m_dv);
            //LoadOperation<BSCT> Loadc = db.Load(Query, LoadOpCompleteExits, null);
            //giaodonvi.Text = "Giao cho đơn vị: " + cmbdv.Text.Trim();
        }

        //void LoadOpCompleteExits(LoadOperation<BSCT> lo)
        //{
        //    if (lo.Entities.Count() > 0)
        //    {                
        //        for (int i = 0; i < lo.Entities.Count(); i++)
        //        {
        //             (this.gridControl2.ItemsSource as BSC_tinh_temp).Add(new BSCT
        //                {
        //                    id = (decimal)lo.Entities.ElementAt(i).id,
        //                    ten_vien_canh = lo.Entities.ElementAt(i).ten_vien_canh.ToString().Trim(),
        //                    ma_kpis = lo.Entities.ElementAt(i).ma_kpis.ToString().Trim(),
        //                    ten_kpis = lo.Entities.ElementAt(i).ten_kpis.ToString().Trim(),
        //                    ten_kpos = lo.Entities.ElementAt(i).ten_kpos.ToString().Trim(),
        //                    dvt = lo.Entities.ElementAt(i).dvt.ToString().Trim(),
        //                    //check = lo.Entities.ElementAt(i).check==null? false: lo.Entities.ElementAt(i).check,
        //                    chitieugiao = lo.Entities.ElementAt(i).chitieugiao == null ? 0 : (double)lo.Entities.ElementAt(i).chitieugiao,
        //                    chitieuth = lo.Entities.ElementAt(i).chitieuth == null ? 0 : (double)lo.Entities.ElementAt(i).chitieuth,
        //                    trongso = lo.Entities.ElementAt(i).trongso == null ? 0 : (double)lo.Entities.ElementAt(i).trongso,
        //                    ty_trong_thuc_hien = lo.Entities.ElementAt(i).ty_trong_thuc_hien == null ? 0 : (double)lo.Entities.ElementAt(i).ty_trong_thuc_hien
        //               });               
        //        }                
        //        gridControl2.GroupBy("ten_vien_canh");
        //        gridControl2.GroupBy("ten_kpos");
        //        gridControl2.ExpandAllGroups();                        
        //    }
        //    get_data();
        //    gridControl2.ShowLoadingPanel = false;     
        //}

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            string qui = thang.DateTime.Month.ToString().Trim() + thang.DateTime.Year.ToString().Trim();
            //EntityQuery<chi_tieu_huyen> Query = db.GetChi_tieu_huyenQuery();
            //LoadOperation<chi_tieu_huyen> Loadx = db.Load(Query.Where(p => p.qui == qui), LoadOpCompleteC, null);

        }

        //void LoadOpCompleteC(LoadOperation<chi_tieu_huyen> lo)
        //{
        //    if (lo.Entities.Count() > 0)
        //    {
        //        for (int i = 0; i < lo.Entities.Count(); i++)
        //        {
        //            chi_tieu_huyen ct = lo.Entities.ElementAt(i);
        //            db.chi_tieu_huyens.Remove(ct);
        //        }
        //        db.SubmitChanges(OnSubmitCompletedD, true);
        //    }
        //    else
        //        save();
 
        //}

        //void save()
        //{
        //    if (gridControl2.VisibleRowCount > 0)
        //    {
        //        for (int i = 0; i < gridControl2.VisibleRowCount; i++)
        //        {
        //            int rowHandle = gridControl2.GetRowHandleByVisibleIndex(i);
        //            if (!gridControl1.IsGroupRowHandle(rowHandle))
        //            {
        //                decimal m_id = (decimal)gridControl2.GetCellValue(rowHandle, id1);
        //                double m_trongso = gridControl2.GetCellValue(rowHandle, trongso) == null ? 0 : Convert.ToDouble(gridControl2.GetCellValue(rowHandle, trongso));
        //                double m_chitieu = gridControl2.GetCellValue(rowHandle, chitieugiao) == null ? 0 : Convert.ToDouble(gridControl2.GetCellValue(rowHandle, chitieugiao));
        //                chi_tieu_huyen ct = new chi_tieu_huyen
        //                {
        //                    id_kpis = m_id,
        //                    ma_dv = cmbdv.EditValue.ToString().Trim(),
        //                    qui = thang.DateTime.Month.ToString().Trim() + thang.DateTime.Year.ToString().Trim(),
        //                    trong_so_giao = m_trongso,
        //                    chi_tieu_giao = m_chitieu
        //                };
        //                db.chi_tieu_huyens.Add(ct);
        //            }
        //        }
        //        db.SubmitChanges(OnSubmitCompleted, true);
        //    }
        //}

        //private void OnSubmitCompletedD(SubmitOperation so)
        //{
        //    if (so.HasError)
        //    {
        //        MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
        //        so.MarkErrorAsHandled();
        //    }
        //    else
        //       save();
                            
        //}
        //private void OnSubmitCompleted(SubmitOperation so)
        //{
        //    if (so.HasError)
        //    {
        //        MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
        //        so.MarkErrorAsHandled();
        //    }
        //    else
        //        MessageBox.Show("Đã ghi dữ liệu xong");  
        //}

        private void tableView2_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            if (e.Column == gridControl2.Columns["chitieugiao"] || e.Column == gridControl2.Columns["trongso"])
                btnsave.IsEnabled = true;

        }
    }
}
