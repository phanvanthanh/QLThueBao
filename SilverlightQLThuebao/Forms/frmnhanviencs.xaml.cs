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
using DevExpress.Xpf.Bars;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;


namespace SilverlightQLThuebao
{
    public partial class frmnhanviencs : DXWindow
    {
        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        public frmnhanviencs()
        {
            InitializeComponent();
            laythongtin();
            brThem.ItemClick += new ItemClickEventHandler(brThem_ItemClick);
            brSua.ItemClick += new ItemClickEventHandler(brSua_ItemClick);
            brXoa.ItemClick += new ItemClickEventHandler(XoaButton_Click);           
            brDong.ItemClick += new ItemClickEventHandler(brDong_ItemClick);            
            
        }

        void laythongtin()
        {
            QLThuebaoDomainContext dbs = new QLThuebaoDomainContext();
            EntityQuery<nhanvien_cs> Query = dbs.Getnhanvien_csQuery();
            LoadOperation<nhanvien_cs> Load = dbs.Load(Query.Where(p => p.ma_huyen == App.ma_huyen && p.kt==App.kythuat), lo => { gridControl1.ItemsSource = lo.Entities; }, null);             
        }

        private void XoaButton_Click(object sender, RoutedEventArgs e)
        {
            //if (gridControl1.GetFocusedRow() != null)
            //{
            //    string ma = gridControl1.GetFocusedRowCellValue(ma_nvcs).ToString().Trim();
            //    MessageBoxResult result = MessageBox.Show("Muốn xóa cán bộ chăm sóc " + ma + " ?", "Xác nhận", MessageBoxButton.OKCancel);
            //    if (result == MessageBoxResult.OK)
            //    {
            //        EntityQuery<manvcs> Query = db.GetManvcsQuery(App.ma_huyen, ma);
            //        LoadOperation<manvcs> LoadOp = db.Load(Query, CheckCompleted, true);
            //    }
            //    else
            //        return;
            //}
            //else
            //    MessageBox.Show("Chưa chọn địa bàn cần xóa !");
            MessageBox.Show("Chức năng này tạm thời khóa lại !");
        }

        void CheckCompleted(LoadOperation<manvcs> lo)
        {
            if (lo.Entities.Count() > 0)
                MessageBox.Show("Dữ liệu đang sử dụng không thể xóa cán bộ chăm sóc khách hàng này !");
            else
            {
                string ma = gridControl1.GetFocusedRowCellValue(ma_nvcs).ToString().Trim();
                EntityQuery<nhanvien_cs> Query = db.Getnhanvien_csQuery();
                LoadOperation<nhanvien_cs> LoadOp = db.Load(Query.Where(p => p.ma_nvcs.Trim() == ma), DeleteCompleted, true);
            }
        }

        private void DeleteCompleted(LoadOperation<nhanvien_cs> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                nhanvien_cs dl = lo.Entities.First();
                db.nhanvien_cs.Remove(dl);
                db.SubmitChanges(OnSubmitCompleted, null);
            }
        }

        private void OnSubmitCompleted(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            laythongtin();
        }

        private void brThem_ItemClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            frmnhapnvcs frm = new frmnhapnvcs(false,"");
            frm.Show();
        }

        private void brSua_ItemClick(object sender, RoutedEventArgs e)
        {
            if (gridControl1.GetFocusedRow() != null)
            {
                string db = gridControl1.GetFocusedRowCellValue(diaban)==null ? "":gridControl1.GetFocusedRowCellValue(diaban).ToString().Trim();
                if (db.Length > 1)
                    db = db.Substring(1, db.Length - 1);

                frmnhapnvcs frm = new frmnhapnvcs(true,db);
                frm.txtmanv.Text = gridControl1.GetFocusedRowCellValue(ma_nvcs).ToString().Trim();
                frm.txtten.Text = gridControl1.GetFocusedRowCellValue(ten_nv).ToString().Trim();
                frm.txtphone.Text = gridControl1.GetFocusedRowCellValue(phone)==null? "": gridControl1.GetFocusedRowCellValue(phone).ToString().Trim();
                frm.checkEdit1.IsChecked = gridControl1.GetFocusedRowCellValue(kt)==null? false: Convert.ToBoolean(gridControl1.GetFocusedRowCellValue(kt));
                this.Close(); 
                frm.Show();
            }
            else
                MessageBox.Show("Chưa chọn nhân viên cần sửa !");
        }       

        private void brDong_ItemClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
