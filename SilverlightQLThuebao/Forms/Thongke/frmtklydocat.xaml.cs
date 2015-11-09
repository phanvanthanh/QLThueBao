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
using SilverlightQLThuebao.Web.Services;
using SilverlightQLThuebao.Web.Models;
using System.ServiceModel.DomainServices.Client;

namespace SilverlightQLThuebao
{
    public partial class frmtklydocat : DXWindow
    {
        string mloai, mbd, mhuyen;
        public frmtklydocat()
        {
            InitializeComponent();
            dngaybd.EditValue = App.Current_d.AddDays(-7);
            dngaykt.EditValue = App.Current_d;
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {

            gridControl1.ShowLoadingPanel = true;
            gridControl1.ItemsSource = null;
            QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
            InvokeOperation<System.Nullable<int>> p = dstb.Excute_p_tklydocat(dngaybd.DateTime, dngaykt.DateTime);
            p.Completed += new EventHandler(Completed);
        }
       


        void Completed(object sende, EventArgs e)
        {
            string m_huyen = App.nhomtd;
            QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
            EntityQuery<rp_tklydocat> Query = dstb.GetRp_tklydocatQuery();
            LoadOperation<rp_tklydocat> LoadOp = dstb.Load(Query.OrderBy(p => p.ma_dv), LoadOp_Complete, null);
        }

        void LoadOp_Complete(LoadOperation<rp_tklydocat> lo)
        {            
            gridControl1.ItemsSource = lo.Entities;
            gridControl1.GroupBy("ten_dv");
            gridControl1.ExpandAllGroups();
            gridControl1.ShowLoadingPanel = false;
        }

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            int rowHandle = tableView1.FocusedRowHandle;
            if (Convert.ToInt32(gridControl1.GetFocusedValue()) == 0)
                return;            
            mhuyen = gridControl1.GetCellValue(rowHandle, "ma_dv").ToString().Trim();
            mbd = gridControl1.GetCellValue(rowHandle, "ma_ld").ToString().Trim();
            string mcolumn = tableView1.FocusedColumn.FieldName;
            if (mcolumn == "slcd")       
                mloai = "C";
            if (mcolumn == "slgp")
                mloai = "G";
            if (mcolumn == "slmy")
                mloai = "M";
            if (mcolumn == "slint")
                mloai = "I";
            if (mcolumn == "slftth")
                mloai = "F";   

            frmdataviewstop frm = new frmdataviewstop(mloai, mbd, mhuyen, dngaybd.DateTime, dngaykt.DateTime);
            frm.Width = this.ActualWidth;
            frm.Height = this.ActualHeight;
            frm.Show();
        }


    }
}
