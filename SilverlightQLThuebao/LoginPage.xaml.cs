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
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;

namespace SilverlightQLThuebao
{
    public partial class LoginPage : UserControl
    {
        QLThuebaoDomainContext check = new QLThuebaoDomainContext();
        FunAndPro callF = new FunAndPro();
        public LoginPage()
        {
            InitializeComponent();
           // this.cmdLogin.IsEnabled = false;
            ThemeManager.ApplicationThemeName = Theme.Office2007BlueName;
           // ThemeManager.ApplicationThemeName = Theme.Office2007BlackName;
            UploadService.UploadClient client = new UploadService.UploadClient();
            client.DoWorkCompleted += new EventHandler<UploadService.DoWorkCompletedEventArgs>(client_DoWorkCompleted);
            client.DoWorkAsync();            
        }

        void client_DoWorkCompleted(object sender, SilverlightQLThuebao.UploadService.DoWorkCompletedEventArgs e)
        {
            App.ip_address = e.Result;
            this.cmdLogin.IsEnabled = true;
            this.txtusername.Focus();
            //this.txtusername.Text = "nam";
            //this.txtpassword.Text = "admin@123";
           // App.computer_name = Application.Current.Host.Source.Host;            

        }

        private void cmdLogin_Click(object sender, RoutedEventArgs e)
        {
            callF.GetDateTime();
            if (this.txtusername.Text == "" || this.txtpassword.Password == "")
                MessageBox.Show("Username hoặc password không được trống !");
            else
            {
                this.Login.Text = "Loging...";               
                EntityQuery<user> Query = check.GetUsersQuery();
                LoadOperation<user> LoadOp = check.Load(Query.Where(p => p.user_name.Trim() == this.txtusername.Text.Trim() && p.m_password.Trim() == callF.EncrytedString(this.txtpassword.Password.Trim())), wc_DoLoginCompleted, null);
            }
        }

        void wc_DoLoginCompleted(LoadOperation<user> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                if (lo.Entities.ElementAt(0).lock_usr == true)
                {
                    userlog(false);
                    MessageBox.Show("User này đã bị khóa ! không thể đăng nhập được");
                    return;
                }
                userlog(true);
                App.User_name = lo.Entities.ElementAt(0).user_name.Trim();
                App.Password = callF.DecrytedString(lo.Entities.ElementAt(0).m_password.Trim());
                App.hoten = lo.Entities.ElementAt(0).hoten.Trim();
                App.ma_huyen = lo.Entities.ElementAt(0).huyen.Trim();
                App.nhomtd = lo.Entities.ElementAt(0).huyentd == null ? lo.Entities.ElementAt(0).huyen.Trim() : lo.Entities.ElementAt(0).huyentd.Trim();
                App.kythuat = lo.Entities.ElementAt(0).kt.Value;
                App.e_menu = lo.Entities.ElementAt(0).m_menu.Trim();
                App.sua = lo.Entities.ElementAt(0).sua.Value;
                App.admin = lo.Entities.ElementAt(0).admin.Value;
                App.lan_dau = lo.Entities.ElementAt(0).lan_dau.Value;
                App.m_themes = lo.Entities.ElementAt(0).themes.Value;
                App.admin_119 = lo.Entities.ElementAt(0).admin119.Value;
                App.adminBSC_VTT = lo.Entities.ElementAt(0).adminBSC_VTT;
                App.adminBSC_TTKD = lo.Entities.ElementAt(0).adminBSC_TTKD;
                MessageBox.Show("Yêu cầu nhập dữ liệu vào chương trình bằng font TCVN3 (font ABC)");              
                
                // lay ma khach hang bat dau cho nguoi dang nhap
                EntityQuery<don_vi> Query = check.GetDon_viQuery();
                LoadOperation<don_vi> LoadOp = check.Load(Query.Where(p => p.ma_dv.Trim() == App.ma_huyen), wc_DoLoginCompleted1, null);

                //// lay dia ban phu trach kinh doanh
                //EntityQuery<ma_diaban> Queryd = check.GetMa_diabanQuery();
                //LoadOperation<ma_diaban> LoadOpKD = check.Load(Queryd.Where(p => p.ma_huyen.Trim() == App.ma_huyen && p.kt==false), wc_DoLoginCompleted2, null);

                //// lay dia ban phu trach kinh doanh
                //EntityQuery<ma_diaban> Queryk = check.GetMa_diabanQuery();
                //LoadOperation<ma_diaban> LoadOpKT = check.Load(Queryd.Where(p => p.ma_huyen.Trim() == App.ma_huyen && p.kt == true), wc_DoLoginCompleted3, null);

                Grid root = Application.Current.RootVisual as Grid;
                if (root != null)
                {
                    root.Children.RemoveAt(0);
                    root.Children.Add(new MainPage());  // change current page to page1
                }
            }
            else
            {
                userlog(false);
                MessageBox.Show("Username hoặc password không đúng !");
                this.Login.Text = "";
            }
        }

