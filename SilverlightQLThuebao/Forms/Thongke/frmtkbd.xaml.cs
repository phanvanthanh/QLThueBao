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
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;

namespace SilverlightQLThuebao
{
    public partial class frmtkbd : DXWindow
    {
        string mloai, mbd,mhuyen;
        public frmtkbd()
        {
            InitializeComponent();
            dngaybd.EditValue = App.Current_d.AddDays(-7);
            dngaykt.EditValue = App.Current_d;
            
        }
       
        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            gridmy.ShowLoadingPanel = true;
            QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
            InvokeOperation<System.Nullable<int>> p= dstb.Excute_p_tktonghop(dngaybd.DateTime, dngaykt.DateTime);                     
            p.Completed += new EventHandler(Completed);         
        }


        void Completed(object sende, EventArgs e)
        {
            string m_huyen = App.nhomtd.Length>30 ? App.nhomtd + ";WWW": App.nhomtd;
            QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
            EntityQuery<rp_tktonghop> Query = dstb.GetRp_tktonghopQuery();
            LoadOperation<rp_tktonghop> LoadOp = dstb.Load(Query.Where(p => m_huyen.Contains(p.ma_dv.Trim())).OrderBy(p => p.ma_dv), LoadOp_Complete, null);
        }

        void LoadOp_Complete(LoadOperation<rp_tktonghop> lo)
        {
            gridmy.ItemsSource = lo.Entities;
            gridmy.ShowLoadingPanel = false;
        }

        private void tableView1_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            if (Convert.ToInt32(gridmy.GetFocusedValue()) == 0)
                return;

            int rowHandle = tableView1.FocusedRowHandle;
            mhuyen = gridmy.GetCellValue(rowHandle, "ma_dv").ToString().Trim();            
            
            string mcolumn =tableView1.FocusedColumn.FieldName;           
            if (mcolumn == "hmcd" || mcolumn == "ngungcd" || mcolumn == "catcd" || mcolumn == "hdlcd" || mcolumn == "thcd")
            {
                mloai = "C";
                switch(mcolumn)
                {
                    case "hmcd":
                        mbd = "M";
                        break;
                    case "ngungcd":
                        mbd = "N";
                        break;
                    case "catcd":
                        mbd = "C";
                        break;
                    case "hdlcd":
                        mbd = "H";
                        break;
                    case "thcd":
                        mbd = "T";
                        break;
                }
            }

            if (mcolumn == "hmgp" || mcolumn == "ngunggp" || mcolumn == "catgp" || mcolumn == "hdlgp" || mcolumn == "thgp")
            {
                mloai = "G";
                switch (mcolumn)
                {
                    case "hmgp":
                        mbd = "M";
                        break;
                    case "ngunggp":
                        mbd = "N";
                        break;
                    case "catgp":
                        mbd = "C";
                        break;
                    case "hdlgp":
                        mbd = "H";
                        break;
                    case "thgp":
                        mbd = "T";
                        break;
                }
            }

            if (mcolumn == "hmgpt" || mcolumn == "ngunggpt" || mcolumn == "catgpt" || mcolumn == "hdlgpt" || mcolumn == "thgpt")
            {
                mloai = "GT";
                switch (mcolumn)
                {
                    case "hmgpt":
                        mbd = "M";
                        break;
                    case "ngunggpt":
                        mbd = "N";
                        break;
                    case "catgpt":
                        mbd = "C";
                        break;
                    case "hdlgpt":
                        mbd = "H";
                        break;
                    case "thgpt":
                        mbd = "T";
                        break;
                }
            }

            if (mcolumn == "hmmy" || mcolumn == "ngungmy" || mcolumn == "catmy" || mcolumn == "hdlmy" || mcolumn == "thmy")
            {
                mloai = "M";
                switch (mcolumn)
                {
                    case "hmmy":
                        mbd = "M";
                        break;
                    case "ngungmy":
                        mbd = "N";
                        break;
                    case "catmy":
                        mbd = "C";
                        break;
                    case "hdlmy":
                        mbd = "H";
                        break;
                    case "thmy":
                        mbd = "T";
                        break;
                }
            }

            if (mcolumn == "hmint" || mcolumn == "ngungint" || mcolumn == "catint" || mcolumn == "catnguint" || mcolumn == "hdlint" || mcolumn == "thint")
            {
                mloai = "I";
                switch (mcolumn)
                {
                    case "hmint":
                        mbd = "M";
                        break;
                    case "ngungint":
                        mbd = "N";
                        break;
                    case "catint":
                        mbd = "C";
                        break;
                    case "catnguint":
                        mbd = "S";
                        break;
                    case "hdlint":
                        mbd = "H";
                        break;
                    case "thint":
                        mbd = "T";
                        break;
                }
            }

            if (mcolumn == "hmftth" || mcolumn == "ngungftth" || mcolumn == "catftth" || mcolumn == "catnguftth" || mcolumn == "hdlftth" || mcolumn == "thftth")
            {
                mloai = "F";
                switch (mcolumn)
                {
                    case "hmftth":
                        mbd = "M";
                        break;
                    case "ngungftth":
                        mbd = "N";
                        break;
                    case "catftth":
                        mbd = "C";
                        break;
                    case "catnguftth":
                        mbd = "S";
                        break;
                    case "hdlftth":
                        mbd = "H";
                        break;
                    case "thftth":
                        mbd = "T";
                        break;
                }
            }

            frmdataview frm = new frmdataview(mloai,mbd,mhuyen,dngaybd.DateTime,dngaykt.DateTime);
            frm.Width = this.ActualWidth;
            frm.Height = this.ActualHeight;
            frm.Show();
        }

    }
}
