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
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;

namespace SilverlightQLThuebao
{
    public partial class frmabout : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        public frmabout()
        {
            InitializeComponent();            
        }

        

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            //EntityQuery<ds_codinh> Query = dstb.GetDs_codinhQuery();
            //LoadOperation<ds_codinh> LoadOp = dstb.Load(Query, LoadOp_Complete, null);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            //dstb.SubmitChanges(OnSubmitCompleted2, true);
        }
        void LoadOp_Complete(LoadOperation<ds_codinh> lo)
        {
            for (int i = 0; i < lo.Entities.Count(); i++)
            {
                lo.Entities.ElementAt(i).tenkhkd = FunAndPro.KhongDau(lo.Entities.ElementAt(i).ten_dktb.Trim());
                lo.Entities.ElementAt(i).dckd = FunAndPro.KhongDau(lo.Entities.ElementAt(i).dia_chitb.Trim());
            }
            MessageBox.Show(lo.Entities.Count().ToString());
           // dstb.SubmitChanges(OnSubmitCompleted, true);
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
                EntityQuery<Gphone> Query = dstb.GetGphonesQuery();
                LoadOperation<Gphone> LoadOp = dstb.Load(Query, LoadOpG_Complete, null); 
            }
        }

        void LoadOpG_Complete(LoadOperation<Gphone> lo)
        {
            for (int i = 0; i < lo.Entities.Count(); i++)
            {
                lo.Entities.ElementAt(i).tenkhkd = FunAndPro.KhongDau(lo.Entities.ElementAt(i).ten_dktb.Trim());
                lo.Entities.ElementAt(i).dckd = FunAndPro.KhongDau(lo.Entities.ElementAt(i).dia_chitb.Trim());
            }
            dstb.SubmitChanges(OnSubmitCompleted1, true);
        }

        private void OnSubmitCompleted1(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
            {
                EntityQuery<mytv> Query = dstb.GetMytvsQuery();
                LoadOperation<mytv> LoadOp = dstb.Load(Query, LoadOpM_Complete, null);
            }
        }

        void LoadOpM_Complete(LoadOperation<mytv> lo)
        {
            for (int i = 0; i < lo.Entities.Count(); i++)
            {
                lo.Entities.ElementAt(i).tenkhkd = FunAndPro.KhongDau(lo.Entities.ElementAt(i).ten_dktb.Trim());
                lo.Entities.ElementAt(i).dckd = FunAndPro.KhongDau(lo.Entities.ElementAt(i).dia_chitb.Trim());
            }
            dstb.SubmitChanges(OnSubmitCompleted2, true);
        }

        private void OnSubmitCompleted2(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
            {
                MessageBox.Show("Da cap nhat xong !");
            }
        }
    }
}