        void wc_DoLoginCompleted1(LoadOperation<don_vi> lo)
        {
            if (lo.Entities.Count() > 0)
            {
                App.batdau_mkh = lo.Entities.ElementAt(0).batdau_mkh.Trim();
                App.ten_huyen = lo.Entities.ElementAt(0).ten_dv.Trim();
                switch (App.ma_huyen)
                {
                    case "TVH":
                        App.batdau_119 = "1";
                        App.refix_119 = 20;
                        break;
                    case "CLG":
                        App.batdau_119 = "2";
                        App.refix_119 = 57;
                        break;
                    case "TCN":
                       App.batdau_119 = "9";
                       App.refix_119 = 66;
                        break;
                    case "CKE":
                        App.batdau_119 = "7";
                        App.refix_119 = 25;
                        break;
                    case "CTH":
                        App.batdau_119 = "4";
                        App.refix_119 = 71;
                        break;
                    case "TCU":
                        App.batdau_119 = "6";
                        App.refix_119 = 32;
                        break;
                    case "CNG":
                       App.batdau_119 = "5";
                       App.refix_119 = 40;
                        break;
                    case "DHI":
                        App.batdau_119 = "8";
                        App.refix_119 = 48;
                        break;
                    default:
                        App.batdau_119 = "0";
                        break;
                }
            }
            
        }

        //void wc_DoLoginCompleted2(LoadOperation<ma_diaban> lo)
        //{
        //    if (lo.Entities.Count() > 0)
        //    {
        //       App.m_kdcs = lo.Entities.ElementAt(0). App.e_menu.Split(';');        
        //    }

        //}

        //void wc_DoLoginCompleted3(LoadOperation<ma_diaban> lo)
        //{
        //    if (lo.Entities.Count() > 0)
        //    {

        //    }

        //}

        void userlog(bool m_thanhcong)
        {
            users_log usr_lg = new users_log
            {
                user_name = txtusername.Text,
                thoi_gian = App.Current_d,
                ip_address = App.ip_address,
                thanhcong = m_thanhcong
            };
            check.users_logs.Add(usr_lg);
            check.SubmitChanges();
        }


        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            //InvokeOperation<System.Nullable<int>> p = check.CreateTableTemp();           
            //p.Completed += new EventHandler(ht);
          //  System.Windows.Browser.HtmlPage.Window.Invoke("close");
            //EntityQuery<internet> Query = check.GetInternetsQuery();
            //LoadOperation<internet> Load = check.Load(Query, LoadOperationCoplete, null);

            //MessageBox.Show("ffsdf");
            //frmchart frm = new frmchart();
            //frm.Width = this.ActualWidth;
            //frm.Height = this.ActualHeight;
            //frm.Show();

            FunAndPro callF = new FunAndPro();
            this.txtusername.Text = callF.DecrytedString(txtpassword.Text);

            //frmdiachi frm = new frmdiachi();
            //frm.Show();
         

        }

       

        //void LoadOperationCoplete(LoadOperation<internet> lo)
        //{
        //    for (int i = 0; i < lo.Entities.Count(); i++)
        //    {
        //        lo.Entities.ElementAt(i).tenkhkd = FunAndPro.KhongDau(lo.Entities.ElementAt(i).ten_dktb);
        //        lo.Entities.ElementAt(i).dckd = FunAndPro.KhongDau(lo.Entities.ElementAt(i).dia_chitb);
        //    }
        //    check.SubmitChanges();
        //    MessageBox.Show("dsaasda");
        //}
        //void ht(object sende, EventArgs e)
        //{
        //    MessageBox.Show("OK");
        //}
    }
}
