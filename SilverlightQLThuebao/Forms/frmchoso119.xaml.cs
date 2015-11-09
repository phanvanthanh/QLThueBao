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
    public partial class frmchoso119 : DXWindow
    {
        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        string batdau_119;
        public frmchoso119()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            switch (txtdv.Text.ToUpper())
            {
                case "TVH":
                    batdau_119 = "1";
                    break;
                case "CLG":
                    batdau_119 = "2";
                    break;
                case "TCN":
                    batdau_119 = "9";
                    break;
                case "CKE":
                    batdau_119 = "7";
                    break;
                case "CTH":
                    batdau_119 = "4";
                    break;
                case "TCU":
                    batdau_119 = "6";
                    break;
                case "CNG":
                    batdau_119 = "5";
                    break;
                default:
                    batdau_119 = "8";
                    break;
            }
            //EntityQuery<mytv> Query = db.GetMytvsQuery();
            //LoadOperation<mytv> LoadOp = db.Load(Query.Where(p=>p.ma_huyen==txtdv.Text.Trim()),LoadOpComplete, null );                    

            EntityQuery<internet> Query1 = db.GetInternetsQuery();
            LoadOperation<internet> LoadOp1 = db.Load(Query1.Where(p => p.so_119==null && p.ma_dv.Trim() == "ADSL"), LoadOpCompleteAN, null);
        }

        //void LoadOpComplete(LoadOperation<mytv> lo) 
        //{
        //    if (lo.Entities.Count() > 0)
        //    {
        //        for (int i = 0; i < lo.Entities.Count(); i++)                
        //            lo.Entities.ElementAt(i).so_119 = batdau_119 + "3" + i.ToString().Trim().PadLeft(5, '0');
        //    }
        //    EntityQuery<internet> Query1 = db.GetInternetsQuery();
        //    LoadOperation<internet> LoadOp1 = db.Load(Query1.Where(p => p.ma_huyen == txtdv.Text.Trim() && p.ma_dv.Trim() == "ADSL"), LoadOpCompleteA, null);
        //}

        void LoadOpCompleteAN(LoadOperation<internet> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                for (int i = 0; i < lo.Entities.Count(); i++)
                    lo.Entities.ElementAt(i).so_119 = batdau_119 + "1" + i.ToString().Trim().PadLeft(5, '0');
            }
            EntityQuery<internet> Query1 = db.GetInternetsQuery();
            LoadOperation<internet> LoadOp1 = db.Load(Query1.Where(p => p.so_119==null && p.ma_dv.Trim() == "FIBER"), LoadOpCompleteBN, null);
        }

        void LoadOpCompleteBN(LoadOperation<internet> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                for (int i = 0; i < lo.Entities.Count(); i++)
                    lo.Entities.ElementAt(i).so_119 = batdau_119 + "2" + i.ToString().Trim().PadLeft(5, '0');
            }
            db.SubmitChanges(OnSubmitCompleted, true);
        }


        // void LoadOpCompleteA(LoadOperation<internet> lo) 
        //{
        //    if (lo.Entities.Count() > 0)
        //    {
        //        for (int i = 0; i < lo.Entities.Count(); i++)
        //            lo.Entities.ElementAt(i).so_119 = batdau_119 + "1" + i.ToString().Trim().PadLeft(5, '0');             
        //    }
        //    EntityQuery<internet> Query1 = db.GetInternetsQuery();
        //    LoadOperation<internet> LoadOp1 = db.Load(Query1.Where(p => p.ma_huyen == txtdv.Text.Trim() && p.ma_dv.Trim() == "FIBER"), LoadOpCompleteB, null);
        //}

         //void LoadOpCompleteB(LoadOperation<internet> lo)
         //{
         //    if (lo.Entities.Count() > 0)
         //    {
         //        for (int i = 0; i < lo.Entities.Count(); i++)
         //            lo.Entities.ElementAt(i).so_119 = batdau_119 + "2" + i.ToString().Trim().PadLeft(5, '0');
         //    }
         //    db.SubmitChanges(OnSubmitCompleted, true);
         //}


        private void OnSubmitCompleted(SubmitOperation so)
        {
            if (so.HasError)
            {
                MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
                so.MarkErrorAsHandled();
            }
            else
                MessageBox.Show("Cho xong !");
        }
        
    }
}
