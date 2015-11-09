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
    public partial class frmdiabancs : DXWindow
    {
        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        public frmdiabancs()
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
            EntityQuery<ma_diaban> Query = dbs.GetMa_diabanQuery();
            LoadOperation<ma_diaban> Load = dbs.Load(Query.Where(p => p.ma_huyen == App.ma_huyen && p.kt == App.kythuat), lo => { gridControl1.ItemsSource = lo.Entities; }, null);             
        }

        private void XoaButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridControl1.GetFocusedRow() != null)
            {
                string ma = gridControl1.GetFocusedRowCellValue(ma_tuyen).ToString().Trim();
                MessageBoxResult result = MessageBox.Show("Muốn xóa tuyến " + ma + " ?", "Xác nhận", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    if (App.kythuat)
                    {
                        EntityQuery<manvcs> Query = db.GettuyenktcsQuery(App.ma_huyen, ma);
                        LoadOperation<manvcs> LoadOp = db.Load(Query, CheckCompleted, true);
                    }
                    else
                    {
                        EntityQuery<manvcs> Query = db.GetManvcsQuery(App.ma_huyen, ma);
                        LoadOperation<manvcs> LoadOp = db.Load(Query, CheckCompleted, true);
                    }
                }
                else
                    return;
            }
            else
                MessageBox.Show("Chưa chọn tuyến cần xóa !");
        }

        void CheckCompleted(LoadOperation<manvcs> lo)
        {
            if (lo.Entities.Count() > 0)
                MessageBox.Show("Dữ liệu đang sử dụng không thể xóa tuyến này !");
            else
            {
                string ma = gridControl1.GetFocusedRowCellValue(ma_tuyen).ToString().Trim();
                EntityQuery<ma_diaban> Query = db.GetMa_diabanQuery();
                LoadOperation<ma_diaban> LoadOp = db.Load(Query.Where(p => p.ma_tuyen.Trim() == ma), DeleteCompleted, true);
            }
        }

        private void DeleteCompleted(LoadOperation<ma_diaban> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                ma_diaban dl = lo.Entities.First();
                db.ma_diabans.Remove(dl);
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
            frmnhapdiaban frm = new frmnhapdiaban(false);
            frm.Show();
        }

        private void brSua_ItemClick(object sender, RoutedEventArgs e)
        {
            if (gridControl1.GetFocusedRow() != null)
            {
                frmnhapdiaban frm = new frmnhapdiaban(true);
                frm.txtmanv.Text = gridControl1.GetFocusedRowCellValue(ma_tuyen).ToString().Trim();
                frm.txtten.Text = gridControl1.GetFocusedRowCellValue(ten_tuyen).ToString().Trim();
                frm.checkEdit1.IsChecked = App.kythuat;
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
