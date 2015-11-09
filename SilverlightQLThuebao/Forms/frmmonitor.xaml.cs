using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Resources;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;

namespace SilverlightQLThuebao
{
    public partial class frmmonitor : ChildWindow
    {
        QLThuebaoDomainContext dstb = new QLThuebaoDomainContext();
        LoadOperation<Catmo> LoadOp;     
        LoadOperation<Catmo> LoadOpD;
        LoadOperation<cat_mo> LoadOpR;
        SolidColorBrush redBrush;
        SolidColorBrush whiteBrush;
        bool m_speaker;
        string m_huyen;
       //int thoigian;
        public frmmonitor() 
        {
            InitializeComponent();
            redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Red;
            whiteBrush = new SolidColorBrush();
            whiteBrush.Color = Colors.Green;
            m_speaker = true;             
            CallTimer();
        }


        public void CallTimer()
        {
            DispatcherTimer Timer = new DispatcherTimer();         
            Timer.Interval = new TimeSpan(0, 0, 0, 6);
            Timer.Tick += new EventHandler(GetData);
            Timer.Start();
        }
        void GetData(object sender, EventArgs e)
        {
           // gridControl1.ShowLoadingPanel = true;
            EntityQuery<Catmo> Query = dstb.GetDataCatmoQuery();
            LoadOp = dstb.Load(Query.OrderBy(p => p.ma_huyen), lo=>
                {
                    if (lo.Entities.Count()>0)
                    {   
                        DispatcherTimer Timer1 = new DispatcherTimer();
                        Timer1.Interval = new TimeSpan(0, 0, 0, 1);
                        Timer1.Tick += new EventHandler(ChangeLed);
                        Timer1.Start();
                        DispatcherTimer Timer2 = new DispatcherTimer();
                        Timer2.Interval = new TimeSpan(0, 0, 0, 2);
                        Timer2.Tick += new EventHandler(ClearF);
                        Timer2.Start();
                        if (m_speaker)
                        {
                            media.Play();
                            media.Position = System.TimeSpan.FromSeconds(0);
                        }
                        else
                            media.Stop();
                    }
                }, null);         
        }

        void ChangeLed(object sender, EventArgs e)
        {
           
            for (int i = 0; i < LoadOp.Entities.Count(); i++)
			{
                string caseSwitch = LoadOp.Entities.ElementAt(i).ma_huyen;    
                
                switch (caseSwitch)
                {
                    case "TVH":
                        {
                            TVH.Fill = redBrush;                           
                            break;
                        }
                    case "CLG":
                        {                           
                            CLG.Fill = redBrush;                         
                            break;
                        }
                    case "TCN":
                        {                            
                            TCN.Fill = redBrush;                         
                            break;
                        }
                    case "CKE":
                        {                            
                            CKE.Fill = redBrush;                         
                            break;
                        }
                    case "CTH":
                        {                            
                            CTH.Fill = redBrush;                         
                            break;
                        }
                    case "TCU":
                        {                            
                            TCU.Fill = redBrush;                         
                            break;
                        }
                    case "CNG":
                        {                            
                            CNG.Fill = redBrush;                         
                            break;
                        }
                    case "DHI":
                        {                            
                            DHI.Fill = redBrush;
                            break;
                        }

                    default:
                        //Console.WriteLine("Default case");
                        break;
                }

			} 
        }

        void ClearF(object sender, EventArgs e)
        {
            TVH.Fill = whiteBrush;
            CLG.Fill = whiteBrush;
            TCN.Fill = whiteBrush;
            CKE.Fill = whiteBrush;
            CTH.Fill = whiteBrush;
            TCU.Fill = whiteBrush;
            CNG.Fill = whiteBrush;
            DHI.Fill = whiteBrush;
        }

       
        void FillData(string huyen)
        {
            gridControl1.ShowLoadingPanel = true;
            this.gridControl1.ItemsSource = new DSCatmo(); // lay bang rong dua vao
            tableView1.DeleteRow(0);
            m_huyen = huyen;
            EntityQuery<cat_mo> Query = dstb.GetCat_moQuery();
            LoadOpR = dstb.Load(Query, LoadOpR_Complete, null);
            
        }

        //private void OnSubmitCompletedS(SubmitOperation so)
        //{
        //    if (so.HasError)
        //    {
        //        MessageBox.Show(string.Format("Submit Failed: {0}", so.Error.Message));
        //        so.MarkErrorAsHandled();
        //    }
        //    else
        //    {
        //        gridControl1.ShowLoadingPanel = true;
        //        this.gridControl1.ItemsSource = new DSCatmo(); // lay bang rong dua vao
        //        tableView1.DeleteRow(0);                
        //        EntityQuery<cat_mo> Query = dstb.GetCat_moQuery();
        //        LoadOpR = dstb.Load(Query, LoadOpR_Complete, null);
        //    }
        //}

        //void FillData1(string huyen)
        //{
        //    gridControl1.ShowLoadingPanel = true;
        //    this.gridControl1.ItemsSource = new DSCatmo(); // lay bang rong dua vao
        //    tableView1.DeleteRow(0);
        //    m_huyen = huyen;
        //    EntityQuery<cat_mo> Query = dstb.GetCat_moQuery();
        //    LoadOpR = dstb.Load(Query, LoadOpR_Complete, null);
        //}

