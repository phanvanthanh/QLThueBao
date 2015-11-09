using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using SilverlightQLThuebao.Web.Models;
using SilverlightQLThuebao.Web.Services;
using System.ServiceModel.DomainServices.Client;

namespace SilverlightQLThuebao
{
    public partial class MainPage : UserControl
    {
        QLThuebaoDomainContext db = new QLThuebaoDomainContext();
        MemoryStream stream;
        FileStream outStream;
        int m_themes = 0;
        ImageBrush imgBrush = new ImageBrush();       
        public MainPage()
        {
            InitializeComponent();
            switch (App.m_themes)
            {
                case 0:
                    m_themes = 0;
                    ThemeManager.ApplicationThemeName = Theme.Office2007BlueName;
                    imgBrush.ImageSource = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/Wallpaper.jpg", UriKind.Relative));                    
                    grid1.Background = imgBrush;                    
                    //mdoc.Background = imgBrush;
                    break;
                case 1:
                    m_themes = 1;
                    ThemeManager.ApplicationThemeName = Theme.DeepBlueName;
                    imgBrush.ImageSource = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/background1.jpg", UriKind.Relative));
                    grid1.Background = imgBrush;
                    //mdoc.Background = imgBrush;
                    break;
                case 2:
                    m_themes = 2;
                    ThemeManager.ApplicationThemeName = Theme.VS2010Name;
                    // grid1.Background = "/SilverlightQLThuebao;component/Images/bg_body-blue.jpg";                   
                    imgBrush.ImageSource = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/background4.jpg", UriKind.Relative));
                    grid1.Background = imgBrush;
                    //mdoc.Background = imgBrush;
                    break;
            } 
            Loaded +=new RoutedEventHandler(MainPage_Loaded);
            hopdongcodinh.ItemClick += new ItemClickEventHandler(hopdongcodinhclick);
            hopdonggphone.ItemClick += new ItemClickEventHandler(hopdongGphoneclick);
            hopdongmytv.ItemClick += new ItemClickEventHandler(hopdongMyTVclick);
            hopdongint.ItemClick += new ItemClickEventHandler(hopdongIntclick);

            doiaccountint.ItemClick += new ItemClickEventHandler(doiaccountintclick);
            doiaccountmytv.ItemClick += new ItemClickEventHandler(doiaccountmytvclick);
            timthuebao.ItemClick += new ItemClickEventHandler(timthuebaoclick);
           
            dsbdcodinh.ItemClick += new ItemClickEventHandler(bdcodinhclick);
            dsbdgphone.ItemClick += new ItemClickEventHandler(bdgphoneclick);
            dsbdmytv.ItemClick += new ItemClickEventHandler(bdmytvclick);
            dsbdint.ItemClick += new ItemClickEventHandler(bdintclick);

            dscodinh.ItemClick += new ItemClickEventHandler(danhsachcodinhclick);
            bosungcodinh.ItemClick += new ItemClickEventHandler(bosungcodinhclick);
            suacodinh.ItemClick += new ItemClickEventHandler(suacodinhclick);
            catcodinh.ItemClick += new ItemClickEventHandler(catcodinhclick);
            
            dsgphone.ItemClick += new ItemClickEventHandler(danhsachgphoneclick);
            bosunggphone.ItemClick += new ItemClickEventHandler(bosunggphoneclick);
            suagphone.ItemClick += new ItemClickEventHandler(suagphoneclick);
            catgphone.ItemClick += new ItemClickEventHandler(catgphoneclick);


            dsmytv.ItemClick += new ItemClickEventHandler(danhsachmytvclick);
            bosungmytv.ItemClick += new ItemClickEventHandler(bosungmytvclick);
            suamytv.ItemClick += new ItemClickEventHandler(suamytvclick);
            catmytv.ItemClick += new ItemClickEventHandler(catmytvclick);

            dsint.ItemClick += new ItemClickEventHandler(danhsachintclick);
            bosungint.ItemClick += new ItemClickEventHandler(bosungintclick);
            suaint.ItemClick += new ItemClickEventHandler(suaintclick);
            catint.ItemClick += new ItemClickEventHandler(catintclick);

            tuyenthu.ItemClick += new ItemClickEventHandler(tuyenthucuocclick);
            nhanvien.ItemClick += new ItemClickEventHandler(nhanvienthucuocclick);
            nhomkhachhang.ItemClick += new ItemClickEventHandler(nhomkhachhangclick);

            monitorcatmo.ItemClick += new ItemClickEventHandler(monitorcatmoclick);
            catmo.ItemClick += new ItemClickEventHandler(catmoclick);
            logcatmo.ItemClick += new ItemClickEventHandler(logcatmoclick);
            tkcatmo.ItemClick += new ItemClickEventHandler(tkcatmoclick);

            ds119.ItemClick += new ItemClickEventHandler(ds119click);
            ds119x.ItemClick += new ItemClickEventHandler(ds119xclick);
            db108.ItemClick += new ItemClickEventHandler(db108click);

            tkptcodinh.ItemClick += new ItemClickEventHandler(tkptcodinhclick);
            tkptgphone.ItemClick += new ItemClickEventHandler(tkptgphoneclick);
            tkptmytv.ItemClick += new ItemClickEventHandler(tkptmytvclick);
            tkptint.ItemClick += new ItemClickEventHandler(tkptintclick);

            tkckcodinh.ItemClick += new ItemClickEventHandler(tkckcodinhclick);
            tkckgphone.ItemClick += new ItemClickEventHandler(tkckgphoneclick);
            tkckmytv.ItemClick += new ItemClickEventHandler(tkckmytvclick);
            tkckint.ItemClick += new ItemClickEventHandler(tkckintclick);

            tkkm.ItemClick += new ItemClickEventHandler(tkkmclick);
            tkbd.ItemClick += new ItemClickEventHandler(tkbdclick);
            tklydocat.ItemClick += new ItemClickEventHandler(tklydocatclick);

            khdoanhnghiep.ItemClick += new ItemClickEventHandler(khdoanhnghiepclick);

            nhanviencs.ItemClick += new ItemClickEventHandler(nhanviencsclick);
            tuyencs.ItemClick += new ItemClickEventHandler(tuyencsclick);
            cscodinh.ItemClick += new ItemClickEventHandler(cscodinhclick);
            csgphone.ItemClick += new ItemClickEventHandler(csgphoneclick);
            csmytv.ItemClick += new ItemClickEventHandler(csmytvclick);
            csint.ItemClick += new ItemClickEventHandler(csintclick);

            ktcodinh.ItemClick += new ItemClickEventHandler(ktcodinhclick);
            ktgphone.ItemClick += new ItemClickEventHandler(ktgphoneclick);
            ktmytv.ItemClick += new ItemClickEventHandler(ktmytvclick);
            ktint.ItemClick += new ItemClickEventHandler(ktintclick);

            tkslgandb.ItemClick += new ItemClickEventHandler(tkslganclick);
            tkdtgandb.ItemClick += new ItemClickEventHandler(tkdtganclick);

            giaobsctinh.ItemClick += new ItemClickEventHandler(giaobsctinhclick);
            giaobscnld.ItemClick += new ItemClickEventHandler(giaobscnldclick);

            xaphuong.ItemClick += new ItemClickEventHandler(xaphuongclick);
            apkhom.ItemClick += new ItemClickEventHandler(apkhomclick);
            duong.ItemClick += new ItemClickEventHandler(duongclick);
            tramvt.ItemClick += new ItemClickEventHandler(tramvtclick);

            filetam.ItemClick += new ItemClickEventHandler(filetamclick);
            khuyenmai.ItemClick += new ItemClickEventHandler(khuyenmaiclick);

            doimatkhau.ItemClick += new ItemClickEventHandler(doimatkhauclick);
            quanlyuser.ItemClick += new ItemClickEventHandler(quanlyuserclick);            
            Loguser.ItemClick += new ItemClickEventHandler(Loguserclick);
            Logcodinh.ItemClick += new ItemClickEventHandler(Logcodinhclick);
            Loggphone.ItemClick += new ItemClickEventHandler(Loggphoneclick);
            Logmytv.ItemClick += new ItemClickEventHandler(Logmytvclick);
            Loginternet.ItemClick += new ItemClickEventHandler(Loginternetclick);
            logout.ItemClick += new ItemClickEventHandler(LogoutClick);
            shutdown.ItemClick += new ItemClickEventHandler(ShutDownClick);

            help.ItemClick += new ItemClickEventHandler(DownloadHelpclick);
            about.ItemClick += new ItemClickEventHandler(Aboutclick);

            choso.ItemClick += new ItemClickEventHandler(Chosoclick);


            string[] m_menu = App.e_menu.Split(';');         
            foreach (string s in m_menu)
            {
                for (int i = 0; i < barManager1.Items.Count; i++)
                {
                    if (barManager1.Items.ElementAt(i).Name == s)
                        barManager1.Items.ElementAt(i).IsEnabled = true;
                }
            }
            if (App.admin)
            {
                quanlyuser.IsEnabled = true;
                Loguser.IsEnabled = true;
                
            }

            EntityQuery<thongbao> Query = db.GetThongbaoQuery();
            LoadOperation<thongbao> LoadOp = db.Load(Query.Where(p => p.ma_huyen == App.ma_huyen), LoadOperationCompleted, false);
            bPosInfo.Content = "Xin chào: " + Converter.TCVN3ToUnicode(App.hoten) + " ! chúc làm việc vui vẻ.";
        }

