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
    public partial class frmdsgandiaban : DXWindow
    {
        bool m_kt,m_emp;
        string m_nv;
        string m_huyen;
        string S_null;
        LoadOperation<Mdiaban> LoadOptuyen;
        LoadOperation<Mdiaban> LoadOptuyenkt;
        LoadOperation<ds_codinh> LoadOp;
        LoadOperation<Gphone> LoadOpG;
        LoadOperation<internet> LoadOpI;
        LoadOperation<mytv> LoadOpM;     
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        public frmdsgandiaban(bool kt, string nv, string huyen,bool emp)
        {
            InitializeComponent();
            m_huyen = huyen.Trim();
            m_nv = nv.Trim();
            m_kt = kt;
            m_emp = emp;
            dien_dl();
        }
        public void dien_dl()
        {
            gridControl1.ShowLoadingPanel = true;
            
            EntityQuery<Mdiaban> Queryt = dstb.GetMadiabanTrimQuery();
            LoadOptuyen = dstb.Load(Queryt.Where(p => p.ma_huyen == m_huyen && p.kt == false).OrderBy(p => p.ten_tuyen), LoadOpTT_Complete, null);
            EntityQuery<Mdiaban> Query = dstb.GetMadiabanTrimQuery();
            LoadOptuyenkt = dstb.Load(Query.Where(p => p.ma_huyen == m_huyen && p.kt == true).OrderBy(p => p.ten_tuyen), LoadOpTTKT_Complete, null);
            EntityQuery<ds_codinh> QueryC = dstb.GetDs_codinhQuery();
            LoadOp = dstb.Load(QueryC.Where(p=>(p.ma_nvcs==null || p.ma_nvkt==null) && p.ma_huyen==m_huyen),null,null );


            EntityQuery<Gphone> QueryG = dstb.GetGphonesQuery();
            LoadOpG = dstb.Load(QueryG.Where(p => (p.ma_nvcs == null || p.ma_nvkt == null) && p.ma_huyen == m_huyen), null, null);
            EntityQuery<internet> QueryI = dstb.GetInternetsQuery();
            LoadOpI = dstb.Load(QueryI.Where(p => (p.ma_nvcs == null || p.ma_nvkt == null) && p.ma_huyen == m_huyen), null, null);
            EntityQuery<mytv> QueryM = dstb.GetMytvsQuery();
            LoadOpM = dstb.Load(QueryM.Where(p => (p.ma_nvcs == null || p.ma_nvkt == null) && p.ma_huyen == m_huyen), null, null);

            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            InvokeOperation<System.Nullable<int>> pr = db.Excute_DsGanDiaban(m_kt, m_nv, m_huyen, m_emp);
            pr.Completed += new EventHandler(GetData);

            if (App.kythuat)
                ma_nvcs.ReadOnly = true;
            else
                ma_nvkt.ReadOnly = true;
        }

        //void LoadOpC(LoadOperation<ds_codinh> lo)
        //{
        //    EntityQuery<Gphone> QueryG = dstb.GetGphonesQuery();
        //    LoadOpG = dstb.Load(QueryG.Where(p => (p.ma_nvcs == null || p.ma_nvkt == null) && p.ma_huyen == m_huyen), LoadOpG_C, null);

        //}
        //void LoadOpG_C(LoadOperation<Gphone> lo)
        //{
        //    EntityQuery<internet> QueryI = dstb.GetInternetsQuery();
        //    LoadOpI = dstb.Load(QueryI.Where(p => (p.ma_nvcs == null || p.ma_nvkt == null) && p.ma_huyen == m_huyen), LoadOpI_C, null);

        //}

        //void LoadOpI_C(LoadOperation<internet> lo)
        //{
        //    EntityQuery<mytv> QueryM = dstb.GetMytvsQuery();
        //    LoadOpM = dstb.Load(QueryM.Where(p => (p.ma_nvcs == null || p.ma_nvkt == null) && p.ma_huyen == m_huyen), LoadOpM_C, null);

        //}
        void LoadOpM_C(LoadOperation<mytv> lo)
        {
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            InvokeOperation<System.Nullable<int>> pr = db.Excute_DsGanDiaban(m_kt, m_nv, m_huyen, m_emp);
            pr.Completed += new EventHandler(GetData);
        }

        void GetData(object sender, EventArgs e)
        {
            this.gridControl1.ItemsSource = new GanDB(); // lay bang rong dua vao
            tableView1.DeleteRow(0);
            gridControl1.ShowLoadingPanel = true;
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            if (m_kt)
            {
                EntityQuery<rp_dsgan> Query = db.GetRp_dsganQuery();
                LoadOperation<rp_dsgan> LoadOp = db.Load(Query.OrderBy(p => p.ma_nvcs), LoadOp_Complete, null);
            }
            else
            {
                EntityQuery<rp_dsgan> Query = db.GetRp_dsganQuery();
                LoadOperation<rp_dsgan> LoadOp = db.Load(Query.OrderBy(p => p.ma_nvkt), LoadOp_Complete, null);
            }

        }

        void LoadOp_Complete(LoadOperation<rp_dsgan> lo)
        {
           // gridControl1.ItemsSource = lo.Entities;

            if (lo.Entities.Count() > 0)
            {
                //gridControl1.ItemsSource = lo.Entities;

                for (int i = 0; i < lo.Entities.Count(); i++)
                {
                    (this.gridControl1.ItemsSource as GanDB).Add(new Gan
                    {
                        so_dt = lo.Entities.ElementAt(i).so_dt,
                        ten_dktb = lo.Entities.ElementAt(i).ten_dktb == null ? "" : lo.Entities.ElementAt(i).ten_dktb,
                        dia_chitb = lo.Entities.ElementAt(i).dia_chitb == null ? "" : lo.Entities.ElementAt(i).dia_chitb,
                        dc_tbld = lo.Entities.ElementAt(i).dc_tbld == null ? "" : lo.Entities.ElementAt(i).dc_tbld,
                        ma_nvcs = lo.Entities.ElementAt(i).ma_nvcs == null ? "" : lo.Entities.ElementAt(i).ma_nvcs,
                        ma_nvkt = lo.Entities.ElementAt(i).ma_nvkt == null ? "" : lo.Entities.ElementAt(i).ma_nvkt,
                        ten_nvkt = lo.Entities.ElementAt(i).ten_nvkt == null ? "" : lo.Entities.ElementAt(i).ten_nvkt,
                        ten_nv = lo.Entities.ElementAt(i).ten_nv == null ? "" : lo.Entities.ElementAt(i).ten_nv
                    });
                }
            }

            gridControl1.ShowLoadingPanel = false;
            this.Title = "Danh sách tổng hợp kinh doanh kỹ thuật " + " - " + lo.Entities.Count().ToString() + " khách hàng";
        }

        void LoadOpTT_Complete(LoadOperation<Mdiaban> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbmanvcs.ItemsSource = lo.Entities;
                this.cmbmanvcs.DisplayMember = ("ten_tuyen").Trim();
                this.cmbmanvcs.ValueMember = "ma_tuyen";
            }
        }

        void LoadOpTTKT_Complete(LoadOperation<Mdiaban> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                this.cmbmanvkt.ItemsSource = lo.Entities;
                this.cmbmanvkt.DisplayMember = ("ten_tuyen").Trim();
                this.cmbmanvkt.ValueMember = "ma_tuyen";
            }
        }

        private void Save_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {            
            string sdt,m_ma_nvcs, m_ma_nvkt;
            gridControl1.ShowLoadingPanel = true;
            for (int i = 0; i < gridControl1.VisibleRowCount; i++)
            {
                sdt = gridControl1.GetCellValue(i, sodt).ToString().Trim();
                m_ma_nvkt = (gridControl1.GetCellValue(i, ma_nvkt) == null || gridControl1.GetCellValue(i, ma_nvkt).ToString().Trim() == "") ? S_null : gridControl1.GetCellValue(i, ma_nvkt).ToString();
                m_ma_nvcs = (gridControl1.GetCellValue(i, ma_nvcs) == null || gridControl1.GetCellValue(i, ma_nvcs).ToString().Trim() == "") ? S_null : gridControl1.GetCellValue(i, ma_nvcs).ToString();
                // Update ds_codinh
                for (int j = 0; j < LoadOp.Entities.Count(); j++)
                {
                    if (LoadOp.Entities.ElementAt(j).so_dt.Trim() == sdt)
                    {
                        if (App.kythuat)
                            LoadOp.Entities.ElementAt(j).ma_nvkt = m_ma_nvkt;
                        else
                            LoadOp.Entities.ElementAt(j).ma_nvcs = m_ma_nvcs;                        
                        break;
                    }
                }

                // Update Gphone
                for (int k = 0; k < LoadOpG.Entities.Count(); k++)
                {
                    if (LoadOpG.Entities.ElementAt(k).so_dt.Trim() == sdt)
                    {
                        if (App.kythuat)
                            LoadOpG.Entities.ElementAt(k).ma_nvkt = m_ma_nvkt;
                        else
                            LoadOpG.Entities.ElementAt(k).ma_nvcs = m_ma_nvcs;
                        break;
                    }
                }

                // Update Internet
                for (int h = 0; h < LoadOpI.Entities.Count(); h++)
                {
                    if (LoadOpI.Entities.ElementAt(h).user_name.Trim() == sdt)
                    {
                        if (App.kythuat)
                            LoadOpI.Entities.ElementAt(h).ma_nvkt = m_ma_nvkt;
                        else
                            LoadOpI.Entities.ElementAt(h).ma_nvcs = m_ma_nvcs;
                        break;
                    }
                }

                // Update MyTV
                for (int m = 0; m < LoadOpM.Entities.Count(); m++)
                {
                    if (LoadOpM.Entities.ElementAt(m).user_name.Trim() == sdt)
                    {
                        if (App.kythuat)
                            LoadOpM.Entities.ElementAt(m).ma_nvkt = m_ma_nvkt;
                        else
                            LoadOpM.Entities.ElementAt(m).ma_nvcs = m_ma_nvcs;
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

        private void Close_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            this.Close();
        }       

       
    }
}