        void LoadOpR_Complete(LoadOperation<cat_mo> lo)
        {
            if (chkall.IsChecked == true)
            {
                EntityQuery<Catmo> Query = dstb.GetDataCatmoQuery();
                LoadOpD = dstb.Load(Query.OrderBy(p => p.ma_huyen), LoadOp_Complete, null);
            }
            else
            {
                EntityQuery<Catmo> Query = dstb.GetDataCatmoQuery();
                LoadOpD = dstb.Load(Query.Where(p => p.ma_huyen == m_huyen).OrderBy(p => p.ma_huyen), LoadOp_Complete, null);
            }
            gridControl1.ShowLoadingPanel = false;
        }

        void LoadOp_Complete(LoadOperation<Catmo> lo)
        {
           // string m_tenyc;
            if (lo.Entities.Count() > 0)
            {
                for (int i = 0; i < lo.Entities.Count(); i++)
                {                    
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
                        ten_yc = lo.Entities.ElementAt(i).mo == false ? lo.Entities.ElementAt(i).ten_yc.Trim() : "Hñy " + lo.Entities.ElementAt(i).ten_yc.Trim(),
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
                gridControl1.ShowLoadingPanel = false;                           
            }
            gridControl1.ShowLoadingPanel = false;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            FunAndPro callF = new FunAndPro();
            callF.GetDateTime();
            string m_sdt,m_mayc;
            for (int i = 0; i < gridControl1.VisibleRowCount; i++)
            {                
                if (Convert.ToBoolean(gridControl1.GetCellValue(i, check)) ==true)
                {
                    m_sdt=gridControl1.GetCellValue(i, sodt).ToString().Trim();
                    m_mayc=gridControl1.GetCellValue(i, ma_yc).ToString().Trim();
                    for (int j = 0; j < LoadOpR.Entities.Count(); j++)
                    {
                        if (LoadOpR.Entities.ElementAt(j).so_dt.Trim() == m_sdt && LoadOpR.Entities.ElementAt(j).ma_yc.Trim() == m_mayc)
                        {
                            cat_mo_log cml = new cat_mo_log
                            {
                                card = LoadOpR.Entities.ElementAt(j).card,
                                dc_tbld = LoadOpR.Entities.ElementAt(j).dc_tbld,
                                dia_chitb = LoadOpR.Entities.ElementAt(j).dia_chitb,
                                dlu = LoadOpR.Entities.ElementAt(j).dlu,
                                en = LoadOpR.Entities.ElementAt(j).en,
                                frame = LoadOpR.Entities.ElementAt(j).frame,
                                logic = true,
                                ma_huyen = LoadOpR.Entities.ElementAt(j).ma_huyen,
                                ma_yc = LoadOpR.Entities.ElementAt(j).ma_yc,
                                mo = LoadOpR.Entities.ElementAt(j).mo,
                                nguoi_mo = App.User_name,
                                nguoi_yc = LoadOpR.Entities.ElementAt(j).nguoi_yc,
                                port = LoadOpR.Entities.ElementAt(j).port,
                                shell = LoadOpR.Entities.ElementAt(j).shell,
                                slot = LoadOpR.Entities.ElementAt(j).slot,
                                slp = LoadOpR.Entities.ElementAt(j).slp,
                                so_dt = LoadOpR.Entities.ElementAt(j).so_dt,
                                ten_dkdb = LoadOpR.Entities.ElementAt(j).ten_dkdb,
                                ten_dktb = LoadOpR.Entities.ElementAt(j).ten_dktb,
                                tg_mo = App.Current_d,
                                tg_yc = LoadOpR.Entities.ElementAt(j).tg_yc
                            };
                            dstb.cat_mo_logs.Add(cml); 
                            cat_mo cm = LoadOpR.Entities.ElementAt(j);
                            dstb.cat_mos.Remove(cm);
                        }
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
                for (int i = 0; i < gridControl1.VisibleRowCount; i++)
                {
                    if (Convert.ToBoolean(gridControl1.GetCellValue(i, check)) == true)
                    {                       
                        tableView1.DeleteRow(i);
                    }
                }
                MessageBox.Show("Đã thực hiện !");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
           this.DialogResult = false;            
        }   

        private void TVH_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillData("TVH");
        }

        private void CLG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillData("CLG");
        }

        private void TCN_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillData("TCN");
        }

        private void CKE_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillData("CKE");
        }

        private void CTH_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillData("CTH");
        }

        private void TCU_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillData("TCU");
        }

        private void CNG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillData("CNG");
        }

        private void DHI_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillData("DHI");
        }

        private void speaker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (m_speaker)
            {
                speaker.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/speakerSilent.png", UriKind.Relative));
                m_speaker = false;
                media.Stop();
            }
            else
            {
                speaker.Source = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/speaker.png", UriKind.Relative));
                m_speaker = true;
                if (LoadOp.Entities.Count() > 0)
                {
                    media.Play();
                    media.Position = System.TimeSpan.FromSeconds(0);
                }
            }
        }

        private void CmdExpand_Click(object sender, RoutedEventArgs e)
        {
            bool m_check=true;
            if (LoadOpD.Entities.Count() > 0)
            {
                for (int i = 0; i < LoadOpD.Entities.Count(); i++)
                {
                    if (Convert.ToBoolean(gridControl1.GetCellValue(i, check)) == true)
                    {                       
                        m_check = false;
                        break;
                    }
                }
                Check_all(m_check);
            }
        }

        void Check_all(bool m_check)
        {         
           for (int i = 0; i < LoadOpD.Entities.Count(); i++)
             {
                gridControl1.SetCellValue(i, check,  m_check );
             }
        }        

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {

        }
     
    }
}