        void LoadOperationCompleted(LoadOperation<thongbao> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                string strs = lo.Entities.ElementAt(0).noi_dung == null ? "" : lo.Entities.ElementAt(0).noi_dung.Trim();
                txtthongbao.Text = "Th«ng b¸o:" + Environment.NewLine + "  - " + strs;
            }
            else
                txtthongbao.Text = "";
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.lan_dau)
            {
                frmdoimk frm = new frmdoimk();
                frm.Show();
            }         
        }

        void hopdongcodinhclick(object sender, RoutedEventArgs e)
        {
            frmhopdongcd nhaphdcd = new frmhopdongcd();
            nhaphdcd.Show();

        }
        void hopdongGphoneclick(object sender, RoutedEventArgs e)
        {
            frmhopdonggp nhaphdgp = new frmhopdonggp();
            nhaphdgp.Show();

        }

        void hopdongMyTVclick(object sender, RoutedEventArgs e)
        {
            frmhopdongmy nhaphdmy = new frmhopdongmy();
            nhaphdmy.Show();
        }

        void hopdongIntclick(object sender, RoutedEventArgs e)
        {
            frmhopdongint frm = new frmhopdongint();
            frm.Show();
        }

        void doiaccountintclick(object sender, RoutedEventArgs e)
        {
            frmdoiaccount frm = new frmdoiaccount();
            frm.Show();
        }

        void doiaccountmytvclick(object sender, RoutedEventArgs e)
        {
            frmdoiaccountmytv frm = new frmdoiaccountmytv();
            frm.Show();
        }

        void timthuebaoclick(object sender, RoutedEventArgs e)
        {
            frmtimint frm = new frmtimint();
            frm.Width = this.ActualWidth;
            frm.Height = this.ActualHeight;
            frm.Show();
        }   
        
        void bdcodinhclick(object sender, RoutedEventArgs e)
        {
            frmdsbdcodinh bdcd = new frmdsbdcodinh();
            bdcd.Width = this.ActualWidth;
            bdcd.Height = this.ActualHeight;
            bdcd.Show();
        }
        void bdgphoneclick(object sender, RoutedEventArgs e)
        {            
            frmdsbdgphone bdgp = new frmdsbdgphone();
            bdgp.Width = this.ActualWidth;
            bdgp.Height = this.ActualHeight;
            bdgp.Show();
        }

        void bdintclick(object sender, RoutedEventArgs e)
        {
            frmdsbdint frm = new frmdsbdint();
            frm.Width = this.ActualWidth;
            frm.Height = this.ActualHeight;
            frm.Show();
        }

        void bdmytvclick(object sender, RoutedEventArgs e)
        {
            frmdsbdmytv frm = new frmdsbdmytv();
            frm.Width = this.ActualWidth;
            frm.Height = this.ActualHeight;
            frm.Show();
        }

         void danhsachcodinhclick(object sender, RoutedEventArgs e)
        {
            frmdscodinh dscd = new frmdscodinh();
            dscd.Width = this.ActualWidth;
            dscd.Height = this.ActualHeight;
            dscd.Show();
        }

         void bosungcodinhclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmeditcd editcd = new frmeditcd(true, "", 0);
                 editcd.Show();
             }
         }

         void suacodinhclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmeditcd editcd = new frmeditcd(false, "", 0);
                 editcd.Show();
             }
         }

         void catcodinhclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmcatcd catcd = new frmcatcd("",false);
                 catcd.Show();
             }
         }


         void danhsachgphoneclick(object sender, RoutedEventArgs e)
         {
             frmdsgphone dsgp = new frmdsgphone();
             dsgp.Width = this.ActualWidth;
             dsgp.Height = this.ActualHeight;
             dsgp.Show();
         }
         
        void bosunggphoneclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmeditgp editgp = new frmeditgp(true, "", 0);
                 editgp.Show();
             }
         }

         void suagphoneclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmeditgp editgp = new frmeditgp(false, "", 0);                
                 editgp.Show();         
             }
         }

         void catgphoneclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {                
                 frmcatgp catgp = new frmcatgp("",false);                
                 catgp.Show();
             }
         }

         void danhsachmytvclick(object sender, RoutedEventArgs e)
         {
             frmdsmytv dsmy = new frmdsmytv();
             dsmy.Width = this.ActualWidth;
             dsmy.Height = this.ActualHeight;
             dsmy.Show();
         }

         void bosungmytvclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmeditmy editmy = new frmeditmy("");
                 editmy.Show();
             }

         }

         void suamytvclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmeditmy editmy = new frmeditmy("");                                 
                 editmy.Show();                
             }
         }

         void catmytvclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmcatmy catmy = new frmcatmy("");                 
                 catmy.Show();        
             }
         }


         void danhsachintclick(object sender, RoutedEventArgs e)
         {
             frmdsinternet dsmy = new frmdsinternet();
             dsmy.Width = this.ActualWidth;
             dsmy.Height = this.ActualHeight;
             dsmy.Show();
         }

         void bosungintclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmeditint frm = new frmeditint("");
                 frm.Show();
             }

         }

         void suaintclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmeditint frm = new frmeditint("");
                 frm.Show();
             }
         }

         void catintclick(object sender, RoutedEventArgs e)
         {
             if (App.sua)
             {
                 frmcatint catmy = new frmcatint("");
                 catmy.Show();
             }
         }

         void tuyenthucuocclick(object sender, RoutedEventArgs e)
         {
             frmtuyenthu dstuyen = new frmtuyenthu("");
             dstuyen.Width = this.ActualWidth;
             dstuyen.Height = this.ActualHeight;
             dstuyen.Show();
         }

         void nhanvienthucuocclick(object sender, RoutedEventArgs e)
         {
             frmthuethu dstuyen = new frmthuethu();          
             dstuyen.Show();
         }
         void nhomkhachhangclick(object sender, RoutedEventArgs e)
         {
             frmdsnhom dsnhom = new frmdsnhom();
             dsnhom.Width = this.ActualWidth;
             dsnhom.Height = this.ActualHeight;
             dsnhom.Show();
         }

         void monitorcatmoclick(object sender, RoutedEventArgs e)
         {
             frmmonitor dscatmo = new frmmonitor();          
             dscatmo.Show();
         }
         void catmoclick(object sender, RoutedEventArgs e)
         {
             frmmoso moso = new frmmoso();
             moso.Show();
         }
         void logcatmoclick(object sender, RoutedEventArgs e)
         {
             frmlogcatmo logcatmo = new frmlogcatmo();
              logcatmo.Width = this.ActualWidth;
              logcatmo.Height = this.ActualHeight;
              logcatmo.Show();
         }
         void tkcatmoclick(object sender, RoutedEventArgs e)
         {
             frmtkcatmo tkcatmo = new frmtkcatmo();
             tkcatmo.Width = this.ActualWidth;
             tkcatmo.Height = this.ActualHeight;
             tkcatmo.Show();
         }


         void ds119click(object sender, RoutedEventArgs e)
         {
             frmds119 frm = new frmds119();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void ds119xclick(object sender, RoutedEventArgs e)
         {
             frmsuaxong frm = new frmsuaxong();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void db108click(object sender, RoutedEventArgs e)
         {
             frm1080 frm = new frm1080();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tkptcodinhclick(object sender, RoutedEventArgs e)
         {
           
             frmtkptcodinh frm = new frmtkptcodinh();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tkptgphoneclick(object sender, RoutedEventArgs e)
         {
             frmtkptgphone tkptgp = new frmtkptgphone();
             tkptgp.Width = this.ActualWidth;
             tkptgp.Height = this.ActualHeight;
             tkptgp.Show();
         }

         void khdoanhnghiepclick(object sender, RoutedEventArgs e)
         {
             frmkhdoanhnghiep frm = new frmkhdoanhnghiep();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tkptmytvclick(object sender, RoutedEventArgs e)
         {
             //MessageBox.Show("sfafadfa");
             frmtkptmytv tkptmy = new frmtkptmytv();
             tkptmy.Width = this.ActualWidth;
             tkptmy.Height = this.ActualHeight;
             tkptmy.Show();
         }

         void tkptintclick(object sender, RoutedEventArgs e)
         {
             frmtkptint frm = new frmtkptint();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tkckcodinhclick(object sender, RoutedEventArgs e)
         {
             frmtkckcodinh frm = new frmtkckcodinh();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tkckgphoneclick(object sender, RoutedEventArgs e)
         {
             frmtkckgphone frm = new frmtkckgphone();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }


         void tkckmytvclick(object sender, RoutedEventArgs e)
         {
             frmtkckmytv frm = new frmtkckmytv();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tkckintclick(object sender, RoutedEventArgs e)
         {
             frmtkckint frm = new frmtkckint();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }


         void tkkmclick(object sender, RoutedEventArgs e)
         {
             frmtkkm frm = new frmtkkm();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tkbdclick(object sender, RoutedEventArgs e)
         {
             frmtkbd frm = new frmtkbd();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tklydocatclick(object sender, RoutedEventArgs e)
         {
             frmtklydocat frm = new frmtklydocat();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void xaphuongclick(object sender, RoutedEventArgs e)
         {
             frmxaphuong frmxaphuong = new frmxaphuong();           
             frmxaphuong.Show();
         }
         void apkhomclick(object sender, RoutedEventArgs e)
         {
             frmapkhom frmapkhom = new frmapkhom();
             frmapkhom.Show();
         }
         void duongclick(object sender, RoutedEventArgs e)
         {
             frmduong frmduong = new frmduong();
             frmduong.Show();
         }
         void tramvtclick(object sender, RoutedEventArgs e)
         {
             frmtramvt frm = new frmtramvt();
             frm.Show();
         }

         void filetamclick(object sender, RoutedEventArgs e)
         {
             frmdstam frm = new frmdstam();
             frm.Show();
         }

         void khuyenmaiclick(object sender, RoutedEventArgs e)
         {
             frmkhuyenmai frm = new frmkhuyenmai();
             frm.Show();
         }

         void doimatkhauclick(object sender, RoutedEventArgs e)
         {
             frmdoimk frm = new frmdoimk();
             frm.Show();
         }
         void quanlyuserclick(object sender, RoutedEventArgs e)
         {
             frmusers frm = new frmusers();
             frm.Show();
         }
         void Loguserclick(object sender, RoutedEventArgs e)
         {
             frmlogusers frm = new frmlogusers();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();

         }
         void Logcodinhclick(object sender, RoutedEventArgs e)
         {
             frmlogcodinh frm = new frmlogcodinh();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }
         void Loggphoneclick(object sender, RoutedEventArgs e)
         {
             frmloggphone frm = new frmloggphone();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }
         void Logmytvclick(object sender, RoutedEventArgs e)
         {
             frmlogmytv frm = new frmlogmytv();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }
         void Loginternetclick(object sender, RoutedEventArgs e)
         {
             frmlogint frm = new frmlogint();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }


         void nhanviencsclick(object sender, RoutedEventArgs e)
         {
             frmnhanviencs frm = new frmnhanviencs();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tuyencsclick(object sender, RoutedEventArgs e)
         {
             frmdiabancs frm = new frmdiabancs();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void cscodinhclick(object sender, RoutedEventArgs e)
         {
             frmcscodinh frm = new frmcscodinh();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void csgphoneclick(object sender, RoutedEventArgs e)
         {
             frmcsgphone frm = new frmcsgphone();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void csmytvclick(object sender, RoutedEventArgs e)
         {
             frmcsmytv frm = new frmcsmytv();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void csintclick(object sender, RoutedEventArgs e)
         {
             frmcsint frm = new frmcsint();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }


         void ktcodinhclick(object sender, RoutedEventArgs e)
         {
             frmktcodinh frm = new frmktcodinh();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void ktgphoneclick(object sender, RoutedEventArgs e)
         {
             frmktgphone frm = new frmktgphone();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void ktmytvclick(object sender, RoutedEventArgs e)
         {
             frmktmytv frm = new frmktmytv();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void ktintclick(object sender, RoutedEventArgs e)
         {
             frmktint frm = new frmktint();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tkslganclick(object sender, RoutedEventArgs e)
         {
             frmtkslgandb frm = new frmtkslgandb();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void tkdtganclick(object sender, RoutedEventArgs e)
         {
             frmtkdtgandb frm = new frmtkdtgandb();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void giaobsctinhclick(object sender, RoutedEventArgs e)
         {
             frmbsctinh frm = new frmbsctinh();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void giaobscnldclick(object sender, RoutedEventArgs e)
         {
             frmbscnld frm = new frmbscnld();
             frm.Width = this.ActualWidth;
             frm.Height = this.ActualHeight;
             frm.Show();
         }

         void Aboutclick(object sender, RoutedEventArgs e)
         {
             frmabout frm = new frmabout();
             frm.Show();
             //frmtestf frm = new frmtestf();
             //frm.Show();
         }


         void Chosoclick(object sender, RoutedEventArgs e)
         {
             frmchoso119 frm = new frmchoso119();
             frm.Show();
             //frmtestf frm = new frmtestf();
             //frm.Show();
         }

         void LogoutClick(object sender, RoutedEventArgs e)
         {
             System.Windows.Browser.HtmlPage.Document.Submit();

         }

         void ShutDownClick(object sender, RoutedEventArgs e)
         {
             System.Windows.Browser.HtmlPage.Window.Invoke("close");
         }

         void DownloadHelpclick(object sender, RoutedEventArgs e)
         {             
             SaveFileDialog Dialog = new SaveFileDialog();
             Dialog.Filter = "PDF Files (*.pdf)|*.pdf";
             Dialog.DefaultFileName = "HD_bien_dong_thue_bao";
             Dialog.ShowDialog();
             outStream = (FileStream)Dialog.OpenFile();
             var fs = new UploadService.UploadClient();
             fs.DownloadCompleted += new EventHandler<SilverlightQLThuebao.UploadService.DownloadCompletedEventArgs>(fs_DownloadCompleted);
             fs.DownloadAsync("HD_bien_dong_thue_bao.pdf");

             //FunAndPro callF = new FunAndPro();
             //callF.Download_Help("HD_bien_dong_thue_bao.pdf");
         }     

         void fs_DownloadCompleted(object sender, UploadService.DownloadCompletedEventArgs e)
         {            
             if (e.Error == null)
             {
                 if (e.Result != null)
                 {                    
                     UploadService.PictureFile imageDownload = e.Result;
                     stream = new MemoryStream(imageDownload.PictureStream);                                                      
                     stream.WriteTo(outStream);
                     outStream.Flush();
                     outStream.Close();
                     imageDownload.PictureStream = null;
                     //stream.Close();
                     MessageBox.Show("Đã lưu file hướng dẫn !");
                 }
                 else
                 {
                     MessageBox.Show("File help không tồn tại !");
                 }
             }
         }

         protected virtual void OnThemeItemClick(object sender, GalleryItemEventArgs e)
         {
             string themeName = (string)e.Item.Caption;
             switch (themeName)
             {
                 case "Office2007BlueName":
                     m_themes = 0;
                     ThemeManager.ApplicationThemeName = Theme.Office2007BlueName;
                     imgBrush.ImageSource = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/background2.jpg", UriKind.Relative));
                     grid1.Background = imgBrush;                    
                     txtthongbao.Foreground = new SolidColorBrush(Colors.Red);
                     SetThemes();
                     break;
                 case "DeepBlueName":
                     m_themes = 1;
                     ThemeManager.ApplicationThemeName = Theme.DeepBlueName;
                     imgBrush.ImageSource = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/background1.jpg", UriKind.Relative));
                     grid1.Background = imgBrush;                     
                     SetThemes();
                     break;
                 case "DXStyleName":
                     m_themes = 2;
                     ThemeManager.ApplicationThemeName = Theme.VS2010Name;
                     // grid1.Background = "/SilverlightQLThuebao;component/Images/bg_body-blue.jpg";                   
                     imgBrush.ImageSource = new BitmapImage(new Uri("/SilverlightQLThuebao;component/Images/background4.jpg", UriKind.Relative));
                     grid1.Background = imgBrush;
                     SetThemes();
                     break;
             }
         }

         void SetThemes()
         {
             EntityQuery<user> Query = db.GetUsersQuery();
             LoadOperation<user> Load = db.Load(Query.Where(p => p.user_name.Trim() == App.User_name), LoadOperationCompleted, true);
         }

         void LoadOperationCompleted(LoadOperation<user> lo)
         {
             if (lo.Entities.Count() > 0)
             {
                 lo.Entities.ElementAt(0).themes = m_themes;
                 db.SubmitChanges();
             }
         }

    }
}
