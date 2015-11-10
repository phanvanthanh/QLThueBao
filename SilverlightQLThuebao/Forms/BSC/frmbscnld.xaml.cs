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
    public partial class frmbscnld : DXWindow
    {
        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        LoadOperation<nhanvien_cs> Loads;
        LoadOperation<BSCT> Load;
        int m_count = 0;
        string[] m_exits;
        public frmbscnld()
        {
            InitializeComponent();
            btnbochon.IsEnabled = false;
            EntityQuery<nhanvien_cs> Querys = db.Getnhanvien_csQuery();
            Loads = db.Load(Querys.Where(p => p.ma_huyen == App.ma_huyen), LoadOpCompleteS, null);
            btnsave.IsEnabled = false;  
        }

        void LoadOpCompleteS(LoadOperation<nhanvien_cs> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbnv.DisplayMember = ("ten_nv").Trim();
                this.cmbnv.ValueMember = "ma_nvcs";
                this.cmbnv.ItemsSource = lo.Entities;
            }
        }

        private void cmdview_Click(object sender, RoutedEventArgs e)
        {
            this.gridControl2.ItemsSource = new BSC_tinh_temp(); // lay bang rong dua vao
            tableView2.DeleteRow(0);
            gridControl2.ShowLoadingPanel = true;
            string m_nv = cmbnv.EditValue.ToString().Trim();
            string m_tg = thang.DateTime.Month.ToString().Trim() + thang.DateTime.Year.ToString().Trim();
            EntityQuery<BSCT> Query = db.GetExitsKpis_tinhQuery(m_tg, m_nv);
            LoadOperation<BSCT> Loadc = db.Load(Query, LoadOpCompleteExits, null);
            giaonhanvien.Text = "Giao cho nhân viên: " + cmbnv.Text.Trim();
        }

        void LoadOpCompleteExits(LoadOperation<BSCT> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                for (int i = 0; i < lo.Entities.Count(); i++)
                {
                    (this.gridControl2.ItemsSource as BSC_tinh_temp).Add(new BSCT
                    {
                        ma_kpi = lo.Entities.ElementAt(i).ma_kpi.ToString().Trim(),
                        ten_kpi = lo.Entities.ElementAt(i).ten_kpi.ToString().Trim(),
                        ten_kpo = lo.Entities.ElementAt(i).ten_kpo.ToString().Trim(),
                        dvt = lo.Entities.ElementAt(i).dvt.ToString().Trim(),
                        //check = lo.Entities.ElementAt(i).check==null? false: lo.Entities.ElementAt(i).check,
                        chitieugiao = lo.Entities.ElementAt(i).chitieugiao == null ? 0 : (double)lo.Entities.ElementAt(i).chitieugiao,
                        chitieuth = lo.Entities.ElementAt(i).chitieuth == null ? 0 : (double)lo.Entities.ElementAt(i).chitieuth,
                        trongso = lo.Entities.ElementAt(i).trongso == null ? 0 : (double)lo.Entities.ElementAt(i).trongso,
                        ty_trong_thuc_hien = lo.Entities.ElementAt(i).ty_trong_thuc_hien == null ? 0 : (double)lo.Entities.ElementAt(i).ty_trong_thuc_hien
                    });
                }
                gridControl2.GroupBy("ten_kpo");
                gridControl2.ExpandAllGroups();
            }
            get_data();
            gridControl2.ShowLoadingPanel = false;
        }

        void get_data()
        {            
            this.gridControl1.ItemsSource = new BSC_tinh(); // lay bang rong dua vao
            tableView1.DeleteRow(0);           
            gridControl1.ShowLoadingPanel = true;

            EntityQuery<BSCT> Query = db.GetKpi_huyenQuery(App.kythuat); //todo lay theo nhan vien duoc chon
            Load = db.Load(Query, LoadOpComplete, null);
        }

        void LoadOpComplete(LoadOperation<BSCT> lo)
        {
            if (lo.Entities.Count() > 0)
            {

                if (gridControl2.VisibleRowCount > 0)
                {
                    m_exits = new string[gridControl2.VisibleRowCount];
                    for (int i = 0; i < gridControl2.VisibleRowCount; i++)
                    {
                        int rowHandle = gridControl2.GetRowHandleByVisibleIndex(i);
                        if (!gridControl2.IsGroupRowHandle(rowHandle))
                            m_exits[i] = gridControl2.GetCellValue(rowHandle, ma_kpi1).ToString().Trim();
                    }
                    for (int i = 0; i < lo.Entities.Count(); i++)
                    {
                        if (!m_exits.Contains(lo.Entities.ElementAt(i).ma_kpi.ToString().Trim()))
                        {
                            (this.gridControl1.ItemsSource as BSC_tinh).Add(new BSCT
                            {
                              
                                ma_kpi = lo.Entities.ElementAt(i).ma_kpi,
                                ten_kpi = lo.Entities.ElementAt(i).ten_kpi.Trim(),
                                ten_kpo = lo.Entities.ElementAt(i).ten_kpo.Trim(),
                                dvt = lo.Entities.ElementAt(i).dvt,
                                check = lo.Entities.ElementAt(i).check == null ? false : lo.Entities.ElementAt(i).check,
                                //tonghop = lo.Entities.ElementAt(i).tonghop == null ? false : lo.Entities.ElementAt(i).tonghop,
                                loai_dvt = lo.Entities.ElementAt(i).loai_dvt
                            });
                        }
                    }

                }
                else
                {
                    //this.gridControl2.ItemsSource = new BSC_tinh_temp(); // lay bang rong dua vao
                    //tableView2.DeleteRow(0);
                    for (int i = 0; i < lo.Entities.Count(); i++)
                    {
                        (this.gridControl1.ItemsSource as BSC_tinh).Add(new BSCT
                        {                            
                            ma_kpi = lo.Entities.ElementAt(i).ma_kpi,
                            ten_kpi = lo.Entities.ElementAt(i).ten_kpi.Trim(),
                            ten_kpo = lo.Entities.ElementAt(i).ten_kpo.Trim(),
                            dvt = lo.Entities.ElementAt(i).dvt,
                            check = lo.Entities.ElementAt(i).check == null ? false : lo.Entities.ElementAt(i).check,
                            //tonghop = lo.Entities.ElementAt(i).tonghop == null ? false : lo.Entities.ElementAt(i).tonghop,
                            loai_dvt = lo.Entities.ElementAt(i).loai_dvt
                        });
                    }
                }
                gridControl1.GroupBy("ten_kpo");
                gridControl1.ExpandAllGroups();
            }
            gridControl1.ShowLoadingPanel = false;
        }

        private void btnchon_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < gridControl1.VisibleRowCount; i++)
            {
                int rowHandle = gridControl1.GetRowHandleByVisibleIndex(i);
                if (!gridControl1.IsGroupRowHandle(rowHandle))
                {
                    if ((bool)gridControl1.GetCellValue(rowHandle, check) == true)
                    {

                        (this.gridControl2.ItemsSource as BSC_tinh_temp).Add(new BSCT
                        {                            
                            ma_kpi = (string)gridControl1.GetCellValue(rowHandle, ma_kpi),
                            ten_kpi = (string)gridControl1.GetCellValue(rowHandle, ten_kpi),
                            ten_kpo = (string)gridControl1.GetCellValue(rowHandle, ten_kpo),
                            dvt = (string)gridControl1.GetCellValue(rowHandle, dvt),
                            //check = lo.Entities.ElementAt(i).check==null? false: lo.Entities.ElementAt(i).check,
                            chitieugiao = 0
                        });
                        btnbochon.IsEnabled = true;
                    }
                }
            }
            gridControl2.GroupBy("ten_kpo");
            gridControl2.ExpandAllGroups();

            //remove các mẫu tin đã chọn
            gridControl1.UngroupBy("ten_kpo");
            xoa:
            int m_count = gridControl1.VisibleRowCount;
            for (int j = 0; j < m_count; j++)
            {
                int rowHandlej = gridControl1.GetRowHandleByVisibleIndex(j);
                if ((bool)gridControl1.GetCellValue(rowHandlej, check) == true)
                {
                    tableView1.DeleteRow(j);
                    goto xoa;
                }
            }
            gridControl1.GroupBy("ten_kpo");
            gridControl1.ExpandAllGroups();
            btnsave.IsEnabled = true;
        }

        // Thanh sửa
        private void btnbochon_Click(object sender, RoutedEventArgs e)
        {
            gridControl2.UngroupBy("ten_kpo");
            xoa:
            for (int i = 0; i < gridControl2.VisibleRowCount; i++)
            {
                int rowHandle = gridControl2.GetRowHandleByVisibleIndex(i);
                if ((bool)gridControl2.GetCellValue(rowHandle, check_bochon) == true)
                {
                    tableView2.DeleteRow(i);
                    goto xoa;
                }
            }
            gridControl2.GroupBy("ten_kpo");
            gridControl2.ExpandAllGroups();
            get_data();
            if (gridControl2.VisibleRowCount==0)
            {
                btnbochon.IsEnabled = false;
            }
            btnsave.IsEnabled = true;            
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            string thang_nvcs = thang.DateTime.Month.ToString().Trim() + thang.DateTime.Year.ToString().Trim();
            EntityQuery<chi_tieu_ca_nhan> Query = db.GetChi_tieu_ca_nhanQuery();
            LoadOperation<chi_tieu_ca_nhan> Loadx = db.Load(Query.Where(p => p.thang_nvcs == thang_nvcs), LoadOpCompleteC, null);
        }

        void LoadOpCompleteC(LoadOperation<chi_tieu_ca_nhan> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                for (int i = 0; i < lo.Entities.Count(); i++)
                {
                    chi_tieu_ca_nhan ct = lo.Entities.ElementAt(i);
                    db.chi_tieu_ca_nhans.Remove(ct);
                }
                db.SubmitChanges(OnSubmitCompletedD, true);
            }
            else
                save();

        }

        void save()
        {
            if (gridControl2.VisibleRowCount > 0)
            {
                for (int i = 0; i < gridControl2.VisibleRowCount; i++)
                {
                    int rowHandle = gridControl2.GetRowHandleByVisibleIndex(i);
                    if (!gridControl1.IsGroupRowHandle(rowHandle))
                    {
                        string m_id = (string)gridControl2.GetCellValue(rowHandle, ma_kpi1);
                        double m_trongso = gridControl2.GetCellValue(rowHandle, trongso) == null ? 0 : Convert.ToDouble(gridControl2.GetCellValue(rowHandle, trongso));
                        double m_chitieu = gridControl2.GetCellValue(rowHandle, chitieugiao) == null ? 0 : Convert.ToDouble(gridControl2.GetCellValue(rowHandle, chitieugiao));
                        chi_tieu_ca_nhan ct = new chi_tieu_ca_nhan
                        {
                            id_kpi = m_id,
                            id_nv_cs = cmbnv.EditValue.ToString().Trim(),
                            thang_nvcs = thang.DateTime.Month.ToString().Trim() + thang.DateTime.Year.ToString().Trim(),
                            tytrong_giao = m_trongso,
                            chitieu_giao = m_chitieu
                        };
                        db.chi_tieu_ca_nhans.Add(ct);
                    }
                }
                db.SubmitChanges(OnSubmitCompleted, true);
            }
        }

        private void OnSubmitCompletedD(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
                save();

        }
        private void OnSubmitCompleted(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
                MessageBox.Show("Đã ghi dữ liệu xong");
        }

        private void tableView2_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            if (e.Column == gridControl2.Columns["chitieugiao"] || e.Column == gridControl2.Columns["trongso"])
                btnsave.IsEnabled = true;

        }

        private void CheckEdit_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btn_new_kpi_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
