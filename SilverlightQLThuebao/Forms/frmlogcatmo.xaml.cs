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
    public partial class frmlogcatmo : DXWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        public frmlogcatmo()
        {
            InitializeComponent(); 
            Loaded +=new RoutedEventHandler(frmlogcatmo_Loaded);           
        }
        void frmlogcatmo_Loaded(object sender, RoutedEventArgs e)
        { 
            string m_sdt=txttim.Text.Trim();
            if (m_sdt != "")
            {
                gridControl1.ShowLoadingPanel = true;
                this.gridControl1.ItemsSource = new DSCatmo(); // lay bang rong dua vao
                tableView1.DeleteRow(0);
                EntityQuery<Catmo> Query = dstb.GetDataLogCatmoQuery(m_sdt);
                LoadOperation<Catmo> LoadOp = dstb.Load(Query.Where(p => p.so_dt == m_sdt), LoadOp_Complete, null);
            }
        }
   

        void LoadOp_Complete(LoadOperation<Catmo> lo)
        {
            string m_tenyc;
            if (lo.Entities.Count() > 0)
            {
                for (int i = 0; i < lo.Entities.Count(); i++)
                {
                    if (lo.Entities.ElementAt(i).mo == false)
                        m_tenyc = lo.Entities.ElementAt(i).ten_yc.Trim();
                    else
                        m_tenyc = "Hñy " + lo.Entities.ElementAt(i).ten_yc.Trim();

                    (this.gridControl1.ItemsSource as DSCatmo).Add(new Catmo()
                    {
                        card = lo.Entities.ElementAt(i).card == null ? 0 : lo.Entities.ElementAt(i).card,
                        dc_tbld = lo.Entities.ElementAt(i).dc_tbld == null ? "" : lo.Entities.ElementAt(i).dc_tbld,
                        dia_chitb = lo.Entities.ElementAt(i).dia_chitb == null ? "" : lo.Entities.ElementAt(i).dia_chitb,
                        dlu = lo.Entities.ElementAt(i).dlu == null ? 0 : lo.Entities.ElementAt(i).dlu,
                        en = lo.Entities.ElementAt(i).en == null ? 0 : lo.Entities.ElementAt(i).en,
                        frame = lo.Entities.ElementAt(i).frame == null ? 0 : lo.Entities.ElementAt(i).frame,
                        id = lo.Entities.ElementAt(i).id,
                        logic = lo.Entities.ElementAt(i).logic,
                        ma_huyen = lo.Entities.ElementAt(i).ma_huyen,
                        ma_yc = lo.Entities.ElementAt(i).ma_yc,
                        ten_yc = m_tenyc,
                        mo = lo.Entities.ElementAt(i).mo,
                        nguoi_mo = lo.Entities.ElementAt(i).nguoi_mo,
                        nguoi_yc = lo.Entities.ElementAt(i).nguoi_yc,
                        port = lo.Entities.ElementAt(i).port == null ? 0 : lo.Entities.ElementAt(i).port,
                        shell = lo.Entities.ElementAt(i).shell == null ? 0 : lo.Entities.ElementAt(i).shell,
                        slot = lo.Entities.ElementAt(i).slot == null ? 0 : lo.Entities.ElementAt(i).slot,
                        slp = lo.Entities.ElementAt(i).slp == null ? 0 : lo.Entities.ElementAt(i).slp,
                        so_dt = lo.Entities.ElementAt(i).so_dt,
                        ten_dkdb = lo.Entities.ElementAt(i).ten_dktb == null ? "" : lo.Entities.ElementAt(i).ten_dktb,
                        ten_dktb = lo.Entities.ElementAt(i).ten_dkdb == null ? "" : lo.Entities.ElementAt(i).ten_dkdb,
                        tg_mo = lo.Entities.ElementAt(i).tg_mo,
                        tg_yc = lo.Entities.ElementAt(i).tg_yc
                    });
                }
            }
            gridControl1.ShowLoadingPanel = false;
        }

    
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (txttim.Text.Trim() != "")
            {
                frmlogcatmo logcatmo = new frmlogcatmo();
                logcatmo.txttim.Text = txttim.Text.Trim();
                logcatmo.Width = this.ActualWidth;
                logcatmo.Height = this.ActualHeight;              
                this.Hide();
                logcatmo.Show();
            }
        }   
    }
}
