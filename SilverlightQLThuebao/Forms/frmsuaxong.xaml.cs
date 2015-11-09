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
using DevExpress.Xpf.Charts;
using System.Globalization;
using System.ServiceModel.DomainServices.Client;
using SilverlightQLThuebao.Web.Services;
using SilverlightQLThuebao.Web.Models;

namespace SilverlightQLThuebao
{
    public partial class frmsuaxong : DXWindow
    {
        List<slthuebao> thuebao = new List<slthuebao>();
        public frmsuaxong()
        {
            InitializeComponent();
            dngaykt.EditValue = DateTime.Now;
            dngaybd.EditValue = DateTime.Now.AddDays(-15);                   
        }

        void CreateData()
        {
            string m_huyen;
            grid.ShowLoadingPanel = true;
            grid1.ShowLoadingPanel = true;
            QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
            if (App.admin_119)
                m_huyen = "ALL";
            else
                m_huyen = "'" + App.nhomtd + "'";

               // m_huyen ="'"+ App.nhomtd.Replace(";","','")+"'";
           // MessageBox.Show(m_huyen);
            InvokeOperation<System.Nullable<int>> p = dstb.Excute_p_getsuaxong119(m_huyen,this.dngaybd.DateTime, this.dngaykt.DateTime);
            p.Completed += new EventHandler(Completed);

        }

        void Completed(object sende, EventArgs e)
        {
            get_data(); 
        }        

        
        void get_data()
        {
            //grid.ShowLoadingPanel = true;
            //grid1.ShowLoadingPanel = true;
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            if (App.admin_119)
            {
                EntityQuery<dssuaxong_119> Query = db.GetDssuaxong_119Query();
                LoadOperation<dssuaxong_119> LoadOp = db.Load(Query.Where(p=>p.bfinished==true).OrderByDescending(p => p.dtRecvTime), LoadOp_Complete, null);
            }
            else
            {
                EntityQuery<dssuaxong_119> Query = db.GetDssuaxong_119Query();
                LoadOperation<dssuaxong_119> LoadOp = db.Load(Query.Where(p =>App.nhomtd.Contains(p.ma_huyen) && p.bfinished==true).OrderByDescending(p => p.dtRecvTime), LoadOp_Complete, null);
            }

            EntityQuery<tkloai119> Querys = db.GetTkloai119Query();
            LoadOperation<tkloai119> LoadOps = db.Load(Querys.OrderBy(p => p.istatusID), LoadOps_Complete, null);
        }

        void LoadOp_Complete(LoadOperation<dssuaxong_119> lo)
        {
            grid.ItemsSource = lo.Entities;
            grid.GroupBy("ma_huyen");
            grid.ExpandAllGroups();
            grid.ShowLoadingPanel = false;
            CreateChart();
            chart.Animate();    
        }

        void LoadOps_Complete(LoadOperation<tkloai119> lo)
        {
            grid1.ItemsSource = lo.Entities;         
            grid1.ShowLoadingPanel = false;           
        }

        void chart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            e.LegendText = ((slthuebao)e.SeriesPoint.Tag).Name;
        }

        void CreateChart()
        {
            double mtong = 0;
            QLThuebaoDomainContext db = new QLThuebaoDomainContext();
            EntityQuery<tk119> Qr = db.GetTk119Query();
            LoadOperation<tk119> Load = db.Load(Qr.OrderBy(p => p.ID), lo =>
            {
                if (lo.Entities.Count() > 0)
                {
                    for (int i = 0; i < lo.Entities.Count(); i++)
                    {
                        double sl = Convert.ToDouble(lo.Entities.ElementAt(i).suaxong, CultureInfo.InvariantCulture);
                        double slx = Convert.ToDouble(lo.Entities.ElementAt(i).baohong, CultureInfo.InvariantCulture);
                        string name = lo.Entities.ElementAt(i).loai.Trim();                        
                        thuebao.Add(new slthuebao(name, sl,slx));
                        mtong += sl;
                    }
                    chart.Diagram.Series[0].DataSource = thuebao;
                    chart.Diagram.Series[1].DataSource = thuebao;
                    // ltongc.Content = "Tổng : " + mtong.ToString() + " tính theo phương pháp 60 ngày có nạp thẻ trên địa bàn tỉnh";
                    //TT.Content = "";
                    chart.Diagram.Series[0].LabelsVisibility = true;
                    chart.Animate();                    
                }


            }, false
                );



        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            CreateData();
        }

       

    }

    public class slthuebao
    {
        readonly double sl;
        readonly double slx;
        readonly string name;

        public double SL { get { return sl; } }
        public double SLx { get { return slx; } }
        public string Name { get { return name; } }

        public slthuebao(string name, double sl, double slx)
        {
            this.name = name;
            this.sl = sl;
            this.slx = slx;
        }
    }

}
