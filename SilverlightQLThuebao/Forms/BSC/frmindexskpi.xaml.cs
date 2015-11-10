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
    public partial class frmnewskpi : DXWindow
    {
        LoadOperation<BSCT> Load;
        QLThuebaoDomainContext db = new QLThuebaoDomainContext();

        public frmnewskpi()
        {
            InitializeComponent();
            get_data();
        }

        private void sKPIDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        void get_data()
        {
            this.gridControl1.ItemsSource = new BSC_tinh(); // lay bang rong dua vao
            tableView1.DeleteRow(0);
            gridControl1.ShowLoadingPanel = true;

            EntityQuery<BSCT> Query = db.GetAllSKpiQuery(); //todo lay theo nhan vien duoc chon
            Load = db.Load(Query, LoadOpComplete, null);

        }

        void LoadOpComplete(LoadOperation<BSCT> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                for (int i = 0; i < lo.Entities.Count(); i++)
                {
                    (this.gridControl1.ItemsSource as BSC_tinh).Add(new BSCT
                    {
                        ma_kpi = lo.Entities.ElementAt(i).ma_kpi,
                        ten_kpi = lo.Entities.ElementAt(i).ten_kpi.Trim(),
                        ten_kpo = lo.Entities.ElementAt(i).ten_kpo.Trim(),
                        dvt = lo.Entities.ElementAt(i).dvt,
                        loai_dvt = lo.Entities.ElementAt(i).loai_dvt
                    });
                }
            }
            gridControl1.GroupBy("ten_kpo");
            gridControl1.ExpandAllGroups();
           
            gridControl1.ShowLoadingPanel = false;
        }

        private void btnaddskpi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
